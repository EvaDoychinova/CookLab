namespace CookLab.Web.Areas.Administration.Controllers
{
    using CookLab.Models.ViewModels.Administration.Dashboard;
    using CookLab.Services.Data;

    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        public DashboardController()
        {
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel {};
            return this.View(viewModel);
        }
    }
}
