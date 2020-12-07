namespace CookLab.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryRecipesService
    {
        Task<IList<int>> GetAllCategoriesForRecipeAsync(string recipeId);
    }
}
