namespace CookLab.Models.ViewModels.UserRecipes
{
    using CookLab.Data.Models;
    using CookLab.Models.ViewModels.Users;
    using CookLab.Services.Mapping;

    public class UserRecipeViewModel : IMapFrom<UserRecipe>
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string UserUserName { get; set; }
    }
}
