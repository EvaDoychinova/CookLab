namespace CookLab.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CookingVesselsController : BaseController
    {
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
