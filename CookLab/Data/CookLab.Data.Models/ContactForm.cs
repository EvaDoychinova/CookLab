namespace CookLab.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using CookLab.Data.Common.Models;

    using static CookLab.Common.ModelsValidations.ContactsValidations;

    public class ContactForm : BaseModel<int>
    {
        public ContactForm()
        {
            this.IsAnswered = false;
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

        public bool IsAnswered { get; set; }
    }
}
