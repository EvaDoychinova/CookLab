namespace CookLab.Services.Data
{
    using System.Threading.Tasks;

    using CookLab.Models.ServiceModels.Nutritions;

    public interface INutritionsService
    {
        Task<string> AddNutritionToIngredientAsync(string ingredientId, NutritionInputServiceModel inputModel);

        Task<string> CalculateNutritionForRecipeAsync(string recipeId);
    }
}
