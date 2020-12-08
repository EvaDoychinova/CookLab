namespace CookLab.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.InputModels.Ingredients;
    using CookLab.Models.ViewModels.Ingredients;
    using CookLab.Services.Data.Tests.AsyncClasses;
    using CookLab.Services.Mapping;

    using Moq;

    using Xunit;

    public class IngredientsServiceTests
    {
        public const string TestIngredientId = "TestIngredientId";
        public const string TestIngredientName = "TestIngredientName";
        public const double TestVolumeIngredient = 50.50;

        [Fact]
        public async Task DoesIngredientsCreateAsyncWorkCorrectly()
        {
            var list = new List<Ingredient>();
            var service = this.CreateMockAndConfigureService(list);

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
            var service = this.CreateMockAndConfigureService(list);

            var newIngredient = new IngredientInputModel
            {
                Name = TestIngredientName,
                VolumeInMlPer100Grams = TestVolumeIngredient,
            };

            await service.CreateAsync(newIngredient);

            await Assert.ThrowsAsync<ArgumentException>(async () => await service.CreateAsync(newIngredient));
        }

        [Fact]
        public async Task DoesIngredientsGetAllAsyncWorkCorrectly()
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

            var service = this.CreateMockAndConfigureService(list);

            var ingredientsResult = await service.GetAllAsync<IngredientViewModel>();
            var count = ingredientsResult.Count();

            Assert.Equal(1, count);
        }

        private IIngredientsService CreateMockAndConfigureService(IList<Ingredient> list)
        {
            var mockIngredientRepo = new Mock<IDeletableEntityRepository<Ingredient>>();
            mockIngredientRepo.Setup(x => x.All())
                .Returns(list.AsQueryable());
            mockIngredientRepo.Setup(x => x.AllAsNoTracking())
                .Returns(new TestAsyncEnumerable<Ingredient>(list).AsQueryable());
            mockIngredientRepo.Setup(x => x.AddAsync(It.IsAny<Ingredient>()))
                .Callback((Ingredient ingredient) => list.Add(ingredient));

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

            return service;
        }
    }
}
