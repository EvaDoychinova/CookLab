namespace CookLab.Common
{
    public static class ErrorMessages
    {
        public const string RequiredInputFieldError = "Please enter the {0} field!";
        public const string RequiredSelectFiledError = "Please select {0}";

        public const string StringLengthError = "{0} should be between {2} and {1} characters";

        public const string InvalidRangeError = "Value for {0} must be between {1} and {2}.";
        public const string InvalidEnumRangeError = "Invalid selection. Please choose one of the given options";

        public const string ImageAllowedExtensionsError = "This photo extension is not allowed!";
        public const string ImageMaxSizeError = "Image allowed size is {0} MB.";
    }
}
