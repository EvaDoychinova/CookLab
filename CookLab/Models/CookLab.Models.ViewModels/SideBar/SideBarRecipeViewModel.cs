namespace CookLab.Models.ViewModels.SideBar
{
    using System;
    using System.Collections.Generic;

    using CookLab.Data.Models;
    using CookLab.Models.ViewModels.RecipeImages;
    using CookLab.Models.ViewModels.Users;
    using CookLab.Services.Mapping;

    public class SideBarRecipeViewModel : IMapFrom<Recipe>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ImageRecipeViewModel> Images { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
