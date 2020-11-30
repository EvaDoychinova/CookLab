namespace CookLab.Models.ViewModels.Categories
{
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class CategoryInRecipeEditViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }
    }
}
