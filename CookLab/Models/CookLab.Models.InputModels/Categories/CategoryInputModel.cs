namespace CookLab.Models.InputModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using CookLab.Data.Models;
    using CookLab.Services.Mapping;
    using CookLab.Web.Infrastructure.Attributes;

    using Microsoft.AspNetCore.Http;

    using static CookLab.Common.DisplayNames.CategoriesDisplayNames;
    using static CookLab.Common.ErrorMessages;
    using static CookLab.Common.ModelsValidations.CategoriesValidations;

    public class CategoryInputModel : IMapTo<Category>
    {
        [Required(ErrorMessage = RequiredFieldError)]
        [StringLength(NameMaxValue, MinimumLength = NameMinValue, ErrorMessage = NameLengthError)]
        [Display(Name = CategoryName)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequiredFieldError)]
        [DataType(DataType.Upload)]
        [AllowedImageExtensions]
        [ImageMaxSize(ImageFileMaxSize)]
        [Display(Name = CategoryImage)]
        public IFormFile Image { get; set; }
    }
}
