namespace CookLab.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.ServiceModels.CookingVessels;
    using CookLab.Services.Mapping;

    public class CookingVesselsService : ICookingVesselsService
    {
        private readonly IRepository<CookingVessel> cookingVesselRepository;

        public CookingVesselsService(IRepository<CookingVessel> cookingVesselRepository)
        {
            this.cookingVesselRepository = cookingVesselRepository;
        }

        public async Task<int> CreateAsync(CookingVesselInputServiceModel inputModel)
        {
            double volume = (int)inputModel.Form switch
            {
                1 => Math.PI * (inputModel.VesselDimension.Diameter / 2) * (inputModel.VesselDimension.Diameter / 2) / 2,
                2 => inputModel.VesselDimension.SideA * inputModel.VesselDimension.SideA,
                3 => inputModel.VesselDimension.SideA * inputModel.VesselDimension.SideB,
                4 => inputModel.Volume,
                _ => 0,
            };

            var cookingVessel = new CookingVessel
            {
                Form = inputModel.Form,
                VesselDimension = new VesselDimension
                {
                    Diameter = inputModel.VesselDimension.Diameter,
                    SideA = inputModel.VesselDimension.SideA,
                    SideB = inputModel.VesselDimension.SideB,
                    Height = inputModel.VesselDimension.Height,
                },
                Volume = volume,
            };

            await this.cookingVesselRepository.AddAsync(cookingVessel);
            await this.cookingVesselRepository.SaveChangesAsync();

            return cookingVessel.Id;
        }

        public ICollection<T> GetAll<T>()
        {
            var cookingVessels = this.cookingVesselRepository.All()
               .To<T>()
               .ToList();

            return cookingVessels;
        }
    }
}
