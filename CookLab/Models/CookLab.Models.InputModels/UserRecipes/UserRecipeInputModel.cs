namespace CookLab.Models.InputModels.UserRecipes
{
    using System.ComponentModel.DataAnnotations;

    public class UserRecipeInputModel
    {
        [Required]
        public string RecipeId { get; set; }

        public bool IsInList { get; set; }
    }
}
