namespace CookLab.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CookLab.Models.InputModels.CookingVessel;

    public interface ICookingVesselsService
    {
        Task<int> CreateAsync(CookingVesselInputModel inputModel);

        ICollection<T> GetAll<T>();
    }
}
