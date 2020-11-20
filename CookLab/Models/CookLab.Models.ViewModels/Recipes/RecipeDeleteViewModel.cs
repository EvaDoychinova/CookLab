namespace CookLab.Models.ViewModels.Recipes
{
    using System.Collections.Generic;

    using CookLab.Data.Models;
    using CookLab.Models.ViewModels.RecipeImages;
    using CookLab.Models.ViewModels.RecipeIngredients;
    using CookLab.Models.ViewModels.UserRecipes;
    using CookLab.Services.Mapping;

    public class RecipeDeleteViewModel : IMapFrom<Recipe>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ImageRecipeViewModel> Images { get; set; }

        public virtual ICollection<RecipeIngredientViewModel> Ingredients { get; set; }

        public string CreatorId { get; set; }

        public virtual ICollection<UserRecipeViewModel> Users { get; set; }
    }
}
