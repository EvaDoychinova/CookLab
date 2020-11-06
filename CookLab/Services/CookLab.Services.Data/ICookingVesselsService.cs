namespace CookLab.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CookLab.Models.ServiceModels.CookingVessels;

    public interface ICookingVesselsService
    {
        Task<int> CreateAsync(CookingVesselInputServiceModel inputModel);

        ICollection<T> GetAll<T>();
    }
}
