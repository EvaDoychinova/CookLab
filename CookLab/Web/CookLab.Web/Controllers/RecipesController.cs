namespace CookLab.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class RecipesController : BaseController
    {
        public IActionResult Create()
        {
            return this.View();
        }

        public IActionResult All()
        {
            return this.View();
        }

        public IActionResult AllByCategory(string categoryId)
        {
            return this.View();
        }

        [Authorize]
        public IActionResult GetMy()
        {
            return this.View();
        }
    }
}
