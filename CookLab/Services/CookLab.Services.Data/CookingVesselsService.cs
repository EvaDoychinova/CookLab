namespace CookLab.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Common;
    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.InputModels.CookingVessel;
    using CookLab.Services.Mapping;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class CookingVesselsService : ICookingVesselsService
    {
        private readonly IDeletableEntityRepository<CookingVessel> cookingVesselRepository;
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;

        public CookingVesselsService(
            IDeletableEntityRepository<CookingVessel> cookingVesselRepository,
            IDeletableEntityRepository<Recipe> recipesRepository)
        {
            this.cookingVesselRepository = cookingVesselRepository;
            this.recipesRepository = recipesRepository;
        }

        public async Task<int> CreateAsync(CookingVesselInputModel inputModel)
        {
            double area = (int)inputModel.Form switch
            {
                1 => Math.PI * (inputModel.Diameter / 2) * (inputModel.Diameter / 2) ?? 0,
                2 => inputModel.SideA * inputModel.SideA ?? 0,
                3 => inputModel.SideA * inputModel.SideB ?? 0,
                4 => inputModel.Area ?? 0,
                5 => Math.PI * (inputModel.Diameter / 2) * (inputModel.Diameter / 2) * inputModel.FormsCount ?? 0,
                _ => 0,
            };

            string name = (int)inputModel.Form switch
            {
                1 => $"{inputModel.Form} {inputModel.Diameter}cm/{inputModel.Height}cm",
                2 => $"{inputModel.Form} {inputModel.SideA}x{inputModel.SideA}cm\xB2/{inputModel.Height}cm",
                3 => $"{inputModel.Form} {inputModel.SideA}x{inputModel.SideB}cm\xB2/{inputModel.Height}cm",
                4 => $"{inputModel.Name} {inputModel.Area}cm\xB2/{inputModel.Height}cm",
                5 => $"{inputModel.FormsCount}x{inputModel.Form} {inputModel.Diameter}cm/{inputModel.Height}cm",
                _ => null,
            };

            if (this.cookingVesselRepository.All().Any(x => x.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.CookingVesselAlreadyExists, name);
            }

            var cookingVessel = new CookingVessel
            {
                Name = name,
                Form = inputModel.Form,
                FormsCount = inputModel.FormsCount,
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

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var cookingVessels = await this.cookingVesselRepository.AllAsNoTracking()
               .OrderBy(x => x.Name)
               .To<T>()
               .ToListAsync();

            return cookingVessels;
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var cookingVessel = await this.cookingVesselRepository.AllAsNoTracking()
               .Where(x => x.Id == id)
               .To<T>()
               .FirstOrDefaultAsync();

            return cookingVessel;
        }

        public async Task DeleteAsync(int id)
        {
            var cookingVessel = this.cookingVesselRepository.All()
                .FirstOrDefault(x => x.Id == id);

            if (cookingVessel == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CookingVesselMissing, id));
            }

            var alternativeCookingVessel = this.cookingVesselRepository.All()
                .FirstOrDefault(x =>
                Math.Round(x.Area, 0) == Math.Round(cookingVessel.Area, 0) &&
                x.Height >= cookingVessel.Height &&
                x.Id != cookingVessel.Id);

            if (alternativeCookingVessel == null)
            {
                alternativeCookingVessel = this.cookingVesselRepository.All()
                .FirstOrDefault(x =>
                Math.Round(x.Area / Math.Pow(10, Math.Abs(-1)), 0) * Math.Pow(10, Math.Abs(-1)) == Math.Round(cookingVessel.Area / Math.Pow(10, Math.Abs(-1)), 0) * Math.Pow(10, Math.Abs(-1)) &&
                x.Height >= cookingVessel.Height &&
                x.Id != cookingVessel.Id);
            }

            if (alternativeCookingVessel == null)
            {
                alternativeCookingVessel = this.cookingVesselRepository.All()
                .FirstOrDefault(x =>
                Math.Round(x.Area / Math.Pow(10, Math.Abs(-1)), 0) * Math.Pow(10, Math.Abs(-1)) == Math.Round(cookingVessel.Area / Math.Pow(10, Math.Abs(-1)), 0) * Math.Pow(10, Math.Abs(-1)) &&
                x.Height >= cookingVessel.Height &&
                x.Id != cookingVessel.Id);
            }

            var recipes = await this.recipesRepository.All()
                            .Where(x => x.CookingVesselId == cookingVessel.Id)
                            .ToListAsync();

            foreach (var recipe in recipes)
            {
                if (alternativeCookingVessel != null)
                {
                    recipe.CookingVessel = alternativeCookingVessel;
                    recipe.CookingVesselId = alternativeCookingVessel.Id;
                    recipe.ModifiedOn = DateTime.UtcNow;
                    this.recipesRepository.Update(recipe);
                }
            }

            this.cookingVesselRepository.Delete(cookingVessel);
            await this.cookingVesselRepository.SaveChangesAsync();
            await this.recipesRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetAllCookingVesselsSelectListAsync()
        {
            var cookingVessels = await this.cookingVesselRepository.AllAsNoTracking()
                    .OrderBy(x => x.Name)
                    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                    .ToListAsync();

            return cookingVessels;
        }
    }
}
