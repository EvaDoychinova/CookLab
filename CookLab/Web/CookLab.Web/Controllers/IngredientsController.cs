namespace CookLab.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Models.InputModels.Ingredients;
    using CookLab.Models.ViewModels.Ingredients;
    using CookLab.Services.Data;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class IngredientsController : BaseController
    {
        private readonly IIngredientsService ingredientsService;

        public IngredientsController(IIngredientsService ingredientsService)
        {
            this.ingredientsService = ingredientsService;
        }

        [Authorize]
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

        public async Task<IActionResult> All(int id = 1)
        {
            var itemsPerPage = 15;
            var ingredients = await this.ingredientsService.GetAllAsync<IngredientViewModel>();

            var viewModel = new IngredientsListViewModel
            {
                Ingredients = ingredients
                            .Skip((id - 1) * itemsPerPage)
                            .Take(itemsPerPage),
                CurrentPage = id,
                ItemsCount = ingredients.Count(),
                ItemsPerPage = itemsPerPage,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(string id)
        {
            var ingredient = await this.ingredientsService.GetByIdAsync<IngredientViewModel>(id);

            if (ingredient == null)
            {
                return this.NotFound();
            }

            return this.View(ingredient);
        }
    }
}
