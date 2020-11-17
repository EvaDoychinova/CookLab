namespace CookLab.Models.InputModels.Recipes
{
    using System.Collections.Generic;

    using CookLab.Data.Models;
    using CookLab.Models.InputModels.RecipeImages;
    using CookLab.Models.ViewModels.Categories;
    using CookLab.Models.ViewModels.Ingredients;
    using CookLab.Services.Mapping;

    public class RecipeInputModel : IMapTo<Recipe>
    {
        public string Name { get; set; }

        public int PreparationTime { get; set; }

        public int CookingTime { get; set; }

        public string Preparation { get; set; }

        public int CookingVesselId { get; set; }

        public ICollection<CategoryRecipeViewModel> Categories { get; set; }

        public ICollection<IngredientRecipeViewModel> Ingredients { get; set; }

        public ICollection<ImageRecipeInputModel> Images { get; set; }
    }
}
