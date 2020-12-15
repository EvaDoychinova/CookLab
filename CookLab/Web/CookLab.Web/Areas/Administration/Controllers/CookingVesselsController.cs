namespace CookLab.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using CookLab.Models.ViewModels.CookingVessels;
    using CookLab.Services.Data;

    using Microsoft.AspNetCore.Mvc;

    public class CookingVesselsController : AdministrationController
    {
        private readonly ICookingVesselsService cookingVesselsService;

        public CookingVesselsController(ICookingVesselsService cookingVesselsService)
        {
            this.cookingVesselsService = cookingVesselsService;
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cookingVessel = await this.cookingVesselsService.GetByIdAsync<CookingVesselDeleteViewModel>(id);

            if (cookingVessel == null)
            {
                return this.NotFound();
            }

            return this.View(cookingVessel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CookingVesselDeleteViewModel viewModel)
        {
            await this.cookingVesselsService.DeleteAsync(viewModel.Id);
            return this.RedirectToAction(nameof(Web.Controllers.CookingVesselsController.All), new { area = string.Empty });
        }
    }
}
