namespace CookLab.Services.Data
{
    using System.Threading.Tasks;

    using CookLab.Models.InputModels.Nutritions;

    public interface INutritionsService
    {
        Task<string> AddNutritionToIngredientAsync(string ingredientId, NutritionInputModel inputModel);

        Task<string> CalculateNutritionForRecipeAsync(string recipeId);
    }
}
