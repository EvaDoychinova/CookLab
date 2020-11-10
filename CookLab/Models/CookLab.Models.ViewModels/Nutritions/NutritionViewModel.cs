namespace CookLab.Models.ViewModels.Nutritions
{
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class NutritionViewModel : IMapFrom<Nutrition>
    {
        public string Id { get; set; }

        public double Calories { get; set; }

        public double Carbohydrates { get; set; }

        public double Fats { get; set; }

        public double Proteins { get; set; }

        public double Fibres { get; set; }
    }
}
