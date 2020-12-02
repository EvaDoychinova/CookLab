namespace CookLab.Models.InputModels.RecipeIngredients
{
    using System;
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

        [Range(WeightMinValue, WeightMaxValue, ErrorMessage = InvalidRangeError)]
        [Display(Name = SelectedIngredientsWeightDisplayName)]
        public double WeightInGrams { get; set; }

        [Range(PartOfRecipeMinValue, PartOfRecipeMaxValue, ErrorMessage = InvalidEnumRangeError)]
        [Display(Name = SelectedIngredientsPartOfRecipeDisplayName)]
        public IngredientPartOfRecipe PartOfRecipe { get; set; }
    }
}
