namespace CookLab.Models.InputModels.AdministratorInputModels.Ingredients
{
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class IngredientInputModel : IMapTo<Ingredient>
    {
        public string Name { get; set; }

        public double VolumeInMlPer100Grams { get; set; }
    }
}
