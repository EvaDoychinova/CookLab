namespace CookLab.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        Task<int> CreateAsync(string name, string imageUrl);

        ICollection<T> GetAll<T>();

        T GetById<T>(int id);
    }
}
