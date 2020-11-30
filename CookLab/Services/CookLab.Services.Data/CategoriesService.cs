namespace CookLab.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Common;
    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.InputModels.Categories;
    using CookLab.Models.ViewModels.Categories;
    using CookLab.Services.Mapping;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IDeletableEntityRepository<CategoryRecipe> recipeCategoriesRepository;

        public CategoriesService(
            IDeletableEntityRepository<Category> categoriesRepository,
            IDeletableEntityRepository<CategoryRecipe> recipeCategoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
            this.recipeCategoriesRepository = recipeCategoriesRepository;
        }

        public async Task<int> CreateAsync(CategoryInputModel inputModel, string rootPath)
        {
            if (this.categoriesRepository.All().Any(x => x.Name == inputModel.Name))
            {
                throw new ArgumentException(ExceptionMessages.CategoryAlreadyExists, inputModel.Name);
            }

            var imageName = inputModel.Name.ToLower().Replace(" ", "-");
            string imagePath = rootPath + $"/assets/img/categories/{imageName}.jpg";

            using (FileStream stream = new FileStream(imagePath, FileMode.Create))
            {
                await inputModel.Image.CopyToAsync(stream);
            }

            var imageUrl = $"assets/img/categories/{imageName}.jpg";

            var category = new Category
            {
                Name = inputModel.Name,
                ImageUrl = imageUrl,
            };

            await this.categoriesRepository.AddAsync(category);
            await this.categoriesRepository.SaveChangesAsync();

            return category.Id;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var categories = await this.categoriesRepository.AllAsNoTracking()
                .OrderBy(x => x.Name)
                .To<T>()
                .ToListAsync();

            return categories;
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var category = await this.categoriesRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return category;
        }

        public async Task EditAsync(CategoryEditViewModel viewModel, string rootPath)
        {
            var category = await this.categoriesRepository.All().FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (category == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CategoryMissing, viewModel.Id));
            }

            if (this.categoriesRepository.All().Any(x => x.Name == viewModel.Name && x.Id != viewModel.Id))
            {
                throw new ArgumentException(ExceptionMessages.CategoryAlreadyExists, viewModel.Name);
            }

            var imageUrl = this.categoriesRepository.All()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id)
                .GetAwaiter()
                .GetResult()
                .ImageUrl;

            if (viewModel.Image != null)
            {
                var imageName = viewModel.Name.ToLower().Replace(" ", "-");
                string imagePath = rootPath + $"/assets/img/categories/{imageName}.jpg";

                using (FileStream stream = new FileStream(imagePath, FileMode.Create))
                {
                    await viewModel.Image.CopyToAsync(stream);
                }

                imageUrl = $"assets/img/categories/{imageName}.jpg";
            }

            category.Name = viewModel.Name;
            category.ImageUrl = imageUrl;
            category.ModifiedOn = DateTime.UtcNow;
            this.categoriesRepository.Update(category);
            await this.categoriesRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await this.categoriesRepository.All().FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CategoryMissing, id));
            }

            if (category.Recipes.Count > 0)
            {
                foreach (var recipe in category.Recipes)
                {
                    this.recipeCategoriesRepository.Delete(recipe);
                }
            }

            this.categoriesRepository.Delete(category);
            await this.categoriesRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetAllCategoriesSelectListAsync()
        {
            var categoriesViewModel = await this.GetAllAsync<CategoryInRecipeViewModel>();

            var categories = categoriesViewModel
                    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                    .ToList();

            return categories;
        }
    }
}
