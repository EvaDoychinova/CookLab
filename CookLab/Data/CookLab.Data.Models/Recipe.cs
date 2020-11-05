﻿namespace CookLab.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using CookLab.Data.Common.Models;

    public class Recipe : BaseDeletableModel<string>
    {
        public Recipe()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Ingredients = new HashSet<RecipeIngredient>();
            this.Categories = new HashSet<CategoryRecipe>();
            this.Users = new HashSet<UserRecipe>();
        }

        public string Name { get; set; }

        public virtual ICollection<CategoryRecipe> Categories { get; set; }

        public virtual ICollection<RecipeImage> Images { get; set; }

        [Required]
        [ForeignKey(nameof(CookingVessel))]
        public int CookingVesselId { get; set; }

        public virtual CookingVessel CookingVessel { get; set; }

        public virtual ICollection<RecipeIngredient> Ingredients { get; set; }

        public string Preparation { get; set; }

        public virtual Nutrition NutritionPer100Grams { get; set; }

        [Required]
        [ForeignKey(nameof(Creator))]
        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        public virtual ICollection<UserRecipe> Users { get; set; }
    }
}
