namespace CookLab.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    using Microsoft.EntityFrameworkCore;

    public class CategoryRecipeService : ICategoryRecipeService
    {
        private readonly IDeletableEntityRepository<CategoryRecipe> categoryRecipeRepository;

        public CategoryRecipeService(IDeletableEntityRepository<CategoryRecipe> categoryRecipeRepository)
        {
            this.categoryRecipeRepository = categoryRecipeRepository;
        }

        public async Task<IEnumerable<T>> GetAllCategoriesForRecipeAsync<T>(string recipeId)
        {
            var categories = await this.categoryRecipeRepository.AllAsNoTracking()
                .Where(x => x.RecipeId == recipeId)
                .OrderBy(x => x.Category.Name)
                .Select(x => x.Category)
                .To<T>()
                .ToListAsync();

            return categories;
        }
    }
}
