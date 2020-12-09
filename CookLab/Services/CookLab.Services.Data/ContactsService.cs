namespace CookLab.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Common;
    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.InputModels.ContactForms;
    using CookLab.Services.Messaging;

    public class ContactsService : IContactsService
    {
        private readonly IDeletableEntityRepository<ContactForm> contactsRepository;
        //private readonly IEmailSender emailSender;

        public ContactsService(
            IDeletableEntityRepository<ContactForm> contactsRepository)
            /*IEmailSender emailSender*/
        {
            this.contactsRepository = contactsRepository;
            //this.emailSender = emailSender;
        }

        public async Task SendEmailToAdminAsync(ContactFormInputModel inputModel)
        {
            if (this.contactsRepository.All()
                .Any(
                x => x.Name == inputModel.Name &&
                x.Email == inputModel.Email &&
                x.Title == inputModel.Title &&
                x.Message == inputModel.Message))
            {
                throw new ArgumentException(ExceptionMessages.ContactFormAlreadyExists);
            }

            var contactForm = new ContactForm
            {
                Name = inputModel.Name,
                Email = inputModel.Email,
                Title = inputModel.Title,
                Message = inputModel.Message,
            };

            await this.contactsRepository.AddAsync(contactForm);
            await this.contactsRepository.SaveChangesAsync();

            //await this.emailSender.SendEmailAsync(
            //    GlobalConstants.AdinistratorEmail,
            //    contactForm.Name,
            //    contactForm.Email,
            //    contactForm.Title,
            //    contactForm.Message);
        }
    }
}
