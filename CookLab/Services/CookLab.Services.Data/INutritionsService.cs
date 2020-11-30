namespace CookLab.Services.Data
{
    using System.Threading.Tasks;

    using CookLab.Models.InputModels.Nutritions;
    using CookLab.Models.ViewModels.Nutritions;

    public interface INutritionsService
    {
        Task<string> AddNutritionToIngredientAsync(string ingredientId, NutritionInputModel inputModel);

        Task CalculateNutritionForRecipeAsync(string recipeId);

        Task<T> ShowNutritionAsync<T>(string ingredientId = null, string recipeId = null);
    }
}
