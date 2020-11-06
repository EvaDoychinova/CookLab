namespace CookLab.Models.ServiceModels.Ingredients
{
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class IngredientInRecipeInputServiceModel : IMapFrom<Ingredient>
    {
        public string IngredientName { get; set; }

        public double IngredientVolumeInMlPer100Grams { get; set; }

        public double Volume => this.WeightInGrams * this.IngredientVolumeInMlPer100Grams / 100;

        public double WeightInGrams { get; set; }
    }
}
