namespace CookLab.Models.ServiceModels.Recipes
{
    using System.Collections.Generic;

    using CookLab.Data.Models;
    using CookLab.Models.ServiceModels.CategoryRecipies;
    using CookLab.Models.ServiceModels.CookingVessels;
    using CookLab.Models.ServiceModels.Ingredients;
    using CookLab.Models.ServiceModels.RecipeImages;
    using CookLab.Services.Mapping;

    public class RecipeInputServiceModel : IMapTo<Recipe>
    {
        public string Name { get; set; }

        public string Preparation { get; set; }

        public virtual ICollection<CategoryRecipeServiceModel> Categories { get; set; }

        public virtual ICollection<RecipeImageInputServiceModel> Images { get; set; }

        public virtual CookingVesselPerRecipeServiceModel CookingVessel { get; set; }

        public virtual ICollection<IngredientInRecipeInputServiceModel> Ingredients { get; set; }
    }
}
