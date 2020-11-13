namespace CookLab.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CookLab.Data.Common.Models;

    using static CookLab.Common.ModelsValidations.IngredientsValidations;

    public class Ingredient : BaseDeletableModel<string>
    {
        public Ingredient()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Recipies = new HashSet<RecipeIngredient>();
        }

        [Required]
        public string Name { get; set; }

        [Range(VolumeMinValue, VolumeMaxValue)]
        public double VolumeInMlPer100Grams { get; set; }

        public virtual Nutrition NutritionPer100Grams { get; set; }

        public virtual ICollection<RecipeIngredient> Recipies { get; set; }
    }
}
