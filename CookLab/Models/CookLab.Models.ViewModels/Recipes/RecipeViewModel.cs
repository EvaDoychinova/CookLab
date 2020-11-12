namespace CookLab.Models.ViewModels.Recipes
{
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class RecipeViewModel : IMapFrom<Recipe>
    {
        public string Name { get; set; }
    }
}