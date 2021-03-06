﻿namespace CookLab.Services.Data
{
    using System.Threading.Tasks;

    using CookLab.Models.InputModels.Nutritions;
    using CookLab.Models.ViewModels.Nutritions;

    public interface INutritionsService
    {
        Task<string> AddNutritionToIngredientAsync(NutritionInputModel inputModel);

        Task CalculateNutritionForRecipeAsync(string recipeId);
    }
}
