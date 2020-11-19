namespace CookLab.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Common;
    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.InputModels.Ingredients;
    using CookLab.Models.ViewModels.Ingredients;
    using CookLab.Services.Mapping;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class IngredientsService : IIngredientsService
    {
        private readonly IDeletableEntityRepository<Ingredient> ingredientRepository;
        private readonly IDeletableEntityRepository<Nutrition> nutritionsRepository;
        private readonly INutritionsService nutritionsService;

        public IngredientsService(
            IDeletableEntityRepository<Ingredient> ingredientRepository,
            IDeletableEntityRepository<Nutrition> nutritionsRepository,
            INutritionsService nutritionsService)
        {
            this.ingredientRepository = ingredientRepository;
            this.nutritionsRepository = nutritionsRepository;
            this.nutritionsService = nutritionsService;
        }

        public async Task<string> CreateAsync(IngredientInputModel inputModel)
        {
            if (this.ingredientRepository.All().Any(x => x.Name == inputModel.Name))
            {
                throw new ArgumentException(ExceptionMessages.IngredientAlreadyExists, inputModel.Name);
            }

            var ingredient = new Ingredient
            {
                Name = inputModel.Name,
                VolumeInMlPer100Grams = inputModel.VolumeInMlPer100Grams,
            };

            await this.ingredientRepository.AddAsync(ingredient);
            await this.ingredientRepository.SaveChangesAsync();

            return ingredient.Id;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var ingredients = await this.ingredientRepository.All()
                .OrderBy(x => x.Name)
                .To<T>()
                .ToListAsync();

            return ingredients;
        }

        public async Task<T> GetByIdAsync<T>(string id)
        {
            var ingredient = await this.ingredientRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return ingredient;
        }

        public async Task EditAsync(IngredientEditViewModel viewModel)
        {
            var ingredient = await this.ingredientRepository.All()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (ingredient == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.IngredientMissing, viewModel.Id));
            }

            if (this.ingredientRepository.All().Any(x => x.Name == viewModel.Name && x.Id != viewModel.Id))
            {
                throw new ArgumentException(ExceptionMessages.IngredientAlreadyExists, viewModel.Name);
            }

            ingredient.Name = viewModel.Name;
            ingredient.VolumeInMlPer100Grams = viewModel.VolumeInMlPer100Grams;

            var nutrition = ingredient.NutritionPer100Grams;

            if (nutrition != null)
            {
                nutrition.Calories = viewModel.NutritionPer100Grams.Calories;
                nutrition.Carbohydrates = viewModel.NutritionPer100Grams.Carbohydrates;
                nutrition.Fats = viewModel.NutritionPer100Grams.Fats;
                nutrition.Proteins = viewModel.NutritionPer100Grams.Proteins;
                nutrition.Fibres = viewModel.NutritionPer100Grams.Fibres;
                nutrition.ModifiedOn = DateTime.UtcNow;
                this.nutritionsRepository.Update(nutrition);
            }

            ingredient.ModifiedOn = DateTime.UtcNow;
            this.ingredientRepository.Update(ingredient);
            await this.ingredientRepository.SaveChangesAsync();
            await this.nutritionsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var ingredient = await this.ingredientRepository.All()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (ingredient == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.IngredientMissing, id));
            }

            ingredient.IsDeleted = true;
            ingredient.DeletedOn = DateTime.UtcNow;

            var nutrition = ingredient.NutritionPer100Grams;

            if (nutrition != null)
            {
                nutrition.IsDeleted = true;
                nutrition.DeletedOn = DateTime.UtcNow;

                this.nutritionsRepository.Update(nutrition);
            }

            this.ingredientRepository.Update(ingredient);
            await this.ingredientRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetAllIngredientsForRecipeAsync()
        {
            var ingredientsViewModel = await this.GetAllAsync<IngredientRecipeViewModel>();

            var inredients = ingredientsViewModel
                    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                    .ToList();

            return inredients;
        }
    }
}
