namespace CookLab.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CookLab.Data.Common.Models;

    using static CookLab.Common.ModelsValidations.CategoriesValidations;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Recipes = new HashSet<CategoryRecipe>();
        }

        [Required]
        [MaxLength(NameMaxValue)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public virtual ICollection<CategoryRecipe> Recipes { get; set; }
    }
}
