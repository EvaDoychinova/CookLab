namespace CookLab.Services.Data
{
    using System.Threading.Tasks;

    public interface IUserRecipesService
    {
        Task AddRecipeToUserListAsync(string userId, string recipeId);

        Task RemoveRecipeFromUserListAsync(string userId, string recipeId);

        int GetUsersForRecipe(string recipeId);
    }
}
