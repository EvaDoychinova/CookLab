namespace CookLab.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using AutoMapper;
    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.InputModels.Ingredients;
    using CookLab.Models.ViewModels.Ingredients;
    using CookLab.Services.Data.Tests.AsyncClasses;
    using CookLab.Services.Data.Tests.TestViewModels;
    using CookLab.Services.Mapping;

    using Moq;

    using Xunit;

    public class IngredientsServiceTests
    {
        public const string TestIngredientId = "TestIngredientId";
        public const string TestIngredientName = "TestIngredientName";
        public const double TestVolumeIngredient = 50.50;

        [Fact]
        public async Task DoesIngredientCreateAsyncWorkCorrectly()
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
            var list = new TestAsyncEnumerable<Ingredient>(new List<Ingredient>
            {
                new Ingredient
                {
                    Name = TestIngredientName,
                    VolumeInMlPer100Grams = TestVolumeIngredient,
                },
            }).AsQueryable();

            var mockIngredientRepo = new Mock<IDeletableEntityRepository<Ingredient>>(MockBehavior.Strict);
            mockIngredientRepo.Setup(x => x.AllAsNoTracking())
                .Returns(list);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => QueryableMappingExtensions.To<IngredientViewModel>(It.IsAny<IQueryable<Ingredient>>()))
                .Returns((Ingredient ingredient) => new TestAsyncEnumerable<IngredientViewModel>(
                    list
                    .Select(x => new IngredientViewModel
                    {
                        Name = ingredient.Name,
                        VolumeInMlPer100Grams = ingredient.VolumeInMlPer100Grams,
                    })));

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

            var ingredientsResult = await service.GetAllAsync<TestIngredientViewModel>();
            var count = ingredientsResult.Count();

            Assert.Equal(1, count);
        }

        [Fact]
        public async Task DoesIngredientEditAsyncWorkCorrectly()
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

            var mockIngredientRepo = new Mock<IDeletableEntityRepository<Ingredient>>();
            mockIngredientRepo.Setup(x => x.All())
                .Returns(list);
            mockIngredientRepo.Setup(x => x.Update(It.IsAny<Ingredient>()))
                .Callback((Ingredient ingredient) =>
                {
                    list.FirstOrDefault(x => x.Id == ingredient.Id).Name = ingredient.Name;
                    list.FirstOrDefault(x => x.Id == ingredient.Id).VolumeInMlPer100Grams = ingredient.VolumeInMlPer100Grams;
                });

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

            var ingredientEdit = new IngredientEditViewModel
            {
                Id = TestIngredientId,
                Name = "EditedIngredientName",
                VolumeInMlPer100Grams = TestVolumeIngredient,
            };

            await service.EditAsync(ingredientEdit);
            var count = list.Count();

            Assert.Equal(1, count);
            Assert.Equal("EditedIngredientName", list.First().Name);
        }

        [Fact]
        public async Task DoesIngredientDeleteAsyncWorkCorrcetly()
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
            mockIngredientRepo.Setup(x => x.All())
                .Returns(list);
            mockIngredientRepo.Setup(x => x.Delete(It.IsAny<Ingredient>()))
                .Callback((Ingredient ingredient) => list.ToList().Remove(ingredient));

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

            await service.DeleteAsync(TestIngredientId);

            Assert.Equal(0, list.Count());
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

        private IIngredientsService CreateMockAndConfigureService(IList<Ingredient> list)
        {
            var mockIngredientRepo = new Mock<IDeletableEntityRepository<Ingredient>>();
            mockIngredientRepo.Setup(x => x.All())
                .Returns(list.AsQueryable());
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
