namespace CookLab.Models.InputModels.Recipes
{
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class RecipeInputModel : IMapTo<Recipe>
    {
        public string Name { get; set; }

        public string Preparation { get; set; }
    }
}
