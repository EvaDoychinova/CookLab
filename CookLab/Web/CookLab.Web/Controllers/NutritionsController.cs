namespace CookLab.Web.Controllers
{
    using CookLab.Services.Data;

    public class NutritionsController : BaseController
    {
        private readonly INutritionsService nutritionsService;

        public NutritionsController(INutritionsService nutritionsService)
        {
            this.nutritionsService = nutritionsService;
        }
    }
}
