namespace CookLab.Common
{
    public static class ExceptionMessages
    {
        public const string CategoryAlreadyExists = "Category with name {0} already exists";
        public const string CategoryMissing = "Category with id {0} does not exist";

        public const string IngredientAlreadyExists = "Ingredient with name {0} already exists";
        public const string IngredientMissing = "Ingredient with id {0} does not exist";

        public const string CookingVesselAlreadyExists = "Cooking vessel with name {0} already exists";
        public const string CookingVesselMissing = "Cooking vessel with id {0} does not exist";

        public const string RecipeAlreadyExists = "Recipe with name {0} already exists";
        public const string RecipeMissing = "Recipe with id {0} does not exist";
        public const string RecipeIncorrect = "Recipe with name {0} was not created correctly";

        public const string ContactFormAlreadyExists = "Contact form with this information already exists";
    }
}
