namespace CookLab.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CookLab.Models.InputModels.Recipes;

    public interface IRecipesService
    {
        Task<string> CreateAsync(string userId, RecipeInputModel inputModel);

        ICollection<T> GetAll<T>();

        ICollection<T> GetAllByCategory<T>(string categoryName);

        T GetById<T>(string id);
    }
}
