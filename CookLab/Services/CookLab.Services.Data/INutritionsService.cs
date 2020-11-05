namespace CookLab.Services.Data
{
    using System.Threading.Tasks;

    using CookLab.Models.ServiceModels.Nutritions;

    public interface INutritionsService
    {
        Task AddNutritionToIngredientAsync(string ingredientId, NutritionInputServiceModel inputModel);

        Task CalculateNutritionForRecipeAsync(string recipeId);
    }
}
