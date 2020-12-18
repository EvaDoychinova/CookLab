namespace CookLab.Models.InputModels.ContactForms
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CookLab.Models.ViewModels.ContactForms;

    using Microsoft.AspNetCore.Mvc.Rendering;

    using static CookLab.Common.ModelsValidations.ContactsValidations;

    public class ContactFormReplyInputModel
    {
        public int Id { get; set; }

        public ContactFormViewModel ContactForm { get; set; }

        [Required]
        [MaxLength(MessageMaxLength)]
        public string ReplyMessage { get; set; }
    }
}
