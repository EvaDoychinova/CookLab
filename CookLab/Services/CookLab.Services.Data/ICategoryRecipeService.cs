namespace CookLab.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryRecipeService
    {
        Task<IList<int>> GetAllCategoriesForRecipeAsync(string recipeId);
    }
}
