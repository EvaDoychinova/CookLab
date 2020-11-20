namespace CookLab.Models.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;

    using CookLab.Data.Models;
    using CookLab.Models.ViewModels.CookingVessels;
    using CookLab.Models.ViewModels.Nutritions;
    using CookLab.Models.ViewModels.RecipeImages;
    using CookLab.Models.ViewModels.RecipeIngredients;
    using CookLab.Models.ViewModels.UserRecipes;
    using CookLab.Services.Mapping;

    public class RecipeEditViewModel : IMapFrom<Recipe>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public TimeSpan PreparationTime { get; set; }

        public TimeSpan CookingTime { get; set; }

        public virtual ICollection<ImageRecipeViewModel> Images { get; set; }

        public int CookingVesselId { get; set; }

        public virtual CookingVesselViewModel CookingVessel { get; set; }

        public virtual ICollection<RecipeIngredientViewModel> Ingredients { get; set; }

        public string Preparation { get; set; }

        public virtual NutritionViewModel NutritionPer100Grams { get; set; }

        public string CreatorId { get; set; }

        public virtual ICollection<UserRecipeViewModel> Users { get; set; }
    }
}
