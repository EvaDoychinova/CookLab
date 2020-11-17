namespace CookLab.Models.ViewModels.Recipes
{
    using System.Collections.Generic;

    public class RecipesListViewModel
    {
        public ICollection<RecipeViewModel> Recipes { get; set; }
    }
}
