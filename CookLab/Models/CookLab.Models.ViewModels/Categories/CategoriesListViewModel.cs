namespace CookLab.Models.ViewModels.Categories
{
    using System.Collections.Generic;

    public class CategoriesListViewModel : PaginationViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
