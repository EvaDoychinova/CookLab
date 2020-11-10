namespace CookLab.Web.Infrastructure.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;

    using Microsoft.AspNetCore.Http;

    using static CookLab.Common.ErrorMessages;
    using static CookLab.Common.ModelsValidations;

    public class AllowedImageExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] allowedExtensions = AllowedImageExtensions;
        private string errorMessage = ImageAllowedExtensionsError;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IFormFile file = value as IFormFile;

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName).ToLower();

                if (!this.allowedExtensions.Contains(extension))
                {
                    return new ValidationResult(this.errorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
