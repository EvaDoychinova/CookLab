namespace CookLab.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Services.Data.Tests.AsyncClasses;

    using Moq;

    using Xunit;

    public class CategoryRecipesServiceTests
    {
        private const string TestRecipeId = "TestRecipeId";

        [Fact]
        public async Task DoesGetAllCategoriesForRecipeAsyncWorkCorrectly()
        {
            var list = new TestAsyncEnumerable<CategoryRecipe>(new List<CategoryRecipe>
            {
                new CategoryRecipe
                {
                    Category = new Category
                    {
                        Id = 1,
                        Name = "TestCategory1",
                    },
                    RecipeId = TestRecipeId,
                },
                new CategoryRecipe
                {
                    Category = new Category
                    {
                        Id = 2,
                        Name = "TestCategory2",
                    },
                    RecipeId = TestRecipeId,
                },
            }).AsQueryable();

            var mockCategoryRecipesRepo = new Mock<IDeletableEntityRepository<CategoryRecipe>>();
            mockCategoryRecipesRepo.Setup(x => x.AllAsNoTracking()).Returns(list);

            var service = new CategoryRecipesService(mockCategoryRecipesRepo.Object);

            var categoriesResult = await service.GetAllCategoriesForRecipeAsync(TestRecipeId);

            Assert.Equal(2, categoriesResult.Count);
            Assert.Equal(1, categoriesResult[0]);
        }
    }
}
