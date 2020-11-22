namespace CookLab.Models.ViewModels.CategoryRecipes
{
    using CookLab.Data.Models;
    using CookLab.Models.ViewModels.Categories;
    using CookLab.Services.Mapping;

    public class CategoryRecipeViewModel : IMapFrom<CategoryRecipe>
    {
        public CategoryInRecipeViewModel Category { get; set; }
    }
}
