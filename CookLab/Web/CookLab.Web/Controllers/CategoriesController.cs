namespace CookLab.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Models.InputModels.Categories;
    using CookLab.Models.ViewModels.Categories;
    using CookLab.Services.Data;

    using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
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
            this.ViewData["Action"] = nameof(this.All);
            return this.View(viewModel);
        }
    }
}
