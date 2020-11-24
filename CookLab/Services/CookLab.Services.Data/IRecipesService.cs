namespace CookLab.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CookLab.Models.InputModels.Recipes;
    using CookLab.Models.ViewModels.Recipes;

    public interface IRecipesService
    {
        Task<string> CreateAsync(string userId, RecipeInputModel inputModel, string rootPath);

        Task<ICollection<T>> GetAllAsync<T>();

        Task<ICollection<T>> GetAllByCategoryAsync<T>(int categoryId);

        Task<T> GetByIdAsync<T>(string id);

        Task<ICollection<T>> GetAllByCreatorAsync<T>(string userId);

        Task<ICollection<T>> GetAllByUserAsync<T>(string userId);

        Task EditAsync(RecipeEditViewModel viewModel);

        Task DeleteAsync(string id);
    }
}
