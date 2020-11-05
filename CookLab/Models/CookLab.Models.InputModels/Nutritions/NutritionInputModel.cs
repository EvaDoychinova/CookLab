namespace CookLab.Models.InputModels.Nutritions
{
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class NutritionInputModel : IMapTo<Nutrition>
    {
        public double Calories { get; set; }

        public double Carbohydrates { get; set; }

        public double Fats { get; set; }

        public double Proteins { get; set; }

        public double Fibres { get; set; }
    }
}
