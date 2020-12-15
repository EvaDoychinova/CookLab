namespace CookLab.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using CookLab.Models.ViewModels.Categories;
    using CookLab.Services.Data;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : AdministrationController
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
            return this.RedirectToAction(nameof(Web.Controllers.CategoriesController.All), new { area = string.Empty });
        }
    }
}
