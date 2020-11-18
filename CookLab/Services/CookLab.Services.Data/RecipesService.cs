namespace CookLab.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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
        private readonly ICategoriesService categoriesService;
        private readonly IIngredientsService ingredientsService;
        private readonly INutritionsService nutritionsService;

        public RecipesService(
            IDeletableEntityRepository<Recipe> recipesRepository,
            IRepository<CookingVessel> cookingVesselRepository,
            ICategoriesService categoriesService,
            IIngredientsService ingredientsService,
            INutritionsService nutritionsService)
        {
            this.recipesRepository = recipesRepository;
            this.cookingVesselRepository = cookingVesselRepository;
            this.categoriesService = categoriesService;
            this.ingredientsService = ingredientsService;
            this.nutritionsService = nutritionsService;
        }

        public INutritionsService NutritionsService { get; }

        public async Task<string> CreateAsync(string userId, RecipeInputModel inputModel)
        {
            var recipe = new Recipe
            {
                Name = inputModel.Name,
                Preparation = inputModel.Preparation,
                CreatorId = userId,
            };

            await this.recipesRepository.AddAsync(recipe);
            await this.recipesRepository.SaveChangesAsync();

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
