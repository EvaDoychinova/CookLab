namespace CookLab.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IIngredientsService
    {
        Task<string> CreateAsync(string name, double volumeInMlPer100Grams);

        T GetById<T>(string id);

        ICollection<T> GetAll<T>();
    }
}
