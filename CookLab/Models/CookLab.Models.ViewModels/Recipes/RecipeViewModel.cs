namespace CookLab.Models.ViewModels.Recipes
{
    using System;

    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class RecipeViewModel : IMapFrom<Recipe>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public TimeSpan PreparationTime { get; set; }

        public TimeSpan CookingTime { get; set; }
    }
}
