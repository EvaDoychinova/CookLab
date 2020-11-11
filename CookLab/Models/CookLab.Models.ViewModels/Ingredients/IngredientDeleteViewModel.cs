namespace CookLab.Models.ViewModels.Ingredients
{
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class IngredientDeleteViewModel : IMapFrom<Ingredient>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double VolumeInMlPer100Grams { get; set; }
    }
}
