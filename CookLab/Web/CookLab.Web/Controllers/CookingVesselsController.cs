namespace CookLab.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Models.InputModels.CookingVessel;
    using CookLab.Models.ViewModels.CookingVessels;
    using CookLab.Services.Data;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CookingVesselsController : BaseController
    {
        private readonly ICookingVesselsService cookingVesselsService;

        public CookingVesselsController(ICookingVesselsService cookingVesselsService)
        {
            this.cookingVesselsService = cookingVesselsService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
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

        public async Task<IActionResult> All(int id = 1)
        {
            int itemsPerPage = 17;
            var cookingVessels = await this.cookingVesselsService.GetAllAsync<CookingVesselViewModel>();

            var viewModel = new CookingVesselsListViewModel
            {
                CookingVessels = cookingVessels
                                .Skip((id - 1) * itemsPerPage)
                                .Take(itemsPerPage),
                CurrentPage = id,
                ItemsCount = cookingVessels.Count(),
                ItemsPerPage = itemsPerPage,
            };
            this.ViewData["Action"] = nameof(this.All);
            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var cookingVessel = await this.cookingVesselsService.GetByIdAsync<CookingVesselViewModel>(id);

            if (cookingVessel == null)
            {
                return this.NotFound();
            }

            return this.View(cookingVessel);
        }
    }
}
