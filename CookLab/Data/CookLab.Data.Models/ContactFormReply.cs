namespace CookLab.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using CookLab.Data.Common.Models;

    using static CookLab.Common.ModelsValidations.ContactsValidations;

    public class ContactFormReply : BaseModel<int>
    {
        [ForeignKey(nameof(ContactForm))]
        public int ContactFormId { get; set; }

        public virtual ContactForm ContactForm { get; set; }

        [Required]
        [MaxLength(MessageMaxLength)]
        public string ReplyMessage { get; set; }
    }
}
