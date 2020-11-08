namespace CookLab.Models.InputModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryInputModel
    {
        [Required]
        [StringLength(30, MinimumLength = 6)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }
    }
}
