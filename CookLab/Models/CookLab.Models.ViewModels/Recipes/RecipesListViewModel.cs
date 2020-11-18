namespace CookLab.Models.ViewModels.Recipes
{
    using System.Collections.Generic;

    public class RecipesListViewModel
    {
        public IEnumerable<RecipeViewModel> Recipes { get; set; }
    }
}
