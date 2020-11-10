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
            string imagePath = this.webHostEnvironment.WebRootPath + $"/assets/img/categories/{inputModel.Name}.jpg";

            using (FileStream stream = new FileStream(imagePath, FileMode.Create))
            {
                await inputModel.Image.CopyToAsync(stream);
            }

            var imageUrl = $"{inputModel.Name.ToLower()}.jpg";

            await this.categoriesService.CreateAsync(inputModel.Name, imageUrl);

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
