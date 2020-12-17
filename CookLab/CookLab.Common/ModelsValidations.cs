namespace CookLab.Common
{
    using System;
    using System.Globalization;
    using System.Linq.Expressions;

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
            public const double VolumeMaxValue = 500;
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
            public const int FormMinValue = 1;
            public const int FormMaxValue = 5;

            public const int FormsCountMinValue = 1;
            public const int FormsCountMaxValue = 20;

            public const int NameMinValue = 3;
            public const int NameMaxValue = 20;
            public const int DatabaseNameMaxValue = 40;

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

            public const int MinPreparationTimeInMinutes = 5;
            public const int MaxPreparationTimeInMinutes = 2 * 24 * 60;

            public const string MinPreparationTime = "00:05:00";
            public const string MaxPreparationTime = "48:00:00";

            public const int MinCookingTimeInMinutes = 5;
            public const int MaxCookingTimeInMinutes = 2 * 24 * 60;

            public const string MinCookingTime = "00:05:00";
            public const string MaxCookingTime = "48:00:00";

            public const int PortionsMinValue = 1;
            public const int PortionsMaxValue = 100;

            public const int PreparationMinLength = 20;
            public const int PreparationMaxLength = int.MaxValue;

            public const int NotesMinLength = 0;
            public const int NotesMaxLength = int.MaxValue;

            public const int ImageFileMaxSize = 2;
        }

        public static class RecipesIngredientsValidations
        {
            public const double WeightMinValue = 0.5;
            public const double WeightMaxValue = 10 * 1000;

            public const int PartOfRecipeMinValue = 0;
            public const int PartOfRecipeMaxValue = 8;
        }

        public static class ContactsValidations
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;

            public const int EmailMaxLength = 100;

            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 100;

            public const int MessageMinLength = 5;
            public const int MessageMaxLength = int.MaxValue;

            public const int IpAddressMinLength = (4 * 1) + 3;
            public const int IpAddressMaxLength = (8 * 4) + 7;
        }
    }
}
