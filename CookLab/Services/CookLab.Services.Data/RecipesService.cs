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

    using Microsoft.EntityFrameworkCore;

    public class RecipesService : IRecipesService
    {
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;
        private readonly IRepository<CookingVessel> cookingVesselRepository;
        private readonly IDeletableEntityRepository<RecipeImage> recipeImageRepository;
        private readonly IDeletableEntityRepository<CategoryRecipe> categoryRecipesRepository;
        private readonly ICategoriesService categoriesService;
        private readonly IIngredientsService ingredientsService;
        private readonly INutritionsService nutritionsService;

        public RecipesService(
            IDeletableEntityRepository<Recipe> recipesRepository,
            IRepository<CookingVessel> cookingVesselRepository,
            IDeletableEntityRepository<RecipeImage> recipeImageRepository,
            IDeletableEntityRepository<CategoryRecipe> categoryRecipesRepository,
            ICategoriesService categoriesService,
            IIngredientsService ingredientsService,
            INutritionsService nutritionsService)
        {
            this.recipesRepository = recipesRepository;
            this.cookingVesselRepository = cookingVesselRepository;
            this.recipeImageRepository = recipeImageRepository;
            this.categoryRecipesRepository = categoryRecipesRepository;
            this.categoriesService = categoriesService;
            this.ingredientsService = ingredientsService;
            this.nutritionsService = nutritionsService;
        }

        public INutritionsService NutritionsService { get; }

        public async Task<string> CreateAsync(string userId, RecipeInputModel inputModel, string rootPath)
        {
            if (this.recipesRepository.All().Any(x => x.Name == inputModel.Name))
            {
                throw new ArgumentException(ExceptionMessages.RecipeAlreadyExists, inputModel.Name);
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

            foreach (var imageFile in inputModel.Images)
            {
                var image = new RecipeImage();
                image.ImageUrl = $"assets/img/recipes/{image.Id}.jpg";
                image.Recipe = recipe;

                await this.recipeImageRepository.AddAsync(image);

                string imagePath = rootPath + image.ImageUrl;
                image.RecipeId = recipe.Id;

                using (FileStream stream = new FileStream(imagePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
            }

            foreach (var categoryId in inputModel.Categories)
            {
                var categoryRecipe = new CategoryRecipe
                {
                    CategoryId = int.Parse(categoryId.Value),
                    Recipe = recipe,
                };

                await this.categoryRecipesRepository.AddAsync(categoryRecipe);
            }

            foreach (var ingredient in inputModel.Ingredients)
            {

            }

            await this.recipesRepository.AddAsync(recipe);
            await this.recipesRepository.SaveChangesAsync();
            await this.recipeImageRepository.SaveChangesAsync();
            await this.categoryRecipesRepository.SaveChangesAsync();

            return recipe.Id;
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
