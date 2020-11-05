namespace CookLab.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using CookLab.Data.Common.Models;

    public class Nutrition : BaseDeletableModel<string>
    {
        public Nutrition()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public double Calories { get; set; }

        public double Carbohydrates { get; set; }

        public double Fats { get; set; }

        public double Proteins { get; set; }

        public double Fibres { get; set; }

        [ForeignKey(nameof(Ingredient))]
        public string IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        [ForeignKey(nameof(Recipe))]
        public string RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
