namespace CookLab.Models.ViewModels.Nutritions
{
    using System.Globalization;

    using CookLab.Data.Models;
    using CookLab.Models.ViewModels.Ingredients;
    using CookLab.Models.ViewModels.Recipes;
    using CookLab.Services.Mapping;

    public class NutritionViewModel : IMapFrom<Nutrition>
    {
        public string Id { get; set; }

        public double Calories { get; set; }

        public string CaloriesToString => this.Calories.ToString("F2", CultureInfo.InvariantCulture);

        public double Carbohydrates { get; set; }

        public string CarbohydratesToString => this.Carbohydrates.ToString("F2", CultureInfo.InvariantCulture);

        public double Fats { get; set; }

        public string FatsToString => this.Fats.ToString("F2", CultureInfo.InvariantCulture);

        public double Proteins { get; set; }

        public string ProteinsToString => this.Proteins.ToString("F2", CultureInfo.InvariantCulture);

        public double Fibres { get; set; }

        public string FibresToString => this.Fibres.ToString("F2", CultureInfo.InvariantCulture);

        public string IngredientId { get; set; }

        public IngredientViewModel Ingredient { get; set; }

        public string RecipeId { get; set; }

        public RecipeViewModel Recipe { get; set; }
    }
}
