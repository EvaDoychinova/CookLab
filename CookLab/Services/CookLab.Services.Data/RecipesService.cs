namespace CookLab.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Common;
    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.InputModels.Recipes;
    using CookLab.Models.ViewModels.Recipes;
    using CookLab.Services.Mapping;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class RecipesService : IRecipesService
    {
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;
        private readonly IRepository<CookingVessel> cookingVesselRepository;
        private readonly IDeletableEntityRepository<Ingredient> ingredientRepository;
        private readonly IDeletableEntityRepository<Category> categoryRepository;
        private readonly IDeletableEntityRepository<RecipeImage> recipeImageRepository;
        private readonly IDeletableEntityRepository<CategoryRecipe> categoryRecipesRepository;
        private readonly IDeletableEntityRepository<RecipeIngredient> ingredientRecipeRepository;
        private readonly IDeletableEntityRepository<Nutrition> nutritionRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly INutritionsService nutritionsService;

        public RecipesService(
            IDeletableEntityRepository<Recipe> recipesRepository,
            IRepository<CookingVessel> cookingVesselRepository,
            IDeletableEntityRepository<Ingredient> ingredientRepository,
            IDeletableEntityRepository<Category> categoryRepository,
            IDeletableEntityRepository<RecipeImage> recipeImageRepository,
            IDeletableEntityRepository<CategoryRecipe> categoryRecipesRepository,
            IDeletableEntityRepository<RecipeIngredient> ingredientRecipeRepository,
            IDeletableEntityRepository<Nutrition> nutritionRepository,
            UserManager<ApplicationUser> userManager,
            INutritionsService nutritionsService)
        {
            this.recipesRepository = recipesRepository;
            this.cookingVesselRepository = cookingVesselRepository;
            this.ingredientRepository = ingredientRepository;
            this.categoryRepository = categoryRepository;
            this.recipeImageRepository = recipeImageRepository;
            this.categoryRecipesRepository = categoryRecipesRepository;
            this.ingredientRecipeRepository = ingredientRecipeRepository;
            this.nutritionRepository = nutritionRepository;
            this.userManager = userManager;
            this.nutritionsService = nutritionsService;
        }

        public INutritionsService NutritionsService { get; }

        public async Task<string> CreateAsync(string userId, RecipeInputModel inputModel, string rootPath)
        {
            if (this.recipesRepository.All().Any(x => x.Name == inputModel.Name))
            {
                throw new ArgumentException(ExceptionMessages.RecipeAlreadyExists, inputModel.Name);
            }

            var cookingVessel = this.cookingVesselRepository.All()
                .FirstOrDefault(x => x.Id == inputModel.CookingVesselId);

            if (cookingVessel == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.CookingVesselMissing, inputModel.CookingVesselId));
            }

            var recipe = new Recipe
            {
                Name = inputModel.Name,
                PreparationTime = TimeSpan.FromMinutes(inputModel.PreparationTime),
                CookingTime = TimeSpan.FromMinutes(inputModel.CookingTime),
                Preparation = inputModel.Preparation,
                CreatorId = userId,
                CookingVesselId = inputModel.CookingVesselId,
            };

            cookingVessel.Recipes.Add(recipe);

            var user = await this.userManager.FindByIdAsync(userId);

            user.CreatedRecipes.Add(recipe);

            foreach (var imageFile in inputModel.Images)
            {
                var image = new RecipeImage();
                image.ImageUrl = $"/assets/img/recipes/{image.Id}.jpg";
                image.RecipeId = recipe.Id;

                string imagePath = rootPath + image.ImageUrl;

                using (FileStream stream = new FileStream(imagePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                recipe.Images.Add(image);
            }

            foreach (var categoryId in inputModel.SelectedCategories)
            {
                var category = this.categoryRepository.All()
                    .FirstOrDefault(x => x.Id == categoryId);

                if (category == null)
                {
                    throw new NullReferenceException(
                    string.Format(ExceptionMessages.CategoryMissing, categoryId));
                }

                var categoryRecipe = new CategoryRecipe
                {
                    CategoryId = categoryId,
                    RecipeId = recipe.Id,
                };

                recipe.Categories.Add(categoryRecipe);
                category.Recipes.Add(categoryRecipe);
            }

            foreach (var ingredientInputModel in inputModel.SelectedIngredients)
            {
                var ingredient = this.ingredientRepository.All()
                .FirstOrDefault(x => x.Id == ingredientInputModel.IngredientId);

                if (ingredient == null)
                {
                    throw new NullReferenceException(
                    string.Format(ExceptionMessages.IngredientMissing, ingredientInputModel.IngredientId));
                }

                var ingredientRecipe = new RecipeIngredient
                {
                    IngredientId = ingredientInputModel.IngredientId,
                    WeightInGrams = ingredientInputModel.WeightInGrams,
                    RecipeId = recipe.Id,
                };

                recipe.Ingredients.Add(ingredientRecipe);
                ingredient.Recipies.Add(ingredientRecipe);
            }

            await this.recipesRepository.AddAsync(recipe);
            await this.recipesRepository.SaveChangesAsync();
            await this.recipeImageRepository.SaveChangesAsync();
            await this.categoryRecipesRepository.SaveChangesAsync();
            await this.ingredientRecipeRepository.SaveChangesAsync();

            var recipeWithNutrition = this.recipesRepository.All()
                .Where(x => x.Name == inputModel.Name)
                .FirstOrDefault();

            if (recipeWithNutrition == null)
            {
                throw new ArgumentException(ExceptionMessages.RecipeIncorrect, recipeWithNutrition.Name);
            }

            if (recipeWithNutrition.Ingredients.Count > 0)
            {
                var nutritions = this.nutritionRepository.All()
                    .ToList()
                    .Where(x => recipeWithNutrition.Ingredients.Any(y => y.IngredientId == x.IngredientId));

                if (nutritions.Any(x => x == null))
                {
                    recipeWithNutrition.NutritionPer100Grams = null;
                }
                else
                {
                    await this.nutritionsService.CalculateNutritionForRecipeAsync(recipeWithNutrition.Id);
                }
            }

            return recipeWithNutrition.Id;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var recipes = await this.recipesRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .To<T>()
                .ToListAsync();

            return recipes;
        }

        public async Task<T> GetByIdAsync<T>(string id)
        {
            var recipe = await this.recipesRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return recipe;
        }

        public async Task<IEnumerable<T>> GetAllByCategoryAsync<T>(int categoryId)
        {
            var recipes = await this.recipesRepository.All()
                .Where(x => x.Categories
                             .Any(y => y.CategoryId == categoryId))
                .To<T>()
                .ToListAsync();

            return recipes;
        }

        public async Task<IEnumerable<T>> GetAllByCreatorAsync<T>(string userId)
        {
            var recipes = await this.recipesRepository.All()
                .Where(x => x.CreatorId == userId)
                .To<T>()
                .ToListAsync();

            return recipes;
        }

        public async Task<IEnumerable<T>> GetAllByUserAsync<T>(string userId)
        {
            var recipes = await this.recipesRepository.All()
                .Where(x => x.Users
                             .Any(y => y.UserId == userId))
                .To<T>()
                .ToListAsync();

            return recipes;
        }

        public async Task EditAsync(RecipeEditViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
