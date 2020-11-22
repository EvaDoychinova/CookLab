namespace CookLab.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CookLab.Common;
    using CookLab.Data.Models;
    using CookLab.Models.InputModels.Recipes;
    using CookLab.Models.ViewModels.Categories;
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
            this.ViewData["Title"] = PageTitles.RecipeAllPageTitle;

            return this.View(this.CreateListViewModel(recipes));
        }

        public async Task<IActionResult> AllByCategory(int id)
        {
            var recipes = await this.recipesService.GetAllByCategoryAsync<RecipeViewModel>(id);
            var category = await this.categoriesService.GetByIdAsync<CategoryViewModel>(id);
            this.ViewData["Title"] = string.Format(PageTitles.RecipeAllByCategoryPageTitle, category.Name);

            return this.View(nameof(this.All), this.CreateListViewModel(recipes));
        }

        public async Task<IActionResult> AllCreatedBy(string id)
        {
            var recipes = await this.recipesService.GetAllByCreatorAsync<RecipeViewModel>(id);
            var user = await this.userManager.FindByIdAsync(id);
            this.ViewData["Title"] = string.Format(PageTitles.RecipeAllCreatedByPageTitle, user.UserName);

            return this.View(nameof(this.All), this.CreateListViewModel(recipes));
        }

        public async Task<IActionResult> AllMy()
        {
            var userId = this.userManager.GetUserId(this.User);
            var recipes = await this.recipesService.GetAllByUserAsync<RecipeViewModel>(userId);
            this.ViewData["Title"] = PageTitles.RecipeAllMyPageTitle;

            return this.View(nameof(this.All), this.CreateListViewModel(recipes));
        }

        public async Task<IActionResult> Details(string id)
        {
            var recipe = await this.recipesService.GetByIdAsync<RecipeDetailsViewModel>(id);

            return this.View(recipe);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var recipe = await this.recipesService.GetByIdAsync<RecipeEditViewModel>(id);

            return this.View(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RecipeEditViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            await this.recipesService.EditAsync(viewModel);

            return this.RedirectToAction(nameof(this.Details));
        }

        public async Task<IActionResult> Delete(string id)
        {
            var recipe = await this.recipesService.GetByIdAsync<RecipeDeleteViewModel>(id);

            return this.View(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RecipeDeleteViewModel viewModel)
        {
            await this.recipesService.DeleteAsync(viewModel.Id);

            return this.RedirectToAction(nameof(this.All));
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
