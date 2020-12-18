namespace CookLab.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Common;
    using CookLab.Models.InputModels.ContactForms;
    using CookLab.Models.ViewModels.ContactForms;
    using CookLab.Services.Data;

    using Microsoft.AspNetCore.Mvc;

    public class ContactsController : AdministrationController
    {
        private readonly IContactsService contactsService;

        public ContactsController(IContactsService contactsService)
        {
            this.contactsService = contactsService;
        }

        public async Task<IActionResult> Reply(int id)
        {
            var contactToAnswer = await this.contactsService.GetByIdAsync<ContactFormViewModel>(id);
            var viewModel = new ContactFormReplyInputModel
            {
                ContactForm = contactToAnswer,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Reply(ContactFormReplyInputModel inputModel)
        {
            var contactToAnswer = await this.contactsService.GetByIdAsync<ContactFormViewModel>(inputModel.Id);

            if (!this.ModelState.IsValid)
            {
                inputModel.ContactForm = contactToAnswer;
                return this.View(inputModel);
            }

            inputModel.ContactForm = contactToAnswer;
            await this.contactsService.SendEmailToUserAsync(inputModel);

            this.TempData[GlobalConstants.RedirectedFromContactsReplyForm] = true;
            return this.RedirectToAction(nameof(this.Success));
        }

        public async Task<IActionResult> All(int id = 1)
        {
            int itemsPerPage = 17;
            var contacts = await this.contactsService.GetAllAsync<ContactFormAllViewModel>();
            var viewModel = new ContactFormsListViewModel
            {
                ContactForms = contacts
                                .Skip((id - 1) * itemsPerPage)
                                .Take(itemsPerPage),
                CurrentPage = id,
                ItemsCount = contacts.Count(),
                ItemsPerPage = itemsPerPage,
            };
            this.ViewData["Action"] = nameof(this.All);
            return this.View(viewModel);
        }

        public IActionResult Success()
        {
            if (this.TempData[GlobalConstants.RedirectedFromContactsReplyForm] == null)
            {
                return this.NotFound();
            }

            return this.View();
        }
    }
}
