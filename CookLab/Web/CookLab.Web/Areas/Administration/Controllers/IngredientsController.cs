namespace CookLab.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using CookLab.Models.ViewModels.Ingredients;
    using CookLab.Services.Data;

    using Microsoft.AspNetCore.Mvc;

    public class IngredientsController : AdministrationController
    {
        private readonly IIngredientsService ingredientsService;

        public IngredientsController(IIngredientsService ingredientsService)
        {
            this.ingredientsService = ingredientsService;
        }

        public async Task<IActionResult> Edit(string id)
        {
            var ingredient = await this.ingredientsService.GetByIdAsync<IngredientEditViewModel>(id);

            if (ingredient == null)
            {
                return this.NotFound();
            }

            return this.View(ingredient);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IngredientEditViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            await this.ingredientsService.EditAsync(viewModel);
            return this.RedirectToAction(nameof(Web.Controllers.IngredientsController.Details), new { id = viewModel.Id });
        }

        public async Task<IActionResult> Delete(string id)
        {
            var ingredient = await this.ingredientsService.GetByIdAsync<IngredientDeleteViewModel>(id);

            if (ingredient == null)
            {
                return this.NotFound();
            }

            return this.View(ingredient);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(IngredientDeleteViewModel viewModel)
        {
            await this.ingredientsService.DeleteAsync(viewModel.Id);
            return this.RedirectToAction(nameof(Web.Controllers.IngredientsController.All));
        }
    }
}
