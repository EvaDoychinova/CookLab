namespace CookLab.Models.ViewModels.Recipes
{
    using System.Collections.Generic;

    public class RecipesListViewModel : PaginationViewModel
    {
        public ICollection<RecipeViewModel> Recipes { get; set; }
    }
}
