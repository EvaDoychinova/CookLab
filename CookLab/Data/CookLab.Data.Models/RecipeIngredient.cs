namespace CookLab.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using CookLab.Data.Common.Models;

    public class RecipeIngredient : BaseDeletableModel<string>
    {
        public RecipeIngredient()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [ForeignKey(nameof(Ingredient))]
        public string IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        [Required]
        [ForeignKey(nameof(Recipe))]
        public string RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public double WeightInGrams { get; set; }
    }
}
