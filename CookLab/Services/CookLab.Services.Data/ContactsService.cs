namespace CookLab.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Common;
    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.InputModels.ContactForms;
    using CookLab.Services.Mapping;
    using CookLab.Services.Messaging;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class ContactsService : IContactsService
    {
        private readonly IRepository<ContactForm> contactsRepository;
        private readonly IRepository<ContactFormReply> contactsRepliesRepository;
        private readonly IEmailSender emailSender;

        public ContactsService(
            IRepository<ContactForm> contactsRepository,
            IRepository<ContactFormReply> contactsRepliesRepository,
            IEmailSender emailSender)
        {
            this.contactsRepository = contactsRepository;
            this.contactsRepliesRepository = contactsRepliesRepository;
            this.emailSender = emailSender;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var contacts = await this.contactsRepository.AllAsNoTracking()
               .Where(x => x.IsAnswered == false)
               .OrderBy(x => x.CreatedOn)
               .To<T>()
               .ToListAsync();

            return contacts;
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var contact = await this.contactsRepository.AllAsNoTracking()
               .Where(x => x.Id == id && x.IsAnswered == false)
               .To<T>()
               .FirstOrDefaultAsync();

            return contact;
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

            await this.emailSender.SendEmailAsync(
                contactForm.Email,
                contactForm.Name,
                GlobalConstants.AdinistratorEmail,
                contactForm.Title,
                contactForm.Message);
        }

        public async Task SendEmailToUserAsync(ContactFormReplyInputModel inputModel)
        {
            var contactFormReply = new ContactFormReply
            {
                ReplyMessage = inputModel.ReplyMessage,
                ContactFormId = inputModel.ContactForm.Id,
            };

            var contactFormToAnswer = this.contactsRepository.All()
                .FirstOrDefault(x => x.Id == inputModel.ContactForm.Id);

            if (contactFormToAnswer == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.ContactFormMissing, inputModel.ContactForm.Id));
            }

            contactFormToAnswer.IsAnswered = true;

            this.contactsRepository.Update(contactFormToAnswer);
            await this.contactsRepliesRepository.AddAsync(contactFormReply);
            await this.contactsRepliesRepository.SaveChangesAsync();
            await this.contactsRepository.SaveChangesAsync();

            await this.emailSender.SendEmailAsync(
                GlobalConstants.AdinistratorEmail,
                GlobalConstants.SystemName,
                inputModel.ContactForm.Email,
                inputModel.ContactForm.Title,
                inputModel.ReplyMessage);
        }
        //public async Task<IEnumerable<SelectListItem>> GetAllContactsSelectListAsync()
        //{
        //    var contacts = await this.contactsRepository.AllAsNoTracking()
        //            .Where(x => x.IsAnswered == false)
        //            .OrderBy(x => x.CreatedOn)
        //            .Select(x => new SelectListItem(x.Title, x.Id.ToString()))
        //            .ToListAsync();

        //    return contacts;
        //}
    }
}
