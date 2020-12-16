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
                Name = "Water",
                VolumeInMlPer100Grams = 100,
            },
            new Ingredient
            {
                Name = "Sugar",
                VolumeInMlPer100Grams = 123.48,
            },
            new Ingredient
            {
                Name = "Sugar brown",
                VolumeInMlPer100Grams = 117.65,
            },
            new Ingredient
            {
                Name = "Salt",
                VolumeInMlPer100Grams = 98.04,
            },
            new Ingredient
            {
                Name = "Powdered sugar",
                VolumeInMlPer100Grams = 181.82,
            },
            new Ingredient
            {
                Name = "Flour white wheat",
                VolumeInMlPer100Grams = 238.1,
            },
            new Ingredient
            {
                Name = "Flour whole grain wheat",
                VolumeInMlPer100Grams = 181.82,
            },
            new Ingredient
            {
                Name = "Flour whole grain rye",
                VolumeInMlPer100Grams = 263.16,
            },
            new Ingredient
            {
                Name = "Flour corn",
                VolumeInMlPer100Grams = 156.25,
            },
            new Ingredient
            {
                Name = "Flour rice",
                VolumeInMlPer100Grams = 156.25,
            },
            new Ingredient
            {
                Name = "Milk",
                VolumeInMlPer100Grams = 97,
            },
            new Ingredient
            {
                Name = "Yogurt",
                VolumeInMlPer100Grams = 97,
            },
            new Ingredient
            {
                Name = "Condensed milk",
                VolumeInMlPer100Grams = 107.53,
            },
            new Ingredient
            {
                Name = "Butter",
                VolumeInMlPer100Grams = 103.09,
            },
            new Ingredient
            {
                Name = "Lentils",
                VolumeInMlPer100Grams = 117.65,
            },
            new Ingredient
            {
                Name = "Beans",
                VolumeInMlPer100Grams = 117.65,
            },
            new Ingredient
            {
                Name = "Rice",
                VolumeInMlPer100Grams = 112.36,
            },
            new Ingredient
            {
                Name = "Semolina",
                VolumeInMlPer100Grams = 135.14,
            },
            new Ingredient
            {
                Name = "Honey",
                VolumeInMlPer100Grams = 69.44,
            },
            new Ingredient
            {
                Name = "Baking powder",
                VolumeInMlPer100Grams = 131.58,
            },
            new Ingredient
            {
                Name = "Baking soda",
                VolumeInMlPer100Grams = 114.94,
            },
            new Ingredient
            {
                Name = "Eggs",
                VolumeInMlPer100Grams = 103.09,
            },
            new Ingredient
            {
                Name = "Egg whites",
                VolumeInMlPer100Grams = 107.53,
            },
            new Ingredient
            {
                Name = "Egg yolks",
                VolumeInMlPer100Grams = 87.72,
            },
            new Ingredient
            {
                Name = "Bananas",
                VolumeInMlPer100Grams = 78.86,
            },
            new Ingredient
            {
                Name = "Buckwheat",
                VolumeInMlPer100Grams = 138.89,
            },
            new Ingredient
            {
                Name = "Cinnamon",
                VolumeInMlPer100Grams = 196.08,
            },
            new Ingredient
            {
                Name = "Coffee",
                VolumeInMlPer100Grams = 263.16,
            },
            new Ingredient
            {
                Name = "Raisins",
                VolumeInMlPer100Grams = 156.25,
            },
            new Ingredient
            {
                Name = "Starch",
                VolumeInMlPer100Grams = 131.58,
            },
            new Ingredient
            {
                Name = "Gelatin",
                VolumeInMlPer100Grams = 107.53,
            },
            new Ingredient
            {
                Name = "Ginger",
                VolumeInMlPer100Grams = 103.09,
            },
            new Ingredient
            {
                Name = "Ginger powder",
                VolumeInMlPer100Grams = 196.08,
            },
            new Ingredient
            {
                Name = "Molasses",
                VolumeInMlPer100Grams = 67.57,
            },
            new Ingredient
            {
                Name = "Milk powder",
                VolumeInMlPer100Grams = 138.89,
            },
            new Ingredient
            {
                Name = "Olive oil",
                VolumeInMlPer100Grams = 123.46,
            },
            new Ingredient
            {
                Name = "Peanut butter",
                VolumeInMlPer100Grams = 131.58,
            },
            new Ingredient
            {
                Name = "Black pepper",
                VolumeInMlPer100Grams = 175.44,
            },
            new Ingredient
            {
                Name = "White pepper",
                VolumeInMlPer100Grams = 156.25,
            },
            new Ingredient
            {
                Name = "Poppy seed",
                VolumeInMlPer100Grams = 175.44,
            },
            new Ingredient
            {
                Name = "Potatoes",
                VolumeInMlPer100Grams = 131.58,
            },
            new Ingredient
            {
                Name = "Sesame seed",
                VolumeInMlPer100Grams = 147.06,
            },
            new Ingredient
            {
                Name = "Rice wild",
                VolumeInMlPer100Grams = 163.93,
            },
            new Ingredient
            {
                Name = "Dry yeast",
                VolumeInMlPer100Grams = 81.3,
            },
            new Ingredient
            {
                Name = "Yeast",
                VolumeInMlPer100Grams = 160.35,
            },
            new Ingredient
            {
                Name = "Cooking cream",
                VolumeInMlPer100Grams = 100,
            },
            new Ingredient
            {
                Name = "Sour cream",
                VolumeInMlPer100Grams = 95.23,
            },
            new Ingredient
            {
                Name = "Flour coconut",
                VolumeInMlPer100Grams = 211.24,
            },
            new Ingredient
            {
                Name = "White Chocolate",
                VolumeInMlPer100Grams = 139.17,
            },
            new Ingredient
            {
                Name = "Milk Chocolate",
                VolumeInMlPer100Grams = 140.83,
            },
            new Ingredient
            {
                Name = "Dark Chocolate (45÷59%)",
                VolumeInMlPer100Grams = 138.36,
            },
            new Ingredient
            {
                Name = "Dark Chocolate (60÷69%)",
                VolumeInMlPer100Grams = 137.55,
            },
            new Ingredient
            {
                Name = "Dark Chocolate (70÷85%)",
                VolumeInMlPer100Grams = 136.76,
            },
            new Ingredient
            {
                Name = "Cocoa powder",
                VolumeInMlPer100Grams = 200.50,
            },
            new Ingredient
            {
                Name = "Cocoa butter",
                VolumeInMlPer100Grams = 108.53,
            },
            new Ingredient
            {
                Name = "Carob powder",
                VolumeInMlPer100Grams = 229.70,
            },
            new Ingredient
            {
                Name = "Chia seeds",
                VolumeInMlPer100Grams = 145.35,
            },
            new Ingredient
            {
                Name = "Almond flour",
                VolumeInMlPer100Grams = 246.45,
            },
            new Ingredient
            {
                Name = "Walnut meal",
                VolumeInMlPer100Grams = 249.04,
            },
            new Ingredient
            {
                Name = "Hazelnut meal",
                VolumeInMlPer100Grams = 204.92,
            },
            new Ingredient
            {
                Name = "Almond meal",
                VolumeInMlPer100Grams = 251.69,
            },
            new Ingredient
            {
                Name = "Almonds",
                VolumeInMlPer100Grams = 165.45,
            },
            new Ingredient
            {
                Name = "Cashew",
                VolumeInMlPer100Grams = 165.56,
            },
            new Ingredient
            {
                Name = "Hazelnuts",
                VolumeInMlPer100Grams = 171.23,
            },
            new Ingredient
            {
                Name = "Peanuts",
                VolumeInMlPer100Grams = 162.05,
            },
            new Ingredient
            {
                Name = "Walnuts",
                VolumeInMlPer100Grams = 219.30,
            },
            new Ingredient
            {
                Name = "Walnuts chopped",
                VolumeInMlPer100Grams = 202.21,
            },
            new Ingredient
            {
                Name = "Coconut shredded",
                VolumeInMlPer100Grams = 254.40,
            },
            new Ingredient
            {
                Name = "Oats",
                VolumeInMlPer100Grams = 254.40,
            },
            new Ingredient
            {
                Name = "Coconut oil",
                VolumeInMlPer100Grams = 109.46,
            },
            new Ingredient
            {
                Name = "Grapeseed oil",
                VolumeInMlPer100Grams = 110.13,
            },
            new Ingredient
            {
                Name = "Sesame oil",
                VolumeInMlPer100Grams = 108.46,
            },
            new Ingredient
            {
                Name = "Sesame meal",
                VolumeInMlPer100Grams = 92.42,
            },
            new Ingredient
            {
                Name = "Cottage cheese",
                VolumeInMlPer100Grams = 105.15,
            },
            new Ingredient
            {
                Name = "Vanilla extract(powder)",
                VolumeInMlPer100Grams = 113.74,
            },
            new Ingredient
            {
                Name = "Maple syrup",
                VolumeInMlPer100Grams = 75.11,
            },
            new Ingredient
            {
                Name = "Dates",
                VolumeInMlPer100Grams = 160.95,
            },
            new Ingredient
            {
                Name = "Figs dry",
                VolumeInMlPer100Grams = 158.78,
            },
            new Ingredient
            {
                Name = "Figs",
                VolumeInMlPer100Grams = 157.72,
            },
            new Ingredient
            {
                Name = "Avocado",
                VolumeInMlPer100Grams = 157.73,
            },
            new Ingredient
            {
                Name = "Red lentils",
                VolumeInMlPer100Grams = 124.53,
            },
            new Ingredient
            {
                Name = "Apples",
                VolumeInMlPer100Grams = 200.4,
            },
            new Ingredient
            {
                Name = "Apricots",
                VolumeInMlPer100Grams = 124.53,
            },
            new Ingredient
            {
                Name = "Mushrooms",
                VolumeInMlPer100Grams = 236.41,
            },
            new Ingredient
            {
                Name = "Pasta",
                VolumeInMlPer100Grams = 236.41,
            },
            new Ingredient
            {
                Name = "Cheese white",
                VolumeInMlPer100Grams = 105.15,
            },
            new Ingredient
            {
                Name = "Cheese yellow",
                VolumeInMlPer100Grams = 105.15,
            },
            new Ingredient
            {
                Name = "Cheddar Cheese",
                VolumeInMlPer100Grams = 100.71,
            },
            new Ingredient
            {
                Name = "Flax seed",
                VolumeInMlPer100Grams = 120,
            },
            new Ingredient
            {
                Name = "Chickpeas boiled",
                VolumeInMlPer100Grams = 139.08,
            },
            new Ingredient
            {
                Name = "Carrots grated",
                VolumeInMlPer100Grams = 215.08,
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
