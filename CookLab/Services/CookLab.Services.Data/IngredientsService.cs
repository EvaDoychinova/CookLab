namespace CookLab.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class IngredientsService : IIngredientsService
    {
        private readonly IDeletableEntityRepository<Ingredient> ingredientRepository;

        public IngredientsService(IDeletableEntityRepository<Ingredient> ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }

        public async Task<string> CreateAsync(string name, double volumeInMlPer100Grams)
        {
            var ingredient = new Ingredient
            {
                Name = name,
                VolumeInMlPer100Grams = volumeInMlPer100Grams,
            };

            await this.ingredientRepository.AddAsync(ingredient);
            await this.ingredientRepository.SaveChangesAsync();

            return ingredient.Id;
        }

        public ICollection<T> GetAll<T>()
        {
            var ingredients = this.ingredientRepository.All()
                .OrderBy(x => x.Name)
                .To<T>()
                .ToList();

            return ingredients;
        }

        public T GetById<T>(string id)
        {
            var ingredient = this.ingredientRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return ingredient;
        }
    }
}
