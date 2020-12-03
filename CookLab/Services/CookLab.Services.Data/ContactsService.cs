namespace CookLab.Services.Data
{
    using System.Threading.Tasks;

    using CookLab.Common;
    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.InputModels.ContactForms;
    using CookLab.Services.Messaging;

    public class ContactsService : IContactsService
    {
        private readonly IDeletableEntityRepository<ContactForm> contactsRepository;
        private readonly IEmailSender emailSender;

        public ContactsService(
            IDeletableEntityRepository<ContactForm> contactsRepository,
            IEmailSender emailSender)
        {
            this.contactsRepository = contactsRepository;
            this.emailSender = emailSender;
        }

        public async Task SendEmailToAdminAsync(ContactFormInputModel inputModel, string ipAddress)
        {
            var contactForm = new ContactForm
            {
                Name = inputModel.Name,
                Email = inputModel.Email,
                Title = inputModel.Title,
                Message = inputModel.Message,
                Id = ipAddress,
            };

            await this.contactsRepository.AddAsync(contactForm);
            await this.contactsRepository.SaveChangesAsync();

            await this.emailSender.SendEmailAsync(
                contactForm.Email,
                contactForm.Name,
                GlobalConstants.AdinistratorEmail,
                contactForm.Title,
                contactForm.Message);
        }
    }
}
