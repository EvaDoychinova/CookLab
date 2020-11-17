namespace CookLab.Web.Infrastructure.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CookLab.Data.Models.Enums;

    using static CookLab.Common.ErrorMessages;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
    public class RequiredFormAttribute : RequiredAttribute
    {
        private readonly string errorMessage = RequiredFieldError;
        private readonly PanForm requiredForm;
        private readonly string givenForm;

        public RequiredFormAttribute(PanForm requiredForm, string givenForm)
        {
            this.requiredForm = requiredForm;
            this.givenForm = givenForm;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var form = validationContext.ObjectType.GetProperty(this.givenForm);
            var formValue = form.GetValue(validationContext.ObjectInstance, null);
            var formValueAsString = formValue.ToString();

            if (value == null && this.requiredForm.ToString() == formValueAsString)
            {
                return new ValidationResult(this.errorMessage);
            }

            var stringValue = value as string;
            if (stringValue != null && !this.AllowEmptyStrings)
            {
                var isValid = stringValue.Trim().Length != 0;

                if (!isValid)
                {
                    return new ValidationResult(this.errorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
