namespace CookLab.Web.ViewComponents
{
    using System.Linq;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.ViewModels.SideBar;
    using CookLab.Services.Mapping;

    using Microsoft.AspNetCore.Mvc;

    public class LatestRecipesViewComponent : ViewComponent
    {
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;

        public LatestRecipesViewComponent(IDeletableEntityRepository<Recipe> recipesRepository)
        {
            this.recipesRepository = recipesRepository;
        }

        public IViewComponentResult Invoke(int count)
        {
            var latestRecipes = this.recipesRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .Take(count)
                .To<SideBarRecipeViewModel>()
                .ToList();

            var viewModel = new SideBarRecipeListViewModel
            {
                SideBarRecipes = latestRecipes,
            };

            return this.View(viewModel);
        }
    }
}
