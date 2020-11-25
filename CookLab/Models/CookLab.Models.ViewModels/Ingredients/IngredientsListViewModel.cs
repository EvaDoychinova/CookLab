namespace CookLab.Models.ViewModels.Ingredients
{
    using System.Collections.Generic;

    public class IngredientsListViewModel : PaginationViewModel
    {
        public IEnumerable<IngredientViewModel> Ingredients { get; set; }
    }
}
