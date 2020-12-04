namespace CookLab.Web.Controllers
{
    using System.Threading.Tasks;

    using CookLab.Common;
    using CookLab.Models.InputModels.ContactForms;
    using CookLab.Services.Data;

    using Microsoft.AspNetCore.Mvc;

    public class ContactsController : BaseController
    {
        private readonly IContactsService contactsService;

        public ContactsController(IContactsService contactsService)
        {
            this.contactsService = contactsService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactFormInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.contactsService.SendEmailToAdminAsync(inputModel);

            this.TempData[GlobalConstants.RedirectedFromContactForm] = true;
            return this.RedirectToAction(nameof(this.ThankYou));
        }

        public IActionResult ThankYou()
        {
            if (this.TempData[GlobalConstants.RedirectedFromContactForm] == null)
            {
                return this.NotFound();
            }

            return this.View();
        }
    }
}
