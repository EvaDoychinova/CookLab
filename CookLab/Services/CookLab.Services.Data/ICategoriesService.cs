namespace CookLab.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CookLab.Models.ViewModels.Categories;

    public interface ICategoriesService
    {
        Task<int> CreateAsync(string name, string imageUrl);

        Task<ICollection<T>> GetAllAsync<T>();

        Task<T> GetByIdAsync<T>(int id);

        Task EditAsync(CategoryViewModel viewModel);

        Task DeleteAsync(int id);
    }
}
