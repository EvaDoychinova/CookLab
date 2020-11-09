namespace CookLab.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.InputModels.Recipes;
    using CookLab.Services.Mapping;

    public class RecipesService : IRecipesService
    {
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;
        private readonly IRepository<CookingVessel> cookingVesselRepository;
        private readonly IRepository<VesselDimension> vesselDimensionsRepository;
        private readonly ICategoriesService categoriesService;
        private readonly IIngredientsService ingredientsService;
        private readonly INutritionsService nutritionsService;

        public RecipesService(
            IDeletableEntityRepository<Recipe> recipesRepository,
            IRepository<CookingVessel> cookingVesselRepository,
            IRepository<VesselDimension> vesselDimensionsRepository,
            ICategoriesService categoriesService,
            IIngredientsService ingredientsService,
            INutritionsService nutritionsService)
        {
            this.recipesRepository = recipesRepository;
            this.cookingVesselRepository = cookingVesselRepository;
            this.vesselDimensionsRepository = vesselDimensionsRepository;
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

        public ICollection<T> GetAll<T>()
        {
            var recipes = this.recipesRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .To<T>()
                .ToList();

            return recipes;
        }

        public ICollection<T> GetAllByCategory<T>(string categoryName)
        {
            var recipes = this.recipesRepository.All()
                .Where(x => x.Categories
                             .Any(y => y.Category.Name == categoryName))
                .To<T>()
                .ToList();

            return recipes;
        }

        public T GetById<T>(string id)
        {
            var recipe = this.recipesRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return recipe;
        }
    }
}
