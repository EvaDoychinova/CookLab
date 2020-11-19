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

        public static class CookingVesselValidations
        {
            public const int NameMinValue = 3;
            public const int NameMaxValue = 20;

            public const double DiameterMinValue = 1;
            public const double DiameterMaxValue = 100;

            public const double SideMinValue = 1;
            public const double SideMaxValue = 100;

            public const double HeightMinValue = 1;
            public const double HeightMaxValue = 50;

            public const double AreaMinValue = 2 * 2;
            public const double AreaMaxValue = 100 * 100;

            public const double VolumeMinValue = 20;
            public const double VolumeMaxValue = 10 * 1000;
        }

        public static class RecipesValidations
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;

            public const int MinPreparationTime = 5;
            public const int MaxPreparationTime = 2 * 24 * 60;

            public const int MinCookingTime = 5;
            public const int MaxCookingTime = 2 * 24 * 60;

            public const int PreparationMinLength = 20;
            public const int PreparationMaxLength = int.MaxValue;

            public const int ImageFileMaxSize = 2;
        }

        public static class RecipesIngredientsValidations
        {
            public const double WeightMinLength = 0.5;
            public const double WeightMaxLength = 10 * 1000;
        }
    }
}
