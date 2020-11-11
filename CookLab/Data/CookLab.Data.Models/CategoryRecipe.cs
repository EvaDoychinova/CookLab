namespace CookLab.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using CookLab.Data.Common.Models;

    public class CategoryRecipe : BaseDeletableModel<int>
    {
        [Required]
        [ForeignKey(nameof(Recipe))]
        public string RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
