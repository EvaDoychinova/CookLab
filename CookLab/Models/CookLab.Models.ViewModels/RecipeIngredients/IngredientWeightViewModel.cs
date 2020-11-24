namespace CookLab.Models.ViewModels.RecipeIngredients
{
    using System.Globalization;

    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class IngredientWeightViewModel : IMapFrom<RecipeIngredient>
    {
        public string IngredientName { get; set; }

        public double WeightInGrams { get; set; }

        public string WeightInGramsToString => this.WeightInGrams.ToString("F2", CultureInfo.InvariantCulture);
    }
}
