namespace CookLab.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CookLab.Models.ViewModels.Ingredients;

    public interface IIngredientsService
    {
        Task<string> CreateAsync(string name, double volumeInMlPer100Grams);

        Task<ICollection<T>> GetAllAsync<T>();

        Task<T> GetByIdAsync<T>(string id);

        Task EditAsync(IngredientViewModel viewModel);

        Task DeleteAsync(string id);
    }
}
