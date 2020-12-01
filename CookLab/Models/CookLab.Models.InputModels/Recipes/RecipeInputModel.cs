namespace CookLab.Models.InputModels.Recipes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CookLab.Data.Models;
    using CookLab.Models.InputModels.RecipeIngredients;
    using CookLab.Services.Mapping;
    using CookLab.Web.Infrastructure.Attributes;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using static CookLab.Common.DisplayNames.RecipesDisplayNames;
    using static CookLab.Common.ErrorMessages;
    using static CookLab.Common.ModelsValidations.RecipesValidations;

    public class RecipeInputModel : IMapTo<Recipe>
    {
        [Required(ErrorMessage = RequiredInputFieldError)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = StringLengthError)]
        [Display(Name = RecipeNameDisplayName)]
        public string Name { get; set; }

        [Range(MinPreparationTimeInMinutes, MaxPreparationTimeInMinutes, ErrorMessage = InvalidRangeError)]
        [Display(Name = PreparationTimeDisplayName)]
        public int PreparationTime { get; set; }

        [Range(MinCookingTimeInMinutes, MaxCookingTimeInMinutes, ErrorMessage = InvalidRangeError)]
        [Display(Name = CookingTimeDisplayName)]
        public int CookingTime { get; set; }

        [Required(ErrorMessage = RequiredInputFieldError)]
        [Range(PortionsMinValue, PortionsMaxValue, ErrorMessage = InvalidRangeError)]
        [Display(Name = PortionsDisplayName)]
        public int Portions { get; set; }

        [Required(ErrorMessage = RequiredInputFieldError)]
        [StringLength(PreparationMaxLength, MinimumLength = PreparationMinLength, ErrorMessage = StringLengthError)]
        public string Preparation { get; set; }

        [Required(ErrorMessage = RequiredSelectFiledError)]
        [Display(Name = CookingVesselDisplayName)]
        public int CookingVesselId { get; set; }

        [Required(ErrorMessage = RequiredSelectFiledError)]
        [Display(Name = SelectedCategoriesDisplayName)]
        public IList<int> SelectedCategories { get; set; }

        [Required(ErrorMessage = RequiredSelectFiledError)]
        public IList<RecipeIngredientInputModel> SelectedIngredients { get; set; }

        [StringLength(NotesMaxLength, MinimumLength =NotesMinLength, ErrorMessage = StringLengthError)]
        [Display(Name = NotesDisplayName)]
        public string Notes { get; set; }

        [Required(ErrorMessage = RequiredInputFieldError)]
        [DataType(DataType.Upload)]
        [AllowedImageExtensions]
        [ImageMaxSize(ImageFileMaxSize)]
        [Display(Name = "Choose images...")]
        public IEnumerable<IFormFile> Images { get; set; }

        public IEnumerable<SelectListItem> CookingVessels { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public IEnumerable<SelectListItem> Ingredients { get; set; }
    }
}
