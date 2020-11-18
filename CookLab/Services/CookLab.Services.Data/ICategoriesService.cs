namespace CookLab.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CookLab.Models.InputModels.Categories;
    using CookLab.Models.ViewModels.Categories;

    public interface ICategoriesService
    {
        Task<int> CreateAsync(CategoryInputModel inputModel, string rootPath);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<T> GetByIdAsync<T>(int id);

        Task EditAsync(CategoryEditViewModel viewModel, string rootPath);

        Task DeleteAsync(int id);
    }
}
