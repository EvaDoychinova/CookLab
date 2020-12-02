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
        private readonly IDeletableEntityRepository<UserRecipe> userRecipeRepository;
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
            IDeletableEntityRepository<UserRecipe> userRecipeRepository,
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
            this.userRecipeRepository = userRecipeRepository;
            this.nutritionRepository = nutritionRepository;
            this.userManager = userManager;
            this.nutritionsService = nutritionsService;
        }

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
                Notes = inputModel.Notes,
                Portions = inputModel.Portions,
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
                    PartOfRecipe = ingredientInputModel.PartOfRecipe,
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
                    recipeWithNutrition.Nutrition = null;
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
            var recipes = await this.recipesRepository.AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .To<T>()
                .ToListAsync();

            return recipes;
        }

        public async Task<T> GetByIdAsync<T>(string id)
        {
            var recipe = await this.recipesRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return recipe;
        }

        public async Task<IEnumerable<T>> GetAllByCategoryAsync<T>(int categoryId)
        {
            var recipes = await this.recipesRepository.AllAsNoTracking()
                .Where(x => x.Categories
                .Any(y => y.CategoryId == categoryId))
                .To<T>()
                .ToListAsync();

            return recipes;
        }

        public async Task<IEnumerable<T>> GetAllByCreatorAsync<T>(string userId)
        {
            var recipes = await this.recipesRepository.AllAsNoTracking()
                .Where(x => x.CreatorId == userId)
                .To<T>()
                .ToListAsync();

            return recipes;
        }

        public async Task<IEnumerable<T>> GetAllByUserAsync<T>(string userId)
        {
            var recipes = await this.recipesRepository.AllAsNoTracking()
                .Where(x => x.Users
                .Any(y => y.UserId == userId))
                .To<T>()
                .ToListAsync();

            return recipes;
        }

        public async Task EditAsync(RecipeEditViewModel viewModel, string rootPath)
        {
            var recipe = await this.recipesRepository.All()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (recipe == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RecipeMissing, viewModel.Id));
            }

            if (this.recipesRepository.All().Any(x => x.Name == viewModel.Name && x.Id != viewModel.Id))
            {
                throw new ArgumentException(ExceptionMessages.RecipeAlreadyExists, viewModel.Name);
            }

            recipe.Name = viewModel.Name;
            recipe.PreparationTime = viewModel.PreparationTime;
            recipe.CookingTime = viewModel.CookingTime;
            recipe.Portions = viewModel.Portions;
            recipe.Preparation = viewModel.Preparation;
            recipe.Notes = viewModel.Notes;
            recipe.ModifiedOn = DateTime.UtcNow;

            var cookingVesselBeforeEdit = await this.cookingVesselRepository.All()
                .FirstOrDefaultAsync(x => x.Id == recipe.CookingVesselId);

            if (cookingVesselBeforeEdit.Id != viewModel.CookingVesselId)
            {
                var cookingVessel = await this.cookingVesselRepository.All()
                .FirstOrDefaultAsync(x => x.Id == viewModel.CookingVesselId);

                if (cookingVessel == null)
                {
                    throw new NullReferenceException(
                        string.Format(ExceptionMessages.CookingVesselMissing, viewModel.CookingVesselId));
                }

                recipe.CookingVesselId = viewModel.CookingVesselId;
                cookingVessel.Recipes.Add(recipe);
                cookingVesselBeforeEdit.Recipes.Remove(recipe);
            }

            var recipesCategoriesBeforeEdit = this.categoryRecipesRepository.All()
                .Where(x => x.RecipeId == recipe.Id);

            foreach (var recipesCategory in recipesCategoriesBeforeEdit)
            {
                this.categoryRecipesRepository.HardDelete(recipesCategory);
            }

            await this.categoryRecipesRepository.SaveChangesAsync();

            foreach (var categoryId in viewModel.CategoriesCategoryId)
            {
                var category = await this.categoryRepository.All()
                    .FirstOrDefaultAsync(x => x.Id == categoryId);

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

            var recipeIngredientsBeforeEdit = this.ingredientRecipeRepository.All()
                .Where(x => x.RecipeId == recipe.Id);

            foreach (var recipeIngredient in recipeIngredientsBeforeEdit)
            {
                this.ingredientRecipeRepository.HardDelete(recipeIngredient);
            }

            await this.ingredientRecipeRepository.SaveChangesAsync();

            foreach (var recipeIngredient in viewModel.Ingredients)
            {
                var ingredient = this.ingredientRepository.All()
                    .FirstOrDefault(x => x.Id == recipeIngredient.IngredientId);

                if (ingredient == null)
                {
                    throw new NullReferenceException(
                    string.Format(ExceptionMessages.IngredientMissing, recipeIngredient.IngredientId));
                }

                var ingredientRecipe = new RecipeIngredient
                {
                    IngredientId = recipeIngredient.IngredientId,
                    WeightInGrams = recipeIngredient.WeightInGrams,
                    PartOfRecipe = recipeIngredient.PartOfRecipe,
                    RecipeId = recipe.Id,
                };

                recipe.Ingredients.Add(ingredientRecipe);
                ingredient.Recipies.Add(ingredientRecipe);
            }

            if (viewModel.ImagesToSelect != null)
            {
                var imagesBeforeEdit = this.recipeImageRepository.All()
                .Where(x => x.RecipeId == recipe.Id);

                foreach (var image in imagesBeforeEdit)
                {
                    this.recipeImageRepository.HardDelete(image);
                }

                await this.recipeImageRepository.SaveChangesAsync();

                foreach (var fileImage in viewModel.ImagesToSelect)
                {
                    var image = new RecipeImage();
                    image.ImageUrl = $"/assets/img/recipes/{image.Id}.jpg";
                    image.RecipeId = recipe.Id;

                    string imagePath = rootPath + image.ImageUrl;

                    using (FileStream stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await fileImage.CopyToAsync(stream);
                    }

                    recipe.Images.Add(image);
                }

                await this.recipeImageRepository.SaveChangesAsync();
            }

            this.recipesRepository.Update(recipe);
            await this.recipesRepository.SaveChangesAsync();
            await this.cookingVesselRepository.SaveChangesAsync();
            await this.categoryRecipesRepository.SaveChangesAsync();
            await this.categoryRepository.SaveChangesAsync();
            await this.ingredientRecipeRepository.SaveChangesAsync();
            await this.ingredientRepository.SaveChangesAsync();

            var nutrition = await this.nutritionRepository.All()
                .FirstOrDefaultAsync(x => x.RecipeId == recipe.Id);

            if (nutrition != null)
            {
                this.nutritionRepository.HardDelete(nutrition);
            }

            await this.nutritionsService.CalculateNutritionForRecipeAsync(recipe.Id);
        }

        public async Task DeleteAsync(string id)
        {
            var recipe = await this.recipesRepository.All()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (recipe == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RecipeMissing, id));
            }

            this.recipesRepository.Delete(recipe);

            var recipeIngredients = await this.ingredientRecipeRepository.All()
                .Where(x => x.RecipeId == recipe.Id)
                .ToListAsync();

            foreach (var ingredient in recipeIngredients)
            {
                this.ingredientRecipeRepository.Delete(ingredient);
            }

            var recipeImages = await this.recipeImageRepository.All()
                .Where(x => x.RecipeId == recipe.Id)
                .ToListAsync();

            foreach (var image in recipeImages)
            {
                this.recipeImageRepository.Delete(image);
            }

            var recipeCategories = await this.categoryRecipesRepository.All()
                .Where(x => x.RecipeId == recipe.Id)
                .ToListAsync();

            foreach (var category in recipeCategories)
            {
                this.categoryRecipesRepository.Delete(category);
            }

            var recipeUsers = await this.userRecipeRepository.All()
                .Where(x => x.RecipeId == recipe.Id)
                .ToListAsync();

            foreach (var user in recipeUsers)
            {
                this.userRecipeRepository.Delete(user);
            }

            await this.recipesRepository.SaveChangesAsync();
            await this.ingredientRecipeRepository.SaveChangesAsync();
            await this.recipeImageRepository.SaveChangesAsync();
            await this.categoryRecipesRepository.SaveChangesAsync();
            await this.userRecipeRepository.SaveChangesAsync();
        }
    }
}
