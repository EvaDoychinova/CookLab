namespace CookLab.Models.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using CookLab.Web.Infrastructure.Attributes;

    using Microsoft.AspNetCore.Http;

    using static CookLab.Common.DisplayNames.CategoriesDisplayNames;
    using static CookLab.Common.ErrorMessages;
    using static CookLab.Common.ModelsValidations.CategoriesValidations;

    public class CategoryEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredFieldError)]
        [StringLength(NameMaxValue, MinimumLength = NameMinValue, ErrorMessage = StringLengthError)]
        [Display(Name = CategoryName)]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        [Required(ErrorMessage = RequiredFieldError)]
        [DataType(DataType.Upload)]
        [AllowedImageExtensions]
        [ImageMaxSize(ImageFileMaxSize)]
        [Display(Name = CategoryImage)]
        public IFormFile Image { get; set; }
    }
}
