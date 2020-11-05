namespace CookLab.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using CookLab.Data.Common.Models;

    public class RecipeImage : BaseDeletableModel<string>
    {
        public RecipeImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [ForeignKey(nameof(Recipe))]
        public string RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
