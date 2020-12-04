namespace CookLab.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CookLab.Data.Common.Models;

    using static CookLab.Common.ModelsValidations.ContactsValidations;

    public class ContactForm : BaseDeletableModel<string>
    {
        public ContactForm()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(MessageMaxLength)]
        public string Message { get; set; }

        //[Required]
        //[MaxLength(IpAddressMaxLength)]
        //public string IpAddress { get; set; }
    }
}
