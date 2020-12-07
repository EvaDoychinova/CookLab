namespace CookLab.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.InputModels.Ingredients;
    using Moq;

    using Xunit;

    public class IngredientsServiceTests
    {
        public const string TestIngredientName = "TestIngredientName";
        public const double TestVolumeIngredient = 50.50;

        [Fact]
        public async Task DoesIngredientsCreateAsyncWorkCorrectly()
        {
            var list = new List<Ingredient>();
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

            var service = new IngredientsService(mockIngredientRepo.Object, mockNutritionsRepo.Object, mockRecipeRepo.Object, mockNutritionsService.Object);

            var newIngredient = new IngredientInputModel
            {
                Name = TestIngredientName,
                VolumeInMlPer100Grams = TestVolumeIngredient,
            };

            await service.CreateAsync(newIngredient);

            Assert.Equal(TestIngredientName, list.First().Name);
        }
    }
}
