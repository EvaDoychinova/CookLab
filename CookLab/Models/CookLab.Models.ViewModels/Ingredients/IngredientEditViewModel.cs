namespace CookLab.Models.ViewModels.Ingredients
{
    using System.ComponentModel.DataAnnotations;

    using CookLab.Models.ViewModels.Nutritions;

    using static CookLab.Common.DisplayNames.IngredientsDisplayNames;
    using static CookLab.Common.ErrorMessages;
    using static CookLab.Common.ModelsValidations.IngredientsValidations;

    public class IngredientEditViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = RequiredFieldError)]
        [StringLength(NameMaxValue, MinimumLength = NameMinValue, ErrorMessage = StringLengthError)]
        [Display(Name = IngredientName)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequiredFieldError)]
        [Range(VolumeMinValue, VolumeMaxValue, ErrorMessage = InvalidRangeError)]
        [Display(Name = IngredientVolume)]
        public double VolumeInMlPer100Grams { get; set; }

        public NutritionEditViewModel Nutrition { get; set; }
    }
}
