namespace CookLab.Models.ViewModels.Recipes
{
    using System.Collections.Generic;

    using CookLab.Data.Models;
    using CookLab.Models.ViewModels.Categories;
    using CookLab.Models.ViewModels.CategoryRecipes;
    using CookLab.Models.ViewModels.Nutritions;
    using CookLab.Models.ViewModels.RecipeImages;
    using CookLab.Models.ViewModels.RecipeIngredients;
    using CookLab.Services.Mapping;

    public class RecipeDeleteViewModel : IMapFrom<Recipe>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Portions { get; set; }

        public ICollection<CategoryRecipeViewModel> Categories { get; set; }

        public NutritionViewModel Nutrition { get; set; }

        public ICollection<ImageRecipeViewModel> Images { get; set; }

        public ICollection<RecipeIngredientViewModel> Ingredients { get; set; }

        public string Preparation { get; set; }

        public string CreatorUserName { get; set; }

        public int UsersCount { get; set; }
    }
}
