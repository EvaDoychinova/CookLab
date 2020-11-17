namespace CookLab.Models.ViewModels.RecipeImages
{
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class ImageRecipeViewModel : IMapFrom<RecipeImage>
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }
    }
}
