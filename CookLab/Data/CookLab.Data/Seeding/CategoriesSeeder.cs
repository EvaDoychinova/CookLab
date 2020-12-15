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
                Name = "Desserts",
                ImageUrl = "/assets/img/categories/desserts.jpg",
            },
            new Category
            {
                Name = "Cakes",
                ImageUrl = "/assets/img/categories/cakes.jpg",
            },
            new Category
            {
                Name = "Cookies",
                ImageUrl = "/assets/img/categories/cookies.jpg",
            },
            new Category
            {
                Name = "Salads",
                ImageUrl = "/assets/img/categories/salads.jpg",
            },
            new Category
            {
                Name = "Soups",
                ImageUrl = "/assets/img/categories/soups.jpg",
            },
            new Category
            {
                Name = "Fish",
                ImageUrl = "/assets/img/categories/fish.jpg",
            },
            new Category
            {
                Name = "Meat",
                ImageUrl = "/assets/img/categories/meat.jpg",
            },
            new Category
            {
                Name = "Vegetarian",
                ImageUrl = "/assets/img/categories/vegetarian.jpg",
            },
            new Category
            {
                Name = "Fasting",
                ImageUrl = "/assets/img/categories/fasting.jpg",
            },
            new Category
            {
                Name = "Vegan",
                ImageUrl = "/assets/img/categories/vegan.jpg",
            },
            new Category
            {
                Name = "Main dishes",
                ImageUrl = "/assets/img/categories/main-dishes.jpg",
            },
            new Category
            {
                Name = "Dips",
                ImageUrl = "/assets/img/categories/dips.jpg",
            },
            new Category
            {
                Name = "Apetizers",
                ImageUrl = "/assets/img/categories/apetizers.jpg",
            },
            new Category
            {
                Name = "Pasta",
                ImageUrl = "/assets/img/categories/pasta.jpg",
            },
            new Category
            {
                Name = "Pizza",
                ImageUrl = "/assets/img/categories/pizza.jpg",
            },
            new Category
            {
                Name = "Bread",
                ImageUrl = "/assets/img/categories/bread.jpg",
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
