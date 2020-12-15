namespace CookLab.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Models;

    internal class IngredientsSeeder : ISeeder
    {
        private List<Ingredient> ingredientsToAdd = new List<Ingredient>
        {
            new Ingredient
            {
                Name = "",
                VolumeInMlPer100Grams = 0,
            },
        };

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Ingredients.Any(x => x.IsDeleted == false))
            {
                return;
            }

            foreach (var ingredient in this.ingredientsToAdd)
            {
                await dbContext.Ingredients.AddAsync(ingredient);
            }
        }
    }
}
