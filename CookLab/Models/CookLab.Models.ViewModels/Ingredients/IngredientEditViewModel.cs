﻿namespace CookLab.Models.ViewModels.Ingredients
{
    using System.ComponentModel.DataAnnotations;

    using CookLab.Data.Models;
    using CookLab.Models.ViewModels.Nutritions;
    using CookLab.Services.Mapping;

    using static CookLab.Common.DisplayNames.IngredientsDisplayNames;
    using static CookLab.Common.ErrorMessages;
    using static CookLab.Common.ModelsValidations.IngredientsValidations;

    public class IngredientEditViewModel : IMapFrom<Ingredient>
    {
        public string Id { get; set; }

        [Required(ErrorMessage = RequiredInputFieldError)]
        [StringLength(NameMaxValue, MinimumLength = NameMinValue, ErrorMessage = StringLengthError)]
        [Display(Name = IngredientName)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequiredInputFieldError)]
        [Range(VolumeMinValue, VolumeMaxValue, ErrorMessage = InvalidRangeError)]
        [Display(Name = IngredientVolume)]
        public double VolumeInMlPer100Grams { get; set; }

        public NutritionEditViewModel NutritionPer100Grams { get; set; }
    }
}
