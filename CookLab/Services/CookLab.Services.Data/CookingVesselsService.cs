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
            double area = (int)inputModel.Form switch
            {
                1 => Math.PI * (inputModel.Diameter / 2) * (inputModel.Diameter / 2) ?? 0,
                2 => inputModel.SideA * inputModel.SideA ?? 0,
                3 => inputModel.SideA * inputModel.SideB ?? 0,
                4 => inputModel.Area ?? 0,
                _ => 0,
            };

            var cookingVessel = new CookingVessel
            {
                Name = (int)inputModel.Form switch
                {
                    1 => $"{inputModel.Form} {inputModel.Diameter}cm",
                    2 => $"{inputModel.Form} {inputModel.SideA}x{inputModel.SideA} cm\xB2",
                    3 => $"{inputModel.Form} {inputModel.SideA}x{inputModel.SideB} cm\xB2",
                    4 => $"{inputModel.Name} {inputModel.Area}cm\xB2",
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
                Area = area,
                Volume = area * inputModel.Height,
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
