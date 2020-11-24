namespace CookLab.Web.Controllers
{
    using CookLab.Services.Data;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class UserRecipesController : BaseController
    {
        private readonly IUserRecipesService portionsService;

        public UserRecipesController(IUserRecipesService userRecipesService)
        {
            this.portionsService = portionsService;
        }

        //[HttpPost]
        //public ActionResult AddToMyRecipes()
        //{
            
        //}
    }
}
