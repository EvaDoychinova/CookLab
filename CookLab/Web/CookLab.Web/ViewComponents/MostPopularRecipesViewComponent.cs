namespace CookLab.Web.ViewComponents
{
    using System.Linq;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.ViewModels.SideBar;
    using CookLab.Services.Mapping;

    using Microsoft.AspNetCore.Mvc;

    public class MostPopularRecipesViewComponent : ViewComponent
    {
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;

        public MostPopularRecipesViewComponent(IDeletableEntityRepository<Recipe> recipesRepository)
        {
            this.recipesRepository = recipesRepository;
        }

        public IViewComponentResult Invoke(int count)
        {
            var latestRecipes = this.recipesRepository.All()
                .OrderByDescending(x => x.Users.Count)
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
