namespace CookLab.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
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
        private readonly ICategoryRecipeService categoryRecipeService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public RecipesController(
            IRecipesService recipesService,
            ICategoriesService categoriesService,
            IIngredientsService ingredientsService,
            ICookingVesselsService cookingVesselsService,
            ICategoryRecipeService categoryRecipeService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment webHostEnvironment)
        {
            this.recipesService = recipesService;
            this.categoriesService = categoriesService;
            this.ingredientsService = ingredientsService;
            this.cookingVesselsService = cookingVesselsService;
            this.categoryRecipeService = categoryRecipeService;
            this.userManager = userManager;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Create()
        {
            var recipe = new RecipeInputModel
            {
                Categories = await this.categoriesService.GetAllCategoriesSelectListAsync(),
                Ingredients = await this.ingredientsService.GetAllIngredientsSelectListAsync(),
                CookingVessels = await this.cookingVesselsService.GetAllCookingVesselsSelectListAsync(),
            };

            return this.View(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecipeInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.Categories = await this.categoriesService.GetAllCategoriesSelectListAsync();
                inputModel.Ingredients = await this.ingredientsService.GetAllIngredientsSelectListAsync();
                inputModel.CookingVessels = await this.cookingVesselsService.GetAllCookingVesselsSelectListAsync();

                return this.View(inputModel);
            }

            var rootPath = this.webHostEnvironment.WebRootPath;
            var userId = this.userManager.GetUserId(this.User);
            await this.recipesService.CreateAsync(userId, inputModel, rootPath);

            return this.RedirectToAction(nameof(this.All));
        }

        public async Task<IActionResult> All(int id = 1)
        {
            int itemsPerPage = 9;
            var recipes = await this.recipesService.GetAllAsync<RecipeViewModel>();
            this.ViewData["Title"] = PageTitles.RecipeAllPageTitle;
            this.ViewData["Action"] = nameof(this.All);
            return this.View(this.CreateListViewModel(recipes, id, itemsPerPage));
        }

        public async Task<IActionResult> AllByCategory([FromQuery] int categoryId, int id = 1)
        {
            int itemsPerPage = 9;
            var recipes = await this.recipesService.GetAllByCategoryAsync<RecipeViewModel>(categoryId);
            var category = await this.categoriesService.GetByIdAsync<CategoryViewModel>(categoryId);
            this.ViewData["Title"] = string.Format(PageTitles.RecipeAllByCategoryPageTitle, category.Name);

            return this.View(nameof(this.All), this.CreateListViewModel(recipes, id, itemsPerPage));
        }

        public async Task<IActionResult> AllCreatedBy([FromQuery] string userId, int id = 1)
        {
            int itemsPerPage = 9;
            var recipes = await this.recipesService.GetAllByCreatorAsync<RecipeViewModel>(userId);
            var user = await this.userManager.FindByIdAsync(userId);
            this.ViewData["Title"] = string.Format(PageTitles.RecipeAllCreatedByPageTitle, user.UserName);

            return this.View(nameof(this.All), this.CreateListViewModel(recipes, id, itemsPerPage));
        }

        public async Task<IActionResult> AllCreatedByMe(int id = 1)
        {
            int itemsPerPage = 9;
            var userId = this.userManager.GetUserId(this.User);
            var recipes = await this.recipesService.GetAllByCreatorAsync<RecipeViewModel>(userId);
            var user = await this.userManager.FindByIdAsync(userId);
            this.ViewData["Title"] = string.Format(PageTitles.RecipeAllCreatedByPageTitle, user.UserName);

            return this.View(nameof(this.All), this.CreateListViewModel(recipes, id, itemsPerPage));
        }

        public async Task<IActionResult> AllMy(int id = 1)
        {
            int itemsPerPage = 9;
            var userId = this.userManager.GetUserId(this.User);
            var recipes = await this.recipesService.GetAllByUserAsync<RecipeViewModel>(userId);
            this.ViewData["Title"] = PageTitles.RecipeAllMyPageTitle;
            this.ViewData["Action"] = nameof(this.AllMy);
            return this.View(nameof(this.All), this.CreateListViewModel(recipes, id, itemsPerPage));
        }

        public async Task<IActionResult> Details(string id)
        {
            var recipe = await this.recipesService.GetByIdAsync<RecipeDetailsViewModel>(id);

            if (recipe == null)
            {
                return this.NotFound();
            }

            recipe.CookingVessels = await this.cookingVesselsService.GetAllCookingVesselsSelectListAsync();
            return this.View(recipe);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var recipe = await this.recipesService.GetByIdAsync<RecipeEditViewModel>(id);

            if (recipe == null)
            {
                return this.NotFound();
            }

            recipe.CategoriesCategoryId = await this.categoryRecipeService.GetAllCategoriesForRecipeAsync(id);
            recipe.CategoriesToSelect = await this.categoriesService.GetAllCategoriesSelectListAsync();
            recipe.IngredientsToSelect = await this.ingredientsService.GetAllIngredientsSelectListAsync();
            recipe.CookingVesselsToSelect = await this.cookingVesselsService.GetAllCookingVesselsSelectListAsync();

            return this.View(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RecipeEditViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                viewModel.CategoriesCategoryId = await this.categoryRecipeService.GetAllCategoriesForRecipeAsync(viewModel.Id);
                viewModel.CategoriesToSelect = await this.categoriesService.GetAllCategoriesSelectListAsync();
                viewModel.IngredientsToSelect = await this.ingredientsService.GetAllIngredientsSelectListAsync();
                viewModel.CookingVesselsToSelect = await this.cookingVesselsService.GetAllCookingVesselsSelectListAsync();

                return this.View(viewModel);
            }

            var rootPath = this.webHostEnvironment.WebRootPath;
            await this.recipesService.EditAsync(viewModel, rootPath);

            return this.RedirectToAction(nameof(this.Details), new { id = viewModel.Id });
        }

        public async Task<IActionResult> Delete(string id)
        {
            var recipe = await this.recipesService.GetByIdAsync<RecipeDeleteViewModel>(id);

            if (recipe == null)
            {
                return this.NotFound();
            }

            return this.View(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RecipeDeleteViewModel viewModel)
        {
            await this.recipesService.DeleteAsync(viewModel.Id);

            return this.RedirectToAction(nameof(this.All));
        }

        private RecipesListViewModel CreateListViewModel(IEnumerable<RecipeViewModel> recipes, int id, int itemsPerPage)
        {
            return new RecipesListViewModel
            {
                Recipes = recipes
                        .Skip((id - 1) * itemsPerPage)
                        .Take(itemsPerPage),
                CurrentPage = id,
                ItemsCount = recipes.Count(),
                ItemsPerPage = itemsPerPage,
            };
        }
    }
}
