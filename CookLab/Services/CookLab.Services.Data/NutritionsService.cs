namespace CookLab.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Common;
    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.InputModels.Nutritions;
    using CookLab.Services.Mapping;

    using Microsoft.EntityFrameworkCore;

    public class NutritionsService : INutritionsService
    {
        private readonly IDeletableEntityRepository<Nutrition> nutritionRepository;
        private readonly IDeletableEntityRepository<Ingredient> ingredientRepository;
        private readonly IDeletableEntityRepository<Recipe> recipeRepository;

        public NutritionsService(
            IDeletableEntityRepository<Nutrition> nutritionRepository,
            IDeletableEntityRepository<Ingredient> ingredientRepository,
            IDeletableEntityRepository<Recipe> recipeRepository)
        {
            this.nutritionRepository = nutritionRepository;
            this.ingredientRepository = ingredientRepository;
            this.recipeRepository = recipeRepository;
        }

        public async Task<string> AddNutritionToIngredientAsync(string ingredientId, NutritionInputModel inputModel)
        {
            var nutrition = new Nutrition
            {
                Calories = inputModel.Calories,
                Carbohydrates = inputModel.Carbohydrates,
                Fats = inputModel.Fats,
                Proteins = inputModel.Proteins,
                Fibres = inputModel.Fibres,
                IngredientId = ingredientId,
            };

            await this.nutritionRepository.AddAsync(nutrition);

            var ingredient = await this.ingredientRepository.All()
                .Where(x => x.Id == ingredientId)
                .FirstOrDefaultAsync();

            ingredient.NutritionPer100Grams = nutrition;
            this.ingredientRepository.Update(ingredient);
            await this.nutritionRepository.SaveChangesAsync();
            await this.ingredientRepository.SaveChangesAsync();
            return nutrition.Id;
        }

        public async Task<string> CalculateNutritionForRecipeAsync(string recipeId)
        {
            var recipe = this.recipeRepository.All()
                .Where(x => x.Id == recipeId)
                .FirstOrDefault();

            if (recipe == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RecipeMissing, recipeId));
            }

            var nutrition = new Nutrition
            {
                Calories = this.CalculateNutritionElementPer100GramsForRecipe(recipe.Ingredients, "Calories"),
                Carbohydrates = this.CalculateNutritionElementPer100GramsForRecipe(recipe.Ingredients, "Carbohydrates"),
                Fats = this.CalculateNutritionElementPer100GramsForRecipe(recipe.Ingredients, "Fats"),
                Proteins = this.CalculateNutritionElementPer100GramsForRecipe(recipe.Ingredients, "Proteins"),
                Fibres = this.CalculateNutritionElementPer100GramsForRecipe(recipe.Ingredients, "Fibres"),
                RecipeId = recipeId,
                IngredientId = null,
            };

            recipe.NutritionPer100Grams = nutrition;
            await this.nutritionRepository.AddAsync(nutrition);
            await this.nutritionRepository.SaveChangesAsync();

            this.recipeRepository.Update(recipe);
            await this.recipeRepository.SaveChangesAsync();
            return nutrition.Id;
        }

        public async Task<T> ShowNutritionAsync<T>(string ingredientId = null, string recipeId = null)
        {
            var nutrition = await this.nutritionRepository.All()
                .Where(x => x.IngredientId == ingredientId && x.RecipeId == recipeId)
                .To<T>()
                .FirstOrDefaultAsync();

            return nutrition;
        }

        private double CalculateNutritionElementPer100GramsForRecipe(ICollection<RecipeIngredient> ingredients, string nutritionPart)
        {
            var nutritionElement = ingredients
                .Sum(x => x.WeightInGrams * (double)x.Ingredient.NutritionPer100Grams
                                                        .GetType().GetProperty(nutritionPart).GetValue(x.Ingredient.NutritionPer100Grams));

            var nutritionElementPer100Grams = nutritionElement * 100 / ingredients.Sum(x => x.WeightInGrams);

            return nutritionElementPer100Grams;
        }
    }
}
