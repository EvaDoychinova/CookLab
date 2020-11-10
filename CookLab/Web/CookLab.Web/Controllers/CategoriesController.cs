namespace CookLab.Web.Controllers
{
    using System.IO;
    using System.Threading.Tasks;

    using CookLab.Models.InputModels.Categories;
    using CookLab.Models.ViewModels.Categories;
    using CookLab.Services.Data;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CategoriesController(
            ICategoriesService categoriesService,
            IWebHostEnvironment webHostEnvironment)
        {
            this.categoriesService = categoriesService;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var rootPath = this.webHostEnvironment.WebRootPath;

            await this.categoriesService.CreateAsync(inputModel, rootPath);

            return this.RedirectToAction(nameof(this.All));
        }

        public async Task<IActionResult> All()
        {
            var categories = await this.categoriesService.GetAllAsync<CategoryViewModel>();

            var viewModel = new CategoriesListViewModel
            {
                Categories = categories,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var category = await this.categoriesService.GetByIdAsync<CategoryViewModel>(id);

            return this.View(category);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await this.categoriesService.GetByIdAsync<CategoryViewModel>(id);

            return this.View(category);
        }

        [HttpPost(nameof(Edit))]
        public async Task<IActionResult> Edit(CategoryViewModel viewModel)
        {
            var category = await this.categoriesService.GetByIdAsync<CategoryViewModel>(viewModel.Id);
            await this.categoriesService.EditAsync(category);

            return this.RedirectToAction(nameof(this.Details), viewModel.Id);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.categoriesService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
