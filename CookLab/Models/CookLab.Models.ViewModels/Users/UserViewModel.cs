namespace CookLab.Models.ViewModels.Users
{
    using System.Collections.Generic;

    using CookLab.Data.Models;
    using CookLab.Models.ViewModels.Recipes;
    using CookLab.Services.Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public ICollection<RecipeViewModel> CreatedRecipes { get; set; }
    }
}
