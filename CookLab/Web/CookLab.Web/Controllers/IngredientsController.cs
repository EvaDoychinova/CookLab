namespace CookLab.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Models.InputModels.Ingredients;
    using CookLab.Models.ViewModels.Ingredients;
    using CookLab.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class IngredientsController : BaseController
    {
        private readonly IIngredientsService ingredientsService;

        public IngredientsController(IIngredientsService ingredientsService)
        {
            this.ingredientsService = ingredientsService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IngredientInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.ingredientsService.CreateAsync(inputModel);
            return this.RedirectToAction(nameof(this.All));
        }

        public async Task<IActionResult> All()
        {
            var ingredients = await this.ingredientsService.GetAllAsync<IngredientViewModel>();

            var viewModel = new IngredinetsListViewModel
            {
                Ingredients = ingredients,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(string id)
        {

            return this.View();
        }

        public async Task<IActionResult> Edit(string id)
        {
            var ingredient = await this.ingredientsService.GetByIdAsync<IngredientEditViewModel>(id);

            return this.View(ingredient);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IngredientEditViewModel viewModel)
        {


            return this.RedirectToAction(nameof(this.Details));
        }
    }
}
