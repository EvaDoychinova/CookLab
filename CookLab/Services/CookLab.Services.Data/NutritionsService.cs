﻿namespace CookLab.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Common;
    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.InputModels.Nutritions;
    using CookLab.Services.Mapping;

    using Microsoft.EntityFrameworkCore;

    public class NutritionsService : INutritionsService
    {
        private readonly IDeletableEntityRepository<Nutrition> nutritionRepository;
        private readonly IDeletableEntityRepository<Ingredient> ingredientRepository;
        private readonly IDeletableEntityRepository<RecipeIngredient> recipeIngredientsRepository;
        private readonly IDeletableEntityRepository<Recipe> recipeRepository;

        public NutritionsService(
            IDeletableEntityRepository<Nutrition> nutritionRepository,
            IDeletableEntityRepository<Ingredient> ingredientRepository,
            IDeletableEntityRepository<RecipeIngredient> recipeIngredientsRepository,
            IDeletableEntityRepository<Recipe> recipeRepository)
        {
            this.nutritionRepository = nutritionRepository;
            this.ingredientRepository = ingredientRepository;
            this.recipeIngredientsRepository = recipeIngredientsRepository;
            this.recipeRepository = recipeRepository;
        }

        public async Task<string> AddNutritionToIngredientAsync(NutritionInputModel inputModel)
        {
            var nutrition = new Nutrition
            {
                Calories = inputModel.Calories,
                Carbohydrates = inputModel.Carbohydrates,
                Fats = inputModel.Fats,
                Proteins = inputModel.Proteins,
                Fibres = inputModel.Fibres,
                IngredientId = inputModel.IngredientId,
                RecipeId = null,
            };

            await this.nutritionRepository.AddAsync(nutrition);

            var ingredient = this.ingredientRepository.All()
                .Where(x => x.Id == inputModel.IngredientId)
                .FirstOrDefault();

            if (ingredient == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.IngredientMissing, inputModel.IngredientId));
            }

            ingredient.NutritionPer100Grams = nutrition;
            ingredient.ModifiedOn = DateTime.UtcNow;
            this.ingredientRepository.Update(ingredient);

            await this.nutritionRepository.SaveChangesAsync();
            await this.ingredientRepository.SaveChangesAsync();

            var recipes = await this.recipeRepository.All()
                .Where(x => x.Ingredients.Any(x => x.IngredientId == inputModel.IngredientId))
                .ToListAsync();

            if (recipes.Count > 0)
            {
                foreach (var recipe in recipes)
                {
                    await this.CalculateNutritionForRecipeAsync(recipe.Id);
                }
            }

            return nutrition.Id;
        }

        public async Task CalculateNutritionForRecipeAsync(string recipeId)
        {
            var recipe = this.recipeRepository.All()
                .FirstOrDefault(x => x.Id == recipeId);

            if (recipe is null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RecipeMissing, recipeId));
            }

            var recipeIngredients = await this.recipeIngredientsRepository.All()
                .Where(x => x.RecipeId == recipe.Id)
                .ToListAsync();

            if (!recipeIngredients.Any(x => this.nutritionRepository.All().FirstOrDefault(y => y.IngredientId == x.IngredientId) == null))
            {
                var initialNutrition = this.nutritionRepository.All()
                    .FirstOrDefault(x => x.RecipeId == recipeId);

                if (initialNutrition != null)
                {
                    initialNutrition.Calories = this.CalculateNutritionElementForWholeRecipe(recipeIngredients, "Calories");
                    initialNutrition.Carbohydrates = this.CalculateNutritionElementForWholeRecipe(recipeIngredients, "Carbohydrates");
                    initialNutrition.Fats = this.CalculateNutritionElementForWholeRecipe(recipeIngredients, "Fats");
                    initialNutrition.Proteins = this.CalculateNutritionElementForWholeRecipe(recipeIngredients, "Proteins");
                    initialNutrition.Fibres = this.CalculateNutritionElementForWholeRecipe(recipeIngredients, "Fibres");
                    initialNutrition.ModifiedOn = DateTime.UtcNow;

                    this.nutritionRepository.Update(initialNutrition);
                }
                else
                {
                    var newNutrition = new Nutrition
                    {
                        Calories = this.CalculateNutritionElementForWholeRecipe(recipeIngredients, "Calories"),
                        Carbohydrates = this.CalculateNutritionElementForWholeRecipe(recipeIngredients, "Carbohydrates"),
                        Fats = this.CalculateNutritionElementForWholeRecipe(recipeIngredients, "Fats"),
                        Proteins = this.CalculateNutritionElementForWholeRecipe(recipeIngredients, "Proteins"),
                        Fibres = this.CalculateNutritionElementForWholeRecipe(recipeIngredients, "Fibres"),
                        RecipeId = recipeId,
                        IngredientId = null,
                    };

                    await this.nutritionRepository.AddAsync(newNutrition);
                    recipe.Nutrition = newNutrition;
                }

                await this.nutritionRepository.SaveChangesAsync();
                this.recipeRepository.Update(recipe);
                await this.recipeRepository.SaveChangesAsync();
            }
        }

        private double CalculateNutritionElementForWholeRecipe(ICollection<RecipeIngredient> ingredients, string nutritionPart)
        {
            var nutritionElement = ingredients
                .Sum(x => x.WeightInGrams / 100 * (double)this.nutritionRepository.All().First(y => y.IngredientId == x.IngredientId)
                                                        .GetType().GetProperty(nutritionPart)
                                                        .GetValue(this.nutritionRepository.All().First(y => y.IngredientId == x.IngredientId)));

            return nutritionElement;
        }
    }
}
