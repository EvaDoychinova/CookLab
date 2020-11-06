namespace CookLab.Models.ServiceModels.CategoryRecipies
{
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class CategoryRecipeServiceModel : IMapFrom<CategoryRecipe>
    {
        public string CategoryName { get; set; }
    }
}
