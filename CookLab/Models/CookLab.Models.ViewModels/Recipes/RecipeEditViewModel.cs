namespace CookLab.Models.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using CookLab.Data.Models;
    using CookLab.Models.ViewModels.Categories;
    using CookLab.Models.ViewModels.RecipeImages;
    using CookLab.Models.ViewModels.RecipeIngredients;
    using CookLab.Services.Mapping;
    using CookLab.Web.Infrastructure.Attributes;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using static CookLab.Common.DisplayNames.RecipesDisplayNames;
    using static CookLab.Common.ErrorMessages;
    using static CookLab.Common.ModelsValidations.RecipesValidations;

    public class RecipeEditViewModel : IMapFrom<Recipe>
    {
        public string Id { get; set; }

        [Required(ErrorMessage = RequiredInputFieldError)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = StringLengthError)]
        [Display(Name = RecipeNameDisplayName)]
        public string Name { get; set; }

        public TimeSpan PreparationTime { get; set; }

        [Range(MinPreparationTime, MaxPreparationTime, ErrorMessage = InvalidRangeError)]
        [Display(Name = PreparationTimeDisplayName)]

        public int PreparationTimeInMinutes => (int)Math.Ceiling( this.PreparationTime.TotalMinutes);

        public TimeSpan CookingTime { get; set; }

        [Range(MinCookingTime, MaxCookingTime, ErrorMessage = InvalidRangeError)]
        [Display(Name = CookingTimeDisplayName)]
        public int CookingTimeInMinutes => (int)Math.Ceiling(this.CookingTime.TotalMinutes);

        [Required(ErrorMessage = RequiredInputFieldError)]
        [Range(PortionsMinValue, PortionsMaxValue, ErrorMessage = InvalidRangeError)]
        [Display(Name = PortionsDisplayName)]
        public int Portions { get; set; }

        public ICollection<ImageRecipeViewModel> Images { get; set; }

        [Required(ErrorMessage = RequiredSelectFiledError)]
        [Display(Name = CookingVesselDisplayName)]
        public int CookingVesselId { get; set; }

        [Required(ErrorMessage = RequiredSelectFiledError)]
        [Display(Name = SelectedCategoriesDisplayName)]
        public IList<int> CategoriesCategoryId { get; set; }

        [Required(ErrorMessage = RequiredSelectFiledError)]
        public IList<RecipeIngredientEditViewModel> Ingredients { get; set; }

        [Required(ErrorMessage = RequiredInputFieldError)]
        [StringLength(PreparationMaxLength, MinimumLength = PreparationMinLength, ErrorMessage = StringLengthError)]
        public string Preparation { get; set; }

        [StringLength(NotesMaxLength, MinimumLength = NotesMinLength, ErrorMessage = StringLengthError)]
        [Display(Name = NotesDisplayName)]
        public string Notes { get; set; }

        [DataType(DataType.Upload)]
        [AllowedImageExtensions]
        [ImageMaxSize(ImageFileMaxSize)]
        [Display(Name = "Choose images...")]
        public IEnumerable<IFormFile> ImagesToSelect { get; set; }

        public IEnumerable<SelectListItem> CookingVesselsToSelect { get; set; }

        public IEnumerable<SelectListItem> CategoriesToSelect { get; set; }

        public IEnumerable<SelectListItem> IngredientsToSelect { get; set; }
    }
}
