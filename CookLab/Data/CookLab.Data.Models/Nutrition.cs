namespace CookLab.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using CookLab.Data.Common.Models;

    using static CookLab.Common.ModelsValidations.NutritionsValidations;

    public class Nutrition : BaseDeletableModel<string>
    {
        public Nutrition()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Range(CaloriesMinValue, CaloriesMaxValue)]
        public double Calories { get; set; }

        [Range(CarbohydratesMinValue, CarbohydratesMaxValue)]
        public double Carbohydrates { get; set; }

        [Range(FatsMinValue, FatsMaxValue)]
        public double Fats { get; set; }

        [Range(ProteinsMinValue, ProteinsMaxValue)]
        public double Proteins { get; set; }

        [Range(FibresMinValue, FibresMaxValue)]
        public double Fibres { get; set; }

        [ForeignKey(nameof(Ingredient))]
        public string IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        [ForeignKey(nameof(Recipe))]
        public string RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
