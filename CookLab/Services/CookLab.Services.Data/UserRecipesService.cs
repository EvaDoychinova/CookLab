namespace CookLab.Services.Data
{
    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;

    public class UserRecipesService : IUserRecipesService
    {
        private readonly IDeletableEntityRepository<UserRecipe> userRecipesRepository;

        public UserRecipesService(IDeletableEntityRepository<UserRecipe> userRecipesRepository)
        {
            this.userRecipesRepository = userRecipesRepository;
        }
    }
}
