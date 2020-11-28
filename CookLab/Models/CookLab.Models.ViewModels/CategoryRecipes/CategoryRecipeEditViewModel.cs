namespace CookLab.Models.ViewModels.CategoryRecipes
{
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class CategoryRecipeEditViewModel : IMapFrom<CategoryRecipe>
    {
        public int CategoryId { get; set; }
    }
}
