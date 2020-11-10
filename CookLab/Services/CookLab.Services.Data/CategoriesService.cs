namespace CookLab.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    using static CookLab.Common.ExceptionMessages;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public async Task<int> CreateAsync(string name, string imageUrl)
        {
            if (this.categoriesRepository.All().Any(x => x.Name == name))
            {
                throw new ArgumentException(CategoryAlreadyExists, name);
            }

            var category = new Category
            {
                Name = name,
                ImageUrl = imageUrl,
            };

            await this.categoriesRepository.AddAsync(category);
            await this.categoriesRepository.SaveChangesAsync();

            return category.Id;
        }

        public ICollection<T> GetAll<T>()
        {
            var categories = this.categoriesRepository.All()
                .OrderByDescending(x => x.Recipes.Count)
                .To<T>()
                .ToList();

            return categories;
        }

        public T GetById<T>(int id)
        {
            var category = this.categoriesRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return category;
        }
    }
}
