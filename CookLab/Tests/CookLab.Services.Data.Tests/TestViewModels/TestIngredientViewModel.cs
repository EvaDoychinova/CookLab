namespace CookLab.Services.Data.Tests.TestViewModels
{
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class TestIngredientViewModel : IMapFrom<Ingredient>
    {
        public string Name { get; set; }

        public double VolumeInMlPer100Grams { get; set; }
    }
}
