namespace CookLab.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.InputModels.CookingVessel;
    using CookLab.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class CookingVesselsService : ICookingVesselsService
    {
        private readonly IRepository<CookingVessel> cookingVesselRepository;

        public CookingVesselsService(IRepository<CookingVessel> cookingVesselRepository)
        {
            this.cookingVesselRepository = cookingVesselRepository;
        }

        public async Task<int> CreateAsync(CookingVesselInputModel inputModel)
        {
            double volume = (int)inputModel.Form switch
            {
                1 => Math.PI * (inputModel.Diameter / 2) * (inputModel.Diameter / 2),
                2 => inputModel.SideA * inputModel.SideA,
                3 => inputModel.SideA * inputModel.SideB,
                4 => inputModel.Volume,
                _ => 0,
            };

            var cookingVessel = new CookingVessel
            {
                Name = (int)inputModel.Form switch
                {
                    1 => $"{inputModel.Form.ToString()} {inputModel.Diameter}cm",
                    2 => $"{inputModel.Form.ToString()} {inputModel.SideA}x{inputModel.SideA} cm\xB2",
                    3 => $"{inputModel.Form.ToString()} {inputModel.SideA}x{inputModel.SideB} cm\xB2",
                    4 => $"{inputModel.Name} {inputModel.Volume}cm\xB3",
                    _ => null,
                },
                Form = inputModel.Form,
                Diameter = (int)inputModel.Form switch
                {
                    1 => inputModel.Diameter,
                    _ => null,
                },
                SideA = (int)inputModel.Form switch
                {
                    2 => inputModel.SideA,
                    3 => inputModel.SideA,
                    _ => null,
                },
                SideB = (int)inputModel.Form switch
                {
                    3 => inputModel.SideB,
                    _ => null,
                },
                Height = inputModel.Height,
                Volume = volume,
            };

            await this.cookingVesselRepository.AddAsync(cookingVessel);
            await this.cookingVesselRepository.SaveChangesAsync();

            return cookingVessel.Id;
        }

        public async Task<ICollection<T>> GetAllAsync<T>()
        {
            var cookingVessels = await this.cookingVesselRepository.All()
               .To<T>()
               .ToListAsync();

            return cookingVessels;
        }
    }
}
