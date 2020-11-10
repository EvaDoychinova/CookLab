namespace CookLab.Web.Infrastructure.Attributes
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    using static CookLab.Common.ErrorMessages;

    public class ImageMaxSizeAttribute : ValidationAttribute
    {
        private readonly string errorMessage = ImageMaxSizeError;
        private readonly int maxSizeInMB;

        public ImageMaxSizeAttribute(int maxSizeInMB)
        {
            this.maxSizeInMB = maxSizeInMB;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IFormFile file = value as IFormFile;

            if (file != null)
            {
                if (file.Length > this.maxSizeInMB * 1024 * 1024)
                {
                    return new ValidationResult(string.Format(this.errorMessage, this.maxSizeInMB));
                }
            }

            return ValidationResult.Success;
        }
    }
}
