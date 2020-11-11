namespace CookLab.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CookLab.Models.InputModels.Ingredients;
    using CookLab.Models.ViewModels.Ingredients;

    public interface IIngredientsService
    {
        Task<string> CreateAsync(IngredientInputModel inputModel);

        Task<ICollection<T>> GetAllAsync<T>();

        Task<T> GetByIdAsync<T>(string id);

        Task EditAsync(IngredientEditViewModel viewModel);

        Task DeleteAsync(IngredientDeleteViewModel viewModel);
    }
}
