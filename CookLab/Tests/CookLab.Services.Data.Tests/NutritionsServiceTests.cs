namespace CookLab.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.InputModels.Nutritions;
    using CookLab.Services.Data.Tests.AsyncClasses;
    using Moq;

    using Xunit;

    public class NutritionsServiceTests
    {
        public const string TestNutritionId = "TestNutritionId";
        public const string TestIngredientId = "TestIngredientId";
        public const string TestRecipeId = "TestRecipeId";
        public const string TestRecipeName = "TestRecipeName";
        public const string TestingredientName = "TestIngredientName";

        [Fact]
        public async Task DoesAddNutritionToIngredientAsyncThrowsNullReferenceExceptionWhenNoSuchIngredient()
        {
            var nutritionList = new List<Nutrition>();

            var service = this.CreateMockAndConfigureService(
                nutritionList,
                new List<Ingredient>(),
                new List<RecipeIngredient>(),
                new List<Recipe>());

            var nutritionToAdd = new NutritionInputModel
            {
                Calories = 100,
                Carbohydrates = 100,
                Fats = 100,
                Proteins = 100,
                Fibres = 100,
                IngredientId = TestIngredientId,
            };

            await Assert.ThrowsAsync<NullReferenceException>(async () => await service.AddNutritionToIngredientAsync(nutritionToAdd));
        }

        [Fact]
        public async Task DoesAddNutritionToIngredientAsyncWorkCorrectlyWhenNoRecipeWithThisIngredient()
        {
            var nutritionList = new List<Nutrition>();

            var ingredientList = new List<Ingredient>
            {
                new Ingredient
                {
                    Id = TestIngredientId,
                    Name = TestingredientName,
                    VolumeInMlPer100Grams = 100,
                },
            };

            var service = this.CreateMockAndConfigureService(
                nutritionList,
                ingredientList,
                new List<RecipeIngredient>(),
                new List<Recipe>());

            var nutritionToAdd = new NutritionInputModel
            {
                Calories = 100,
                Carbohydrates = 100,
                Fats = 100,
                Proteins = 100,
                Fibres = 100,
                IngredientId = TestIngredientId,
            };

            await service.AddNutritionToIngredientAsync(nutritionToAdd);

            Assert.Equal(TestIngredientId, nutritionList.First().IngredientId);
        }

        [Fact]
        public async Task DoesAddNutritionToIngredientAsyncWorkCorrectlyWhenExistRecipeWithThisIngredient()
        {
            var nutritionList = new List<Nutrition>();

            var ingredientList = new List<Ingredient>
            {
                new Ingredient
                {
                    Id = TestIngredientId,
                    Name = TestingredientName,
                    VolumeInMlPer100Grams = 100,
                },
            };

            var recipeList = new List<Recipe>
            {
                new Recipe
                {
                    Id = TestRecipeId,
                    Name = TestRecipeName,
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            IngredientId = TestIngredientId,
                            RecipeId = TestRecipeId,
                            WeightInGrams = 100,
                        },
                    },
                },
            };

            var service = this.CreateMockAndConfigureService(
                nutritionList,
                ingredientList,
                new List<RecipeIngredient>(),
                recipeList);

            var nutritionToAdd = new NutritionInputModel
            {
                Calories = 100,
                Carbohydrates = 100,
                Fats = 100,
                Proteins = 100,
                Fibres = 100,
                IngredientId = TestIngredientId,
            };

            await service.AddNutritionToIngredientAsync(nutritionToAdd);

            Assert.Equal(2, nutritionList.Count());
        }

        [Fact]
        public async Task DoesCalculateNutritionForRecipeAsyncWorkCorrectly()
        {
            var nutritionList = new List<Nutrition>
            {
                new Nutrition
                {
                    Id = TestNutritionId,
                    Calories = 100,
                    Carbohydrates = 100,
                    Fats = 100,
                    Proteins = 100,
                    Fibres = 100,
                    IngredientId = TestIngredientId,
                },
            };

            var ingredientList = new List<Ingredient>
            {
                new Ingredient
                {
                    Id = TestIngredientId,
                    Name = TestingredientName,
                    VolumeInMlPer100Grams = 100,
                },
            };

            var recipeList = new List<Recipe>
            {
                new Recipe
                {
                    Id = TestRecipeId,
                    Name = TestRecipeName,
                    Ingredients = new HashSet<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            IngredientId = TestIngredientId,
                            RecipeId = TestRecipeId,
                            WeightInGrams = 100,
                        },
                    },
                },
            };

            var service = this.CreateMockAndConfigureService(
                nutritionList,
                ingredientList,
                new List<RecipeIngredient>(),
                recipeList);

            await service.CalculateNutritionForRecipeAsync(TestRecipeId);

            Assert.Equal(2, nutritionList.Count());
        }

        [Fact]
        public async Task DoesCalculateNutritionForRecipeAsyncThrowNullReferenceExceptionWhenNoSuchRecipe()
        {
            var service = this.CreateMockAndConfigureService(
                new List<Nutrition>(),
                new List<Ingredient>(),
                new List<RecipeIngredient>(),
                new List<Recipe>());

            await Assert.ThrowsAsync<NullReferenceException>(async () => await service.CalculateNutritionForRecipeAsync(TestRecipeId));
        }

        private INutritionsService CreateMockAndConfigureService(
            IList<Nutrition> nutritionList,
            IList<Ingredient> ingredientList,
            IList<RecipeIngredient> recipeIngredientList,
            IList<Recipe> recipeList)
        {
            var mockNutritionsRepo = new Mock<IDeletableEntityRepository<Nutrition>>();
            mockNutritionsRepo.Setup(x => x.All())
              .Returns(nutritionList.AsQueryable());
            mockNutritionsRepo.Setup(x => x.AddAsync(It.IsAny<Nutrition>()))
                .Callback((Nutrition nutrition) => nutritionList.Add(nutrition));
            //mockNutritionsRepo.Setup(x => x.Delete(It.IsAny<Nutrition>()))
            //    .Callback((Nutrition nutrition) => nutrition.IsDeleted = true);
            mockNutritionsRepo.Setup(x => x.Update(It.IsAny<Nutrition>()))
                .Callback((Nutrition nutrition) =>
                {
                    nutritionList.FirstOrDefault(x => x.Id == nutrition.Id).Calories = nutrition.Calories;
                    nutritionList.FirstOrDefault(x => x.Id == nutrition.Id).Carbohydrates = nutrition.Carbohydrates;
                    nutritionList.FirstOrDefault(x => x.Id == nutrition.Id).Fats = nutrition.Fats;
                    nutritionList.FirstOrDefault(x => x.Id == nutrition.Id).Proteins = nutrition.Proteins;
                    nutritionList.FirstOrDefault(x => x.Id == nutrition.Id).Fibres = nutrition.Fibres;
                });

            var mockIngredientRepo = new Mock<IDeletableEntityRepository<Ingredient>>();
            mockIngredientRepo.Setup(x => x.All())
                .Returns(ingredientList.AsQueryable());
            mockIngredientRepo.Setup(x => x.Update(It.IsAny<Ingredient>()))
                .Callback((Ingredient ingredient) =>
                {
                    ingredientList.FirstOrDefault(x => x.Id == ingredient.Id).Name = ingredient.Name;
                    ingredientList.FirstOrDefault(x => x.Id == ingredient.Id).VolumeInMlPer100Grams = ingredient.VolumeInMlPer100Grams;
                });

            var mockRecipeRepo = new Mock<IDeletableEntityRepository<Recipe>>();
            mockRecipeRepo.Setup(x => x.All())
                .Returns(new TestAsyncEnumerable<Recipe>(recipeList).AsQueryable());

            var mockRecipeIngredientRepo = new Mock<IDeletableEntityRepository<RecipeIngredient>>();
            mockRecipeIngredientRepo.Setup(x => x.All())
                .Returns(new TestAsyncEnumerable<RecipeIngredient>(recipeIngredientList).AsQueryable());

            var service = new NutritionsService(
                mockNutritionsRepo.Object,
                mockIngredientRepo.Object,
                mockRecipeIngredientRepo.Object,
                mockRecipeRepo.Object);

            return service;
        }
    }
}
