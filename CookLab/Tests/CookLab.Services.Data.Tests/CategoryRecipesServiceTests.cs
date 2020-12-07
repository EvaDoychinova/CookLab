namespace CookLab.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;

    using Microsoft.EntityFrameworkCore;

    using Moq;

    using Xunit;

    public class CategoryRecipesServiceTests
    {
        public const string TestRecipeId = "4ae46bcd-5469-4e92-bf1e-f105fe11c79a";

        [Fact]
        public async Task DoesGetAllCategoriesForRecipeAsyncWorkCorrectly()
        {
            var list = new List<CategoryRecipe>
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
            };

            var categories = list.AsQueryable();

            var mockCategoryRecipesRepo = new Mock<IDeletableEntityRepository<CategoryRecipe>>();
            mockCategoryRecipesRepo.Setup(x => x.AllAsNoTracking()).Returns(categories);

            var service = new CategoryRecipesService(mockCategoryRecipesRepo.Object);

            var categoriesResult = service.GetAllCategoriesForRecipeAsync(TestRecipeId).GetAwaiter().GetResult();

            Assert.Equal(1, categoriesResult.First());
            Assert.Equal(2, categoriesResult.Count);
        }
    }
}
