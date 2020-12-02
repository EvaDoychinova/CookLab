namespace CookLab.Web.Controllers
{
    using System.Linq;
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

        public async Task<IActionResult> All(int id = 1)
        {
            int itemsPerPage = 12;
            var categories = await this.categoriesService.GetAllAsync<CategoryViewModel>();

            var viewModel = new CategoriesListViewModel
            {
                Categories = categories
                            .Skip((id - 1) * itemsPerPage)
                            .Take(itemsPerPage),
                CurrentPage = id,
                ItemsCount = categories.Count(),
                ItemsPerPage = itemsPerPage,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var category = await this.categoriesService.GetByIdAsync<CategoryViewModel>(id);

            if (category == null)
            {
                return this.NotFound();
            }

            return this.View(category);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await this.categoriesService.GetByIdAsync<CategoryEditViewModel>(id);

            if (category == null)
            {
                return this.NotFound();
            }

            return this.View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            var rootPath = this.webHostEnvironment.WebRootPath;
            await this.categoriesService.EditAsync(viewModel, rootPath);
            return this.RedirectToAction(nameof(this.Details), new { id = viewModel.Id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var category = await this.categoriesService.GetByIdAsync<CategoryDeleteViewModel>(id);

            if (category == null)
            {
                return this.NotFound();
            }

            return this.View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CategoryDeleteViewModel viewModel)
        {
            await this.categoriesService.DeleteAsync(viewModel.Id);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
