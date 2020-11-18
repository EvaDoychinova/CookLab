namespace CookLab.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Models.InputModels.Recipes;
    using CookLab.Models.ViewModels.Categories;
    using CookLab.Models.ViewModels.CookingVessels;
    using CookLab.Models.ViewModels.Ingredients;
    using CookLab.Services.Data;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class RecipesController : BaseController
    {
        private readonly IRecipesService recipesService;
        private readonly ICategoriesService catgeoriesService;
        private readonly IIngredientsService ingredientsService;
        private readonly ICookingVesselsService cookingVesselsService;

        public RecipesController(
            IRecipesService recipesService,
            ICategoriesService catgeoriesService,
            IIngredientsService ingredientsService,
            ICookingVesselsService cookingVesselsService)
        {
            this.recipesService = recipesService;
            this.catgeoriesService = catgeoriesService;
            this.ingredientsService = ingredientsService;
            this.cookingVesselsService = cookingVesselsService;
        }

        public async Task<IActionResult> Create()
        {
            var categories = await this.catgeoriesService.GetAllAsync<CategoryRecipeViewModel>();
            var ingredients = await this.ingredientsService.GetAllAsync<IngredientRecipeViewModel>();
            var cookingVessels = await this.cookingVesselsService.GetAllAsync<CookingVesselRecipeViewModel>();

            var recipe = new RecipeInputModel
            {
                Categories = categories.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList(),
                Ingredients = ingredients.Select(x => new SelectListItem(x.Name, x.Id)).ToList(),
                CookingVessels = cookingVessels.Select(x=>new SelectListItem(x.Name, x.Id.ToString())),
            };

            return this.View(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecipeInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult All()
        {
            return this.View();
        }

        public IActionResult AllByCategory(string categoryId)
        {
            return this.View();
        }

        [Authorize]
        public IActionResult GetMy()
        {
            return this.View();
        }
    }
}
