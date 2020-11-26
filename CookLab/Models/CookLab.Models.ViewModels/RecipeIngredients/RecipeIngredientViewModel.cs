namespace CookLab.Models.ViewModels.RecipeIngredients
{
    using System.ComponentModel.DataAnnotations;

    using CookLab.Data.Models;
    using CookLab.Data.Models.Enums;
    using CookLab.Models.ViewModels.Ingredients;
    using CookLab.Services.Mapping;

    using static CookLab.Common.DisplayNames.RecipesDisplayNames;

    public class RecipeIngredientViewModel : IMapFrom<RecipeIngredient>
    {
        public string Id { get; set; }

        public string IngredientId { get; set; }

        public IngredientRecipeViewModel Ingredient { get; set; }

        public double WeightInGrams { get; set; }

        public IngredientPartOfRecipe PartOfRecipe { get; set; }
    }
}
