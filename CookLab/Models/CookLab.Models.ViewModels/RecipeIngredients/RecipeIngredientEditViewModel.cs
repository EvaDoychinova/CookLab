namespace CookLab.Models.ViewModels.RecipeIngredients
{
    using System.ComponentModel.DataAnnotations;

    using CookLab.Data.Models;
    using CookLab.Data.Models.Enums;
    using CookLab.Services.Mapping;

    using static CookLab.Common.DisplayNames.RecipesDisplayNames;
    using static CookLab.Common.ErrorMessages;
    using static CookLab.Common.ModelsValidations.RecipesIngredientsValidations;

    public class RecipeIngredientEditViewModel : IMapFrom<RecipeIngredient>
    {
        public string Id { get; set; }

        [Required(ErrorMessage = RequiredSelectFiledError)]
        [Display(Name = SelectedIngredientsNameDisplayName)]
        public string IngredientId { get; set; }

        public string IngredientName { get; set; }

        [Range(WeightMinValue, WeightMaxValue, ErrorMessage = InvalidRangeError)]
        [Display(Name = SelectedIngredientsWeightDisplayName)]
        public double WeightInGrams { get; set; }

        [Range(PartOfRecipeMinValue, PartOfRecipeMaxValue, ErrorMessage = InvalidEnumRangeError)]
        [Display(Name = SelectedIngredientsPartOfRecipeDisplayName)]
        public IngredientPartOfRecipe PartOfRecipe { get; set; }
    }
}
