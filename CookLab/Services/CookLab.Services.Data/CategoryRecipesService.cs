namespace CookLab.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;

    using Microsoft.EntityFrameworkCore;

    public class CategoryRecipesService : ICategoryRecipesService
    {
        private readonly IDeletableEntityRepository<CategoryRecipe> categoryRecipeRepository;

        public CategoryRecipesService(IDeletableEntityRepository<CategoryRecipe> categoryRecipeRepository)
        {
            this.categoryRecipeRepository = categoryRecipeRepository;
        }

        public async Task<IList<int>> GetAllCategoriesForRecipeAsync(string recipeId)
        {
            var categories = await this.categoryRecipeRepository.AllAsNoTracking()
                .Where(x => x.RecipeId == recipeId)
                .OrderBy(x => x.Category.Name)
                .Select(x => x.Category.Id)
                .ToListAsync();

            return categories;
        }
    }
}
