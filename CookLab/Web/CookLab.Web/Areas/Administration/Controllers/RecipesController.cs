namespace CookLab.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using CookLab.Data.Models;
    using CookLab.Models.ViewModels.Recipes;
    using CookLab.Services.Data;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class RecipesController : AdministrationController
    {
        private readonly IRecipesService recipesService;
        private readonly ICategoriesService categoriesService;
        private readonly IIngredientsService ingredientsService;
        private readonly ICookingVesselsService cookingVesselsService;
        private readonly ICategoryRecipesService categoryRecipeService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public RecipesController(
            IRecipesService recipesService,
            ICategoriesService categoriesService,
            IIngredientsService ingredientsService,
            ICookingVesselsService cookingVesselsService,
            ICategoryRecipesService categoryRecipeService,
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

            return this.RedirectToAction(nameof(Web.Controllers.RecipesController.Details), new { id = viewModel.Id });
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

            return this.RedirectToAction(nameof(Web.Controllers.RecipesController.All));
        }
    }
}
