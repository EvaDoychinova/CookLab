namespace CookLab.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Common;
    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.ViewModels.Categories;
    using CookLab.Services.Mapping;

    using Microsoft.EntityFrameworkCore;

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
                throw new ArgumentException(ExceptionMessages.CategoryAlreadyExists, name);
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

        public async Task<ICollection<T>> GetAllAsync<T>()
        {
            var categories = await this.categoriesRepository.All()
                .OrderByDescending(x => x.Recipes.Count)
                .To<T>()
                .ToListAsync();

            return categories;
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var category = await this.categoriesRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return category;
        }

        public async Task EditAsync(CategoryViewModel viewModel)
        {
            var category = await this.categoriesRepository.All()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (category == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CategoryMissing, viewModel.Id));
            }

            category.Name = viewModel.Name;
            category.ImageUrl = viewModel.ImageUrl;
            category.ModifiedOn = DateTime.UtcNow;
            this.categoriesRepository.Update(category);
            await this.categoriesRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await this.GetByIdAsync<Category>(id);

            if (category == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CategoryMissing, id));
            }

            category.IsDeleted = true;
            category.DeletedOn = DateTime.UtcNow;
            this.categoriesRepository.Update(category);
            await this.categoriesRepository.SaveChangesAsync();
        }
    }
}
