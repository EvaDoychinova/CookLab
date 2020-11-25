namespace CookLab.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CookLab.Models.InputModels.Recipes;
    using CookLab.Models.ViewModels.Recipes;

    public interface IRecipesService
    {
        Task<string> CreateAsync(string userId, RecipeInputModel inputModel, string rootPath);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<T>> GetAllByCategoryAsync<T>(int categoryId);

        Task<T> GetByIdAsync<T>(string id);

        Task<IEnumerable<T>> GetAllByCreatorAsync<T>(string userId);

        Task<IEnumerable<T>> GetAllByUserAsync<T>(string userId);

        Task EditAsync(RecipeEditViewModel viewModel, string rootPath);

        Task DeleteAsync(string id);
    }
}
