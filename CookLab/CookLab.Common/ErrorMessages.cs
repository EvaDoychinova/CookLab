namespace CookLab.Common
{
    public static class ErrorMessages
    {
        public const string RequiredFieldError = "Please enter the required field!";

        public const string StringLengthError = "{0} should be between {2} and {1} characters";

        public const string InvalidRangeError = "Value for {0} must be between {1} and {2}.";

        public const string ImageAllowedExtensionsError = "This photo extension is not allowed!";
        public const string ImageMaxSizeError = "Image allowed size is {0} MB.";
    }
}
