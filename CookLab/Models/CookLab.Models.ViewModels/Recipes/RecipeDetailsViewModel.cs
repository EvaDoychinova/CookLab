namespace CookLab.Models.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    using CookLab.Data.Models;
    using CookLab.Models.ViewModels.CategoryRecipes;
    using CookLab.Models.ViewModels.CookingVessels;
    using CookLab.Models.ViewModels.Nutritions;
    using CookLab.Models.ViewModels.RecipeImages;
    using CookLab.Models.ViewModels.RecipeIngredients;
    using CookLab.Models.ViewModels.UserRecipes;
    using CookLab.Services.Mapping;

    using Microsoft.AspNetCore.Mvc.Rendering;

    using static CookLab.Common.DisplayNames.RecipesDisplayNames;
    using static CookLab.Common.ErrorMessages;
    using static CookLab.Common.ModelsValidations.RecipesValidations;

    public class RecipeDetailsViewModel : IMapFrom<Recipe>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public TimeSpan PreparationTime { get; set; }

        public int PreparationTimeInMinutes => (int)Math.Ceiling(this.PreparationTime.TotalMinutes);

        public TimeSpan CookingTime { get; set; }

        public int CookingTimeInMinutes => (int)Math.Ceiling(this.CookingTime.TotalMinutes);

        public int Portions { get; set; }

        [Range(PortionsMinValue, PortionsMaxValue, ErrorMessage = InvalidRangeError)]
        [Display(Name = PortionsDisplayName)]
        public int DesiredPortions => this.Portions;

        public ICollection<ImageRecipeViewModel> Images { get; set; }

        public ICollection<CategoryRecipeViewModel> Categories { get; set; }

        public CookingVesselViewModel CookingVessel { get; set; }

        public ICollection<RecipeIngredientViewModel> Ingredients { get; set; }

        public string Preparation { get; set; }

        public virtual NutritionViewModel Nutrition { get; set; }

        public string CreatorId { get; set; }

        public string CreatorUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnToString => this.CreatedOn.ToString("d", CultureInfo.InvariantCulture);

        public string Notes { get; set; }

        public ICollection<UserRecipeViewModel> Users { get; set; }

        public IEnumerable<SelectListItem> CookingVessels { get; set; }
    }
}
