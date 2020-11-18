namespace CookLab.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CookLab.Models.InputModels.Ingredients;
    using CookLab.Models.ViewModels.Ingredients;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface IIngredientsService
    {
        Task<string> CreateAsync(IngredientInputModel inputModel);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<T> GetByIdAsync<T>(string id);

        Task EditAsync(IngredientEditViewModel viewModel);

        Task DeleteAsync(string id);

        Task<IEnumerable<SelectListItem>> GetAllIngredientsForRecipeAsync();
    }
}
