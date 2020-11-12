namespace CookLab.Models.ViewModels.Ingredients
{
    using System.Globalization;

    using CookLab.Data.Models;
    using CookLab.Models.ViewModels.Nutritions;
    using CookLab.Services.Mapping;

    public class IngredientViewModel : IMapFrom<Ingredient>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double VolumeInMlPer100Grams { get; set; }

        public string VolumeToString => this.VolumeInMlPer100Grams.ToString("F2", CultureInfo.InvariantCulture);

        public NutritionViewModel NutritionPer100Grams { get; set; }
    }
}
