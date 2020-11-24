namespace CookLab.Models.InputModels.RecipeIngredients
{
    using System.ComponentModel.DataAnnotations;

    using CookLab.Data.Models.Enums;

    using static CookLab.Common.DisplayNames.RecipesDisplayNames;
    using static CookLab.Common.ErrorMessages;
    using static CookLab.Common.ModelsValidations.RecipesIngredientsValidations;

    public class RecipeIngredientInputModel
    {
        [Required(ErrorMessage = RequiredSelectFiledError)]
        [Display(Name = SelectedIngredientsNameDisplayName)]
        public string IngredientId { get; set; }

        [Range(WeightMinLength, WeightMaxLength, ErrorMessage = InvalidRangeError)]
        [Display(Name = SelectedIngredientsWeightDisplayName)]
        public double WeightInGrams { get; set; }

        [Display(Name = SelectedIngredientsPartOfRecipe)]
        [Range(PartOfRecipeMinValue, PartOfRecipeMaxValue, ErrorMessage = InvalidEnumRangeError)]
        public IngredientPartOfRecipe PartOfRecipe { get; set; }
    }
}
