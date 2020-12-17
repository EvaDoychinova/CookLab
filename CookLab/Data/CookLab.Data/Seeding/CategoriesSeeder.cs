namespace CookLab.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Models;

    internal class CategoriesSeeder : ISeeder
    {
        private List<Category> categoriesToAdd = new List<Category>
        {
            new Category
            {
                Id = 1,
                Name = "Desserts",
                ImageUrl = "/assets/img/categories/desserts.jpg",
            },
            new Category
            {
                Id = 2,
                Name = "Cakes",
                ImageUrl = "/assets/img/categories/cakes.jpg",
            },
            new Category
            {
                Id = 3,
                Name = "Cookies",
                ImageUrl = "/assets/img/categories/cookies.jpg",
            },
            new Category
            {
                Id = 4,
                Name = "Salads",
                ImageUrl = "/assets/img/categories/salads.jpg",
            },
            new Category
            {
                Id = 5,
                Name = "Soups",
                ImageUrl = "/assets/img/categories/soups.jpg",
            },
            new Category
            {
                Id = 6,
                Name = "Fish",
                ImageUrl = "/assets/img/categories/fish.jpg",
            },
            new Category
            {
                Id = 7,
                Name = "Meat",
                ImageUrl = "/assets/img/categories/meat.jpg",
            },
            new Category
            {
                Id = 8,
                Name = "Vegetarian",
                ImageUrl = "/assets/img/categories/vegetarian.jpg",
            },
            new Category
            {
                Id = 9,
                Name = "Fasting",
                ImageUrl = "/assets/img/categories/fasting.jpg",
            },
            new Category
            {
                Id = 10,
                Name = "Vegan",
                ImageUrl = "/assets/img/categories/vegan.jpg",
            },
            new Category
            {
                Id = 11,
                Name = "Main dishes",
                ImageUrl = "/assets/img/categories/main-dishes.jpg",
            },
            new Category
            {
                Id = 12,
                Name = "Dips",
                ImageUrl = "/assets/img/categories/dips.jpg",
            },
            new Category
            {
                Id = 13,
                Name = "Apetizers",
                ImageUrl = "/assets/img/categories/apetizers.jpg",
            },
            new Category
            {
                Id = 14,
                Name = "Pasta",
                ImageUrl = "/assets/img/categories/pasta.jpg",
            },
            new Category
            {
                Id = 15,
                Name = "Pizza",
                ImageUrl = "/assets/img/categories/pizza.jpg",
            },
            new Category
            {
                Id = 16,
                Name = "Bread",
                ImageUrl = "/assets/img/categories/bread.jpg",
            },
            new Category
            {
                Id = 17,
                Name = "Chocolates",
                ImageUrl = "/assets/img/categories/chocolates.jpg",
            },
            new Category
            {
                Id = 18,
                Name = "Breakfasts",
                ImageUrl = "/assets/img/categories/breakfasts.jpg",
            },
        };

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any(x => x.IsDeleted == false))
            {
                return;
            }

            foreach (var category in this.categoriesToAdd)
            {
                await dbContext.Categories.AddAsync(category);
            }
        }
    }
}
