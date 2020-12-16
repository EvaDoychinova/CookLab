namespace CookLab.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Models;

    internal class RecipesSeeder : ISeeder
    {
        private List<Recipe> recipesToAdd = new List<Recipe>
            {
                new Recipe
                {
                    Name = "",
                    CookingTime = TimeSpan.FromMinutes(0),
                    PreparationTime = TimeSpan.FromMinutes(0),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                        },
                    },
                    CookingVesselId = 0,
                    CreatorId = "",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                        },
                    },
                    Notes = "",
                    Portions = 0,
                    Preparation = "",
                },
            };

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Recipes.Any(x => x.IsDeleted == false))
            {
                return;
            }

            foreach (var recipe in this.recipesToAdd)
            {
                await dbContext.Recipes.AddAsync(recipe);
            }
        }
    }
}
