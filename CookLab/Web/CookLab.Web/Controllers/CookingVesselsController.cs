namespace CookLab.Web.Controllers
{
    using System.Threading.Tasks;

    using CookLab.Models.InputModels.CookingVessel;
    using CookLab.Models.ViewModels.CookingVessels;
    using CookLab.Services.Data;

    using Microsoft.AspNetCore.Mvc;

    public class CookingVesselsController : BaseController
    {
        private readonly ICookingVesselsService cookingVesselsService;

        public CookingVesselsController(ICookingVesselsService cookingVesselsService)
        {
            this.cookingVesselsService = cookingVesselsService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CookingVesselInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var cookingVessel = await this.cookingVesselsService.CreateAsync(inputModel);

            return this.RedirectToAction(nameof(this.All));
        }

        public async Task<IActionResult> All()
        {
            var cookingVessels = await this.cookingVesselsService.GetAllAsync<CookingVesselViewModel>();

            var viewModel = new CookingVesselsListViewModel
            {
                CookingVessels = cookingVessels,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var cookingVessel = await this.cookingVesselsService.GetByIdAsync<CookingVesselViewModel>(id);

            return this.View(cookingVessel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cookingVessel = await this.cookingVesselsService.GetByIdAsync<CookingVesselDeleteViewModel>(id);

            return this.View(cookingVessel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CookingVesselDeleteViewModel viewModel)
        {
            await this.cookingVesselsService.DeleteAsync(viewModel.Id);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
