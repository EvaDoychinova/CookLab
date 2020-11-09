namespace CookLab.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.InputModels.Nutritions;

    public class NutritionsService : INutritionsService
    {
        private readonly IDeletableEntityRepository<Nutrition> nutritionRepository;
        private readonly IDeletableEntityRepository<Recipe> recipeRepository;

        public NutritionsService(
            IDeletableEntityRepository<Nutrition> nutritionRepository,
            IDeletableEntityRepository<Recipe> recipeRepository)
        {
            this.nutritionRepository = nutritionRepository;
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
            await this.nutritionRepository.SaveChangesAsync();

            return nutrition.Id;
        }

        public async Task<string> CalculateNutritionForRecipeAsync(string recipeId)
        {
            var recipe = this.recipeRepository.All()
                .Where(x => x.Id == recipeId)
                .FirstOrDefault();

            var nutrition = new Nutrition
            {
                Calories = this.CalculateNutritionElementPer100GramsForRecipe(recipe.Ingredients, "Calories"),
                Carbohydrates = this.CalculateNutritionElementPer100GramsForRecipe(recipe.Ingredients, "Carbohydrates"),
                Fats = this.CalculateNutritionElementPer100GramsForRecipe(recipe.Ingredients, "Fats"),
                Proteins = this.CalculateNutritionElementPer100GramsForRecipe(recipe.Ingredients, "Proteins"),
                Fibres = this.CalculateNutritionElementPer100GramsForRecipe(recipe.Ingredients, "Fibres"),
                RecipeId = recipeId,
            };

            await this.nutritionRepository.AddAsync(nutrition);
            await this.nutritionRepository.SaveChangesAsync();

            return nutrition.Id;
        }

        private double CalculateNutritionElementPer100GramsForRecipe(ICollection<RecipeIngredient> ingredients, string nutritionPart)
        {
            var nutritionElement = ingredients
                .Sum(x => x.WeightInGrams * (double)x.Ingredient.NutritionPer100Grams
                                                        .GetType().GetProperty(nutritionPart).GetValue(x.Ingredient.NutritionPer100Grams));

            var nutritionElementPer100Grams = nutritionElement / ingredients.Sum(x => x.WeightInGrams);

            return nutritionElementPer100Grams;
        }
    }
}
