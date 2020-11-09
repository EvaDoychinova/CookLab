namespace CookLab.Models.InputModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    using Microsoft.AspNetCore.Http;

    public class CategoryInputModel : IMapTo<Category>
    {
        [Required(ErrorMessage ="Category name cannot be empty string!")]
        [StringLength(30, MinimumLength = 4)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Image file has not been chosen!")]
        [Display(Name = "Choose image")]
        public IFormFile Image { get; set; }
    }
}
