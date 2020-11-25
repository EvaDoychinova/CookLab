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
    using CookLab.Models.ViewModels.CookingVessels;
    using CookLab.Services.Mapping;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class CookingVesselsService : ICookingVesselsService
    {
        private readonly IRepository<CookingVessel> cookingVesselRepository;
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;

        public CookingVesselsService(
            IRepository<CookingVessel> cookingVesselRepository,
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
                _ => 0,
            };

            string name = (int)inputModel.Form switch
            {
                1 => $"{inputModel.Form} {inputModel.Diameter}cm",
                2 => $"{inputModel.Form} {inputModel.SideA}x{inputModel.SideA} cm\xB2",
                3 => $"{inputModel.Form} {inputModel.SideA}x{inputModel.SideB} cm\xB2",
                4 => $"{inputModel.Name} {inputModel.Area}cm\xB2",
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
                .FirstOrDefault(x => Math.Round(x.Area, 0) == Math.Round(cookingVessel.Area, 0));

            if (alternativeCookingVessel == null)
            {
                alternativeCookingVessel = this.cookingVesselRepository.All()
                .FirstOrDefault(x => Math.Round(x.Area, -1) == Math.Round(cookingVessel.Area, -1));
            }

            if (alternativeCookingVessel == null)
            {
                alternativeCookingVessel = this.cookingVesselRepository.All()
                .FirstOrDefault(x => Math.Round(x.Area, -2) == Math.Round(cookingVessel.Area, -2));
            }

            var recipes = cookingVessel.Recipes.ToList();

            foreach (var recipe in recipes)
            {
                recipe.CookingVessel = alternativeCookingVessel;
                recipe.CookingVesselId = alternativeCookingVessel.Id;
                this.recipesRepository.Update(recipe);
            }

            this.cookingVesselRepository.Delete(cookingVessel);
            await this.cookingVesselRepository.SaveChangesAsync();
            await this.recipesRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetAllCookingVesselsForRecipeAsync()
        {
            var cookingVesselsViewModel = await this.GetAllAsync<CookingVesselRecipeViewModel>();

            var cookingVessels = cookingVesselsViewModel
                    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                    .ToList();

            return cookingVessels;
        }
    }
}
