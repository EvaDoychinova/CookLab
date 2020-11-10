namespace CookLab.Web.Areas.Administration.Controllers
{
    using CookLab.Common;
    using CookLab.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area(GlobalConstants.AdministrationAreaName)]
    public class AdministrationController : BaseController
    {
    }
}
