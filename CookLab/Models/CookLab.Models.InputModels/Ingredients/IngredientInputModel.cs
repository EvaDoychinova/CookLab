namespace CookLab.Models.InputModels.Ingredients
{
    using System.ComponentModel.DataAnnotations;

    using static CookLab.Common.DisplayNames.IngredientsDisplayNames;
    using static CookLab.Common.ErrorMessages;
    using static CookLab.Common.ModelsValidations.IngredientsValidations;

    public class IngredientInputModel
    {
        [Required(ErrorMessage = RequiredInputFieldError)]
        [StringLength(NameMaxValue, MinimumLength = NameMinValue, ErrorMessage = StringLengthError)]
        [Display(Name = IngredientName)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequiredInputFieldError)]
        [Range(VolumeMinValue, VolumeMaxValue, ErrorMessage = InvalidRangeError)]
        [Display(Name = IngredientVolume)]
        public double VolumeInMlPer100Grams { get; set; }
    }
}
