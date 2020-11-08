namespace CookLab.Web.Controllers
{
    using System.Threading.Tasks;

    using CookLab.Models.InputModels.Categories;
    using CookLab.Models.ViewModels.Categories;
    using CookLab.Services.Data;

    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryInputModel inputModel)
        {
            await this.categoriesService.CreateAsync(inputModel.Name, inputModel.ImageUrl);

            return this.Redirect("/Categories/All");
        }

        public IActionResult All()
        {
            var categories = this.categoriesService.GetAll<CategoryViewModel>();

            var viewModel = new CategoriesListViewModel
            {
                Categories = categories,
            };

            return this.View(viewModel);
        }
    }
}
