namespace CookLab.Models.ViewModels.Ingredients
{
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class IngredientRecipeViewModel : IMapFrom<Ingredient>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
