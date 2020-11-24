namespace CookLab.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum IngredientPartOfRecipe
    {
        All = 0,
        Base = 1,
        [Display(Name = "Cream 1")]
        Cream1 = 2,
        [Display(Name = "Cream 2")]
        Cream2 = 3,
        [Display(Name = "Cream 3")]
        Cream3 = 4,
        Topping = 5,
        Dough = 6,
        Filling = 7,
        Sauce = 8,
    }
}
