namespace CookLab.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.InputModels.Ingredients;
    using CookLab.Models.ViewModels.Ingredients;
    using CookLab.Models.ViewModels.Nutritions;
    using CookLab.Services.Data.Tests.AsyncClasses;

    using Moq;

    using Xunit;

    public class IngredientsServiceTests
    {
        public const string TestIngredientId = "TestIngredientId";
        public const string TestIngredientId2 = "TestIngredientId2";
        public const string TestIngredientName = "TestIngredientName";
        public const string TestIngredientName2 = "TestIngredientName2";
        public const double TestVolumeIngredient = 50.50;
        public const double TestVolumeIngredient2 = 100.10;

        public const string TestNutritionId = "TestNutritionId";

        [Fact]
        public async Task DoesIngredientCreateAsyncWorkCorrectly()
        {
            var list = new List<Ingredient>();
            var service = this.CreateMockAndConfigureService(list, new List<Nutrition>(), new List<Recipe>());

            var newIngredient = new IngredientInputModel
            {
                Name = TestIngredientName,
                VolumeInMlPer100Grams = TestVolumeIngredient,
            };

            await service.CreateAsync(newIngredient);

            Assert.Equal(TestIngredientName, list.First().Name);
        }

        [Fact]
        public async Task DoesIngredientCreateAsyncThrowArgumentExceptionWhenIngredientNameExists()
        {
            var list = new List<Ingredient>();
            var service = this.CreateMockAndConfigureService(list, new List<Nutrition>(), new List<Recipe>());

            var newIngredient = new IngredientInputModel
            {
                Name = TestIngredientName,
                VolumeInMlPer100Grams = TestVolumeIngredient,
            };

            await service.CreateAsync(newIngredient);

            await Assert.ThrowsAsync<ArgumentException>(async () => await service.CreateAsync(newIngredient));
        }

        //[Fact]
        //public async Task DoesIngredientsGetAllAsyncWorkCorrectly()
        //{
        //    var list = new TestAsyncEnumerable<Ingredient>(new List<Ingredient>
        //    {
        //        new Ingredient
        //        {
        //            Name = TestIngredientName,
        //            VolumeInMlPer100Grams = TestVolumeIngredient,
        //        },
        //    }).AsQueryable();

        //    var mockIngredientRepo = new Mock<IDeletableEntityRepository<Ingredient>>(MockBehavior.Strict);
        //    mockIngredientRepo.Setup(x => x.AllAsNoTracking())
        //        .Returns(list);

        //    var mapperMock = new Mock<IMapper>();
        //    mapperMock.Setup(x => QueryableMappingExtensions.To<IngredientViewModel>(It.IsAny<IQueryable<Ingredient>>()))
        //        .Returns((Ingredient ingredient) => new TestAsyncEnumerable<IngredientViewModel>(
        //            list
        //            .Select(x => new IngredientViewModel
        //            {
        //                Name = ingredient.Name,
        //                VolumeInMlPer100Grams = ingredient.VolumeInMlPer100Grams,
        //            })));

        //    var mockNutritionsRepo = new Mock<IDeletableEntityRepository<Nutrition>>();
        //    var mockRecipeRepo = new Mock<IDeletableEntityRepository<Recipe>>();

        //    var mockRecipeIngredientRepo = new Mock<IDeletableEntityRepository<RecipeIngredient>>();
        //    var mockNutritionsService = new Mock<NutritionsService>(
        //        mockNutritionsRepo.Object,
        //        mockIngredientRepo.Object,
        //        mockRecipeIngredientRepo.Object,
        //        mockRecipeRepo.Object);

        //    var service = new IngredientsService(
        //        mockIngredientRepo.Object,
        //        mockNutritionsRepo.Object,
        //        mockRecipeRepo.Object,
        //        mockNutritionsService.Object);

        //    var ingredientsResult = await service.GetAllAsync<TestIngredientViewModel>();
        //    var count = ingredientsResult.Count();

        //    Assert.Equal(1, count);
        //}

        [Fact]
        public async Task DoesIngredientEditAsyncWorkCorrectly()
        {
            var list = new List<Ingredient>
            {
                new Ingredient
                {
                  Id = TestIngredientId,
                  Name = TestIngredientName,
                  VolumeInMlPer100Grams = TestVolumeIngredient,
                },
            };

            var service = this.CreateMockAndConfigureService(list, new List<Nutrition>(), new List<Recipe>());

            var ingredientEdit = new IngredientEditViewModel
            {
                Id = TestIngredientId,
                Name = "EditedIngredientName",
                VolumeInMlPer100Grams = TestVolumeIngredient,
            };

            await service.EditAsync(ingredientEdit);

            Assert.Equal("EditedIngredientName", list.First().Name);
        }

        [Fact]
        public async Task DoesIngredientEditAsyncThrowNullReferenceExceptionWhenIngredientIsNull()
        {
            var service = this.CreateMockAndConfigureService(new List<Ingredient>(), new List<Nutrition>(), new List<Recipe>());

            await Assert.ThrowsAsync<NullReferenceException>(async () => await service.EditAsync(new IngredientEditViewModel()));
        }

        [Fact]
        public async Task DoesIngredientEditAsyncThrowArgumentExceptionWhenIngredientWhitTheNewNameExists()
        {
            var list = new List<Ingredient>
            {
                new Ingredient
                {
                  Id = TestIngredientId,
                  Name = TestIngredientName,
                  VolumeInMlPer100Grams = TestVolumeIngredient,
                },
                new Ingredient
                {
                  Id = TestIngredientId2,
                  Name = TestIngredientName2,
                  VolumeInMlPer100Grams = TestVolumeIngredient2,
                },
            };

            var ingredientEdit = new IngredientEditViewModel
            {
                Id = TestIngredientId2,
                Name = TestIngredientName,
                VolumeInMlPer100Grams = TestVolumeIngredient2,
            };

            var service = this.CreateMockAndConfigureService(list, new List<Nutrition>(), new List<Recipe>());

            await Assert.ThrowsAsync<ArgumentException>(async () => await service.EditAsync(ingredientEdit));
        }

        [Fact]
        public async Task DoesIngredientEditAsyncEditNutritionForIngredient()
        {
            var list = new List<Ingredient>
            {
                new Ingredient
                {
                  Id = TestIngredientId,
                  Name = TestIngredientName,
                  VolumeInMlPer100Grams = TestVolumeIngredient,
                },
            };

            var nutritionList = new List<Nutrition>
            {
                new Nutrition
                {
                    Id = TestNutritionId,
                    Calories = 0,
                    Carbohydrates = 0,
                    Fats = 0,
                    Proteins = 0,
                    Fibres = 0,
                    IngredientId = TestIngredientId,
                },
            };

            var service = this.CreateMockAndConfigureService(list, nutritionList, new List<Recipe>());

            var ingredientEdit = new IngredientEditViewModel
            {
                Id = TestIngredientId,
                Name = TestIngredientName2,
                VolumeInMlPer100Grams = TestVolumeIngredient2,
                NutritionPer100Grams = new NutritionEditViewModel
                {
                    Id = TestNutritionId,
                    Calories = 100,
                    Carbohydrates = 100,
                    Fats = 100,
                    Proteins = 100,
                    Fibres = 100,
                },
            };

            await service.EditAsync(ingredientEdit);

            Assert.Equal(100, nutritionList.First().Calories);
        }

        [Fact]
        public async Task DoesIngredientDeleteAsyncWorkCorrcetly()
        {
            var list = new List<Ingredient>
            {
                new Ingredient
                {
                  Id = TestIngredientId,
                  Name = TestIngredientName,
                  VolumeInMlPer100Grams = TestVolumeIngredient,
                },
            };

            var service = this.CreateMockAndConfigureService(list, new List<Nutrition>(), new List<Recipe>());

            await service.DeleteAsync(TestIngredientId);

            Assert.True(list.First().IsDeleted);
        }

        [Fact]
        public async Task DoesIngredientDeleteAsyncThrowNullReferenceExceptionWhenIngredientIsNull()
        {
            var service = this.CreateMockAndConfigureService(new List<Ingredient>(), new List<Nutrition>(), new List<Recipe>());

            await Assert.ThrowsAsync<NullReferenceException>(async () => await service.DeleteAsync("string"));
        }

        [Fact]
        public async Task DoesIngredientDeleteAsyncDeleteNutritionForIngredient()
        {
            var list = new List<Ingredient>
            {
                new Ingredient
                {
                  Id = TestIngredientId,
                  Name = TestIngredientName,
                  VolumeInMlPer100Grams = TestVolumeIngredient,
                },
            };

            var nutritionList = new List<Nutrition>
            {
                new Nutrition
                {
                    Id = TestNutritionId,
                    Calories = 0,
                    Carbohydrates = 0,
                    Fats = 0,
                    Proteins = 0,
                    Fibres = 0,
                    IngredientId = TestIngredientId,
                },
            };

            var service = this.CreateMockAndConfigureService(list, nutritionList, new List<Recipe>());

            await service.DeleteAsync(TestIngredientId);

            Assert.True(nutritionList.First().IsDeleted);
        }

        [Fact]
        public async Task DoesIngredientsGetAllIngredientsSelectListAsyncWorkCorrectly()
        {
            var list = new TestAsyncEnumerable<Ingredient>(new List<Ingredient>
            {
                new Ingredient
                {
                  Id = TestIngredientId,
                  Name = TestIngredientName,
                  VolumeInMlPer100Grams = TestVolumeIngredient,
                },
            }).AsQueryable();

            var mockIngredientRepo = new Mock<IDeletableEntityRepository<Ingredient>>(MockBehavior.Strict);
            mockIngredientRepo.Setup(x => x.AllAsNoTracking())
                .Returns(list);

            var mockNutritionsRepo = new Mock<IDeletableEntityRepository<Nutrition>>();
            var mockRecipeRepo = new Mock<IDeletableEntityRepository<Recipe>>();

            var mockRecipeIngredientRepo = new Mock<IDeletableEntityRepository<RecipeIngredient>>();
            var mockNutritionsService = new Mock<NutritionsService>(
                mockNutritionsRepo.Object,
                mockIngredientRepo.Object,
                mockRecipeIngredientRepo.Object,
                mockRecipeRepo.Object);

            var service = new IngredientsService(
                mockIngredientRepo.Object,
                mockNutritionsRepo.Object,
                mockRecipeRepo.Object,
                mockNutritionsService.Object);

            var ingredients = await service.GetAllIngredientsSelectListAsync();
            var count = ingredients.Count();

            Assert.Equal(1, count);
        }

        private IIngredientsService CreateMockAndConfigureService(IList<Ingredient> list, IList<Nutrition> nutritionList, IList<Recipe> recipeList)
        {
            var mockIngredientRepo = new Mock<IDeletableEntityRepository<Ingredient>>();
            mockIngredientRepo.Setup(x => x.All())
                .Returns(list.AsQueryable());
            mockIngredientRepo.Setup(x => x.AddAsync(It.IsAny<Ingredient>()))
                .Callback((Ingredient ingredient) => list.Add(ingredient));
            mockIngredientRepo.Setup(x => x.Delete(It.IsAny<Ingredient>()))
               .Callback((Ingredient ingredient) => ingredient.IsDeleted = true);
            mockIngredientRepo.Setup(x => x.Update(It.IsAny<Ingredient>()))
                .Callback((Ingredient ingredient) =>
                {
                    list.FirstOrDefault(x => x.Id == ingredient.Id).Name = ingredient.Name;
                    list.FirstOrDefault(x => x.Id == ingredient.Id).VolumeInMlPer100Grams = ingredient.VolumeInMlPer100Grams;
                });

            var mockNutritionsRepo = new Mock<IDeletableEntityRepository<Nutrition>>();
            mockNutritionsRepo.Setup(x => x.All())
              .Returns(nutritionList.AsQueryable());
            mockNutritionsRepo.Setup(x => x.Delete(It.IsAny<Nutrition>()))
                .Callback((Nutrition nutrition) => nutrition.IsDeleted = true);
            mockNutritionsRepo.Setup(x => x.Update(It.IsAny<Nutrition>()))
                .Callback((Nutrition nutrition) =>
                {
                    nutritionList.FirstOrDefault(x => x.Id == nutrition.Id).Calories = nutrition.Calories;
                    nutritionList.FirstOrDefault(x => x.Id == nutrition.Id).Carbohydrates = nutrition.Carbohydrates;
                    nutritionList.FirstOrDefault(x => x.Id == nutrition.Id).Fats = nutrition.Fats;
                    nutritionList.FirstOrDefault(x => x.Id == nutrition.Id).Proteins = nutrition.Proteins;
                    nutritionList.FirstOrDefault(x => x.Id == nutrition.Id).Fibres = nutrition.Fibres;
                });

            var mockRecipeRepo = new Mock<IDeletableEntityRepository<Recipe>>();
            mockRecipeRepo.Setup(x => x.All())
                .Returns(new TestAsyncEnumerable<Recipe>(recipeList).AsQueryable());

            var mockRecipeIngredientRepo = new Mock<IDeletableEntityRepository<RecipeIngredient>>();
            var mockNutritionsService = new Mock<NutritionsService>(
                mockNutritionsRepo.Object,
                mockIngredientRepo.Object,
                mockRecipeIngredientRepo.Object,
                mockRecipeRepo.Object);

            var service = new IngredientsService(
                mockIngredientRepo.Object,
                mockNutritionsRepo.Object,
                mockRecipeRepo.Object,
                mockNutritionsService.Object);

            return service;
        }
    }
}
