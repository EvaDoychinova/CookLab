namespace CookLab.Models.InputModels.Nutritions
{
    using System.ComponentModel.DataAnnotations;

    using static CookLab.Common.ErrorMessages;
    using static CookLab.Common.ModelsValidations.NutritionsValidations;

    public class NutritionInputModel
    {
        [Range(CaloriesMinValue, CaloriesMaxValue, ErrorMessage = InvalidRangeError)]
        public double Calories { get; set; }

        [Range(CaloriesMinValue, CaloriesMaxValue, ErrorMessage = InvalidRangeError)]
        public double Carbohydrates { get; set; }

        [Range(CaloriesMinValue, CaloriesMaxValue, ErrorMessage = InvalidRangeError)]
        public double Fats { get; set; }

        [Range(CaloriesMinValue, CaloriesMaxValue, ErrorMessage = InvalidRangeError)]
        public double Proteins { get; set; }

        [Range(CaloriesMinValue, CaloriesMaxValue, ErrorMessage = InvalidRangeError)]
        public double Fibres { get; set; }
    }
}
