namespace CookLab.Web.Controllers
{
    using CookLab.Common;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class IngredientController : BaseController
    {
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            return this.View();
        }

        public IActionResult All()
        {
            return this.View();
        }
    }
}
