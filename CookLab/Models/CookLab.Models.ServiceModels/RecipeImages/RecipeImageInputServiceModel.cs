namespace CookLab.Models.ServiceModels.RecipeImages
{
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class RecipeImageInputServiceModel : IMapTo<RecipeImage>
    {
        public string ImageUrl { get; set; }
    }
}
