namespace CookLab.Models.InputModels.Recipes
{
    using System.Collections.Generic;

    using CookLab.Data.Models;
    using CookLab.Models.InputModels.RecipeImages;
    using CookLab.Models.ViewModels.Categories;
    using CookLab.Models.ViewModels.Ingredients;
    using CookLab.Services.Mapping;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class RecipeInputModel : IMapTo<Recipe>
    {
        public string Name { get; set; }

        public int PreparationTime { get; set; }

        public int CookingTime { get; set; }

        public string Preparation { get; set; }

        public int CookingVesselId { get; set; }

        public IList<int> SelectedCategories { get; set; }

        public IList<string> SelectedIngredients { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }

        public IEnumerable<SelectListItem> CookingVessels { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public IEnumerable<SelectListItem> Ingredients { get; set; }
    }
}
