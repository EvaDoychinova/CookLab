namespace CookLab.Models.InputModels.ContactForms
{
    using System.ComponentModel.DataAnnotations;

    using CookLab.Web.Infrastructure.Attributes;

    using static CookLab.Common.DisplayNames.ContactsDisplayNames;
    using static CookLab.Common.ErrorMessages;
    using static CookLab.Common.ModelsValidations.ContactsValidations;

    public class ContactFormInputModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = StringLengthError)]
        [Display(Name = NameDisplayName)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = EmailDisplayName)]
        public string Email { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = StringLengthError)]
        [Display(Name = TitleDisplayName)]
        public string Title { get; set; }

        [Required]
        [StringLength(MessageMaxLength, MinimumLength = MessageMinLength, ErrorMessage = StringLengthError)]
        [Display(Name = MessageDisplayName)]
        public string Message { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
