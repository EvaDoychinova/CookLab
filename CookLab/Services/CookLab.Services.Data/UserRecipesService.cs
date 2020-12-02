namespace CookLab.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;

    using Microsoft.EntityFrameworkCore;

    using static CookLab.Common.ExceptionMessages;

    public class UserRecipesService : IUserRecipesService
    {
        private readonly IDeletableEntityRepository<UserRecipe> userRecipesRepository;
        private readonly IDeletableEntityRepository<Recipe> recipeRepository;

        public UserRecipesService(
            IDeletableEntityRepository<UserRecipe> userRecipesRepository,
            IDeletableEntityRepository<Recipe> recipeRepository)
        {
            this.userRecipesRepository = userRecipesRepository;
            this.recipeRepository = recipeRepository;
        }

        public async Task AddRecipeToUserListAsync(string userId, string recipeId)
        {
            var userRecipe = await this.userRecipesRepository.AllWithDeleted()
                .FirstOrDefaultAsync(x => x.UserId == userId && x.RecipeId == recipeId);

            if (userRecipe != null)
            {
                this.userRecipesRepository.Undelete(userRecipe);
            }
            else
            {
                userRecipe = new UserRecipe
                {
                    UserId = userId,
                    RecipeId = recipeId,
                };

                await this.userRecipesRepository.AddAsync(userRecipe);
            }

            await this.userRecipesRepository.SaveChangesAsync();
        }

        public async Task RemoveRecipeFromUserListAsync(string userId, string recipeId)
        {
            var userRecipe = await this.userRecipesRepository.All()
                .FirstOrDefaultAsync(x => x.UserId == userId && x.RecipeId == recipeId);

            if (userRecipe != null)
            {
                this.userRecipesRepository.Delete(userRecipe);
                await this.userRecipesRepository.SaveChangesAsync();
            }
        }

        public async Task<int> GetUsersForRecipeAsync(string recipeId)
        {
            var recipe = await this.recipeRepository.All()
                .FirstOrDefaultAsync(x => x.Id == recipeId);

            if (recipe == null)
            {
                throw new NullReferenceException(string.Format(RecipeMissing, recipeId));
            }

            var usersCount = await this.userRecipesRepository.All()
                .Where(x => x.RecipeId == recipeId)
                .CountAsync();

            return usersCount;
        }
    }
}
