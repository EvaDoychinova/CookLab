namespace CookLab.Web.Infrastructure.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using CookLab.Common;

    using Microsoft.AspNetCore.Http;

    using static CookLab.Common.ErrorMessages;

    public class AllowedImageExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] allowedExtensions = GlobalConstants.AllowedImageExtensions;
        private string errorMessage = ImageAllowedExtensionsError;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IFormFile file = value as IFormFile;

            if (file != null)
            {
                if (!this.allowedExtensions.Any(x => file.Name.EndsWith(x)))
                {
                    return new ValidationResult(this.errorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
