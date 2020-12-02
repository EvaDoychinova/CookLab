namespace CookLab.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using CookLab.Data.Common.Models;

    using static CookLab.Common.ModelsValidations.RecipesValidations;

    public class Recipe : BaseDeletableModel<string>
    {
        public Recipe()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Images = new HashSet<RecipeImage>();
            this.Ingredients = new HashSet<RecipeIngredient>();
            this.Categories = new HashSet<CategoryRecipe>();
            this.Users = new HashSet<UserRecipe>();
        }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Range(typeof(TimeSpan), MinPreparationTime, MaxPreparationTime)]
        public TimeSpan PreparationTime { get; set; }

        [Range(typeof(TimeSpan), MinCookingTime, MaxCookingTime)]
        public TimeSpan CookingTime { get; set; }

        [Range(PortionsMinValue, PortionsMaxValue)]
        public int Portions { get; set; }

        public virtual ICollection<CategoryRecipe> Categories { get; set; }

        public virtual ICollection<RecipeImage> Images { get; set; }

        [ForeignKey(nameof(CookingVessel))]
        public int CookingVesselId { get; set; }

        public virtual CookingVessel CookingVessel { get; set; }

        public virtual ICollection<RecipeIngredient> Ingredients { get; set; }

        [Required]
        [MaxLength(PreparationMaxLength)]
        public string Preparation { get; set; }

        public virtual Nutrition Nutrition { get; set; }

        [Required]
        [ForeignKey(nameof(Creator))]
        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        public virtual ICollection<UserRecipe> Users { get; set; }

        [MaxLength(NotesMaxLength)]
        public string Notes { get; set; }
    }
}
