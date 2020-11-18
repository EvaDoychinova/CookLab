namespace CookLab.Models.InputModels.Nutritions
{
    using System.ComponentModel.DataAnnotations;

    using CookLab.Models.ViewModels.Ingredients;

    using static CookLab.Common.DisplayNames.NutritionsDisplayNames;
    using static CookLab.Common.ErrorMessages;
    using static CookLab.Common.ModelsValidations.NutritionsValidations;

    public class NutritionInputModel
    {
        [Required(ErrorMessage = RequiredInputFieldError)]
        [Range(CaloriesMinValue, CaloriesMaxValue, ErrorMessage = InvalidRangeError)]
        [Display(Name = CaloriesDisplayName)]
        public double Calories { get; set; }

        [Required(ErrorMessage = RequiredInputFieldError)]
        [Range(CaloriesMinValue, CaloriesMaxValue, ErrorMessage = InvalidRangeError)]
        [Display(Name = CarbohydratesDisplayName)]
        public double Carbohydrates { get; set; }

        [Required(ErrorMessage = RequiredInputFieldError)]
        [Range(CaloriesMinValue, CaloriesMaxValue, ErrorMessage = InvalidRangeError)]
        [Display(Name = FatsDisplayName)]
        public double Fats { get; set; }

        [Required(ErrorMessage = RequiredInputFieldError)]
        [Range(CaloriesMinValue, CaloriesMaxValue, ErrorMessage = InvalidRangeError)]
        [Display(Name = ProteinsDisplayName)]
        public double Proteins { get; set; }

        [Required(ErrorMessage = RequiredInputFieldError)]
        [Range(CaloriesMinValue, CaloriesMaxValue, ErrorMessage = InvalidRangeError)]
        [Display(Name = FibresDisplayName)]
        public double Fibres { get; set; }

        public string IngredientId { get; set; }

        public IngredientViewModel Ingredient { get; set; }
    }
}
