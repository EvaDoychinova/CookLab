namespace CookLab.Common
{
    public static class ModelsValidations
    {
        public static readonly string[] AllowedImageExtensions = { ".jpg", ".png", ".jpeg", ".gif" };

        public static class CategoriesValidations
        {
            public const int NameMinValue = 4;
            public const int NameMaxValue = 30;

            public const int ImageFileMaxSize = 2;
        }

        public static class IngredientsValidations
        {
            public const int NameMinValue = 3;
            public const int NameMaxValue = 30;

            public const double VolumeMinValue = 10;
            public const double VolumeMaxValue = 200;
        }

        public static class NutritionsValidations
        {
            public const double CaloriesMinValue = 0;
            public const double CaloriesMaxValue = 1000;

            public const double CarbohydratesMinValue = 0;
            public const double CarbohydratesMaxValue = 100;

            public const double FatsMinValue = 0;
            public const double FatsMaxValue = 100;

            public const double ProteinsMinValue = 0;
            public const double ProteinsMaxValue = 100;

            public const double FibresMinValue = 0;
            public const double FibresMaxValue = 100;
        }
    }
}
