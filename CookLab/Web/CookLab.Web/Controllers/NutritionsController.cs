namespace CookLab.Web.Controllers
{
    using System.Threading.Tasks;
    using CookLab.Models.InputModels.Nutritions;
    using CookLab.Models.ViewModels.Ingredients;
    using CookLab.Models.ViewModels.Nutritions;
    using CookLab.Services.Data;
    using Microsoft.AspNetCore.Mvc;

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

            return this.View(ingredient);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NutritionInputModel inputModel, string id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var ingredient = await this.ingredientsService.GetByIdAsync<IngredientViewModel>(id);

            if (ingredient.Nutrition == null)
            {
                await this.nutritionsService.AddNutritionToIngredientAsync(ingredient.Id, inputModel);
            }

            return this.RedirectToAction("Details", "Ingredients", new { id = id });
        }

        public async Task<IActionResult> IngredientNutrition(string id)
        {
            var nutrition = await this.nutritionsService.ShowNutritionAsync<NutritionViewModel>(id,null);

            return this.View(nutrition);
        }

        public async Task<IActionResult> RecipeNutrition(string id)
        {
            var nutrition = await this.nutritionsService.ShowNutritionAsync<NutritionViewModel>(null, id);

            return this.View(nutrition);
        }
    }
}
