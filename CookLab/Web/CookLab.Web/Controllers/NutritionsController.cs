namespace CookLab.Web.Controllers
{
    using System.Threading.Tasks;

    using CookLab.Models.InputModels.Nutritions;
    using CookLab.Models.ViewModels.Ingredients;
    using CookLab.Services.Data;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class NutritionsController : BaseController
    {
        private readonly INutritionsService nutritionsService;
        private readonly IIngredientsService ingredientsService;

        public NutritionsController(
            INutritionsService nutritionsService,
            IIngredientsService ingredientsService)
        {
            this.nutritionsService = nutritionsService;
            this.ingredientsService = ingredientsService;
        }

        public async Task<IActionResult> Create(string id)
        {
            var ingredient = await this.ingredientsService.GetByIdAsync<IngredientViewModel>(id);
            var nutrition = new NutritionInputModel();
            nutrition.IngredientId = id;
            nutrition.Ingredient = ingredient;

            return this.View(nutrition);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NutritionInputModel inputModel, string id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var ingredient = await this.ingredientsService.GetByIdAsync<IngredientViewModel>(id);

            if (ingredient.NutritionPer100Grams == null)
            {
                await this.nutritionsService.AddNutritionToIngredientAsync(inputModel);
            }

            return this.RedirectToAction(nameof(IngredientsController.Details), new { id = id });
        }
    }
}
