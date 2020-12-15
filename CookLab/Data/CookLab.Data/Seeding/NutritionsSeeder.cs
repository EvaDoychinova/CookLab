namespace CookLab.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Models;

    internal class NutritionsSeeder : ISeeder
    {
        private List<Nutrition> nutritionsToAdd = new List<Nutrition>
        {
            new Nutrition
            {
                Calories = 0,
                Carbohydrates = 0,
                Proteins = 0,
                Fats = 0,
                Fibres = 0,
                IngredientId = "",
            },
        };

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Nutritions.Any(x => x.IsDeleted == false))
            {
                return;
            }

            foreach (var nutrition in this.nutritionsToAdd)
            {
                await dbContext.Nutritions.AddAsync(nutrition);
            }
        }
    }
}
