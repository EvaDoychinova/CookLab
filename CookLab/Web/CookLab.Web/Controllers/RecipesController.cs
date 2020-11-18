namespace CookLab.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CookLab.Data.Models;
    using CookLab.Models.InputModels.Recipes;
    using CookLab.Models.ViewModels.Recipes;
    using CookLab.Services.Data;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class RecipesController : BaseController
    {
        private readonly IRecipesService recipesService;
        private readonly ICategoriesService categoriesService;
        private readonly IIngredientsService ingredientsService;
        private readonly ICookingVesselsService cookingVesselsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public RecipesController(
            IRecipesService recipesService,
            ICategoriesService categoriesService,
            IIngredientsService ingredientsService,
            ICookingVesselsService cookingVesselsService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment webHostEnvironment)
        {
            this.recipesService = recipesService;
            this.categoriesService = categoriesService;
            this.ingredientsService = ingredientsService;
            this.cookingVesselsService = cookingVesselsService;
            this.userManager = userManager;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Create()
        {
            var recipe = new RecipeInputModel
            {
                Categories = await this.categoriesService.GetAllCategoriesForRecipeAsync(),
                Ingredients = await this.ingredientsService.GetAllIngredientsForRecipeAsync(),
                CookingVessels = await this.cookingVesselsService.GetAllCookingVesselsForRecipeAsync(),
            };

            return this.View(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecipeInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.Categories = await this.categoriesService.GetAllCategoriesForRecipeAsync();
                inputModel.Ingredients = await this.ingredientsService.GetAllIngredientsForRecipeAsync();
                inputModel.CookingVessels = await this.cookingVesselsService.GetAllCookingVesselsForRecipeAsync();

                return this.View(inputModel);
            }

            var rootPath = this.webHostEnvironment.WebRootPath;
            var userId = this.userManager.GetUserId(this.User);
            await this.recipesService.CreateAsync(userId, inputModel, rootPath);

            return this.RedirectToAction(nameof(this.All));
        }

        public async Task<IActionResult> All()
        {
            var recipes = await this.recipesService.GetAllAsync<RecipeViewModel>();

            return this.View(this.CreateListViewModel(recipes));
        }

        public async Task<IActionResult> AllByCategory(int id)
        {
            var recipes = await this.recipesService.GetAllByCategoryAsync<RecipeViewModel>(id);

            return this.View(this.CreateListViewModel(recipes));
        }

        public async Task<IActionResult> AllCreatedBy(string id)
        {
            var recipes = await this.recipesService.GetAllByCreatorAsync<RecipeViewModel>(id);

            return this.View(this.CreateListViewModel(recipes));
        }

        public async Task<IActionResult> GetMy()
        {
            var userId = this.userManager.GetUserId(this.User);

            var recipes = await this.recipesService.GetAllByUserAsync<RecipeViewModel>(userId);

            return this.View(this.CreateListViewModel(recipes));
        }

        private RecipesListViewModel CreateListViewModel(IEnumerable<RecipeViewModel> recipes)
        {
            return new RecipesListViewModel
            {
                Recipes = recipes,
            };
        }
    }
}
