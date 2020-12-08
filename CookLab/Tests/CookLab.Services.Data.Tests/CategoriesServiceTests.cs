namespace CookLab.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.InputModels.Categories;
    using CookLab.Models.ViewModels.Categories;
    using CookLab.Services.Data.Tests.AsyncClasses;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Internal;

    using Moq;

    using Xunit;

    public class CategoriesServiceTests
    {
        private const string TestCategoryName = "Test";
        private const string TestImageUrl = "~/Test.jpg";
        private const string TestImageName = "Test.jpg";
        private const string TestImageContentType = "image/jpg";

        [Fact]
        public async Task DoesCategoryCreateAsyncWorksCorrectly()
        {
            var list = new List<Category>();
            var mockCategoryRepo = new Mock<IDeletableEntityRepository<Category>>();
            mockCategoryRepo.Setup(x => x.All())
                .Returns(list.AsQueryable());
            mockCategoryRepo.Setup(x => x.AddAsync(It.IsAny<Category>()))
                .Callback((Category category) => list.Add(category));

            var mockCategoryRecipeRepo = new Mock<IDeletableEntityRepository<CategoryRecipe>>();

            var service = new CategoriesService(mockCategoryRepo.Object, mockCategoryRecipeRepo.Object);

            using FileStream stream = File.OpenRead(TestImageName);
            var file = new FormFile(stream, 0, stream.Length, null, stream.Name)
            {
                Headers = new HeaderDictionary(),
                ContentType = TestImageContentType,
            };

            await service.CreateAsync(
                new CategoryInputModel
                {
                    Name = TestCategoryName,
                    Image = file,
                },
                string.Empty);

            var count = mockCategoryRepo.Object.All().Count();

            Assert.Equal(1, count);
        }

        [Fact]
        public async Task DoesCategoryCreateAsyncThrowArgumentExceptionWhenCategoryExists()
        {
            var list = new List<Category>();
            var mockCategoryRepo = new Mock<IDeletableEntityRepository<Category>>();
            mockCategoryRepo.Setup(x => x.All())
                .Returns(list.AsQueryable());
            mockCategoryRepo.Setup(x => x.AddAsync(It.IsAny<Category>()))
                .Callback((Category category) => list.Add(category));

            var mockCategoryRecipeRepo = new Mock<IDeletableEntityRepository<CategoryRecipe>>();

            var service = new CategoriesService(mockCategoryRepo.Object, mockCategoryRecipeRepo.Object);

            using FileStream stream = File.OpenRead(TestImageName);
            var file = new FormFile(stream, 0, stream.Length, null, stream.Name)
            {
                Headers = new HeaderDictionary(),
                ContentType = TestImageContentType,
            };

            await Assert.ThrowsAsync<ArgumentException>(async () => await service.CreateAsync(
                new CategoryInputModel
                {
                    Name = TestCategoryName,
                    Image = file,
                },
                string.Empty));
        }

        [Fact]
        public async Task DoesCategoryGetAllWorkCorrectly()
        {
            var list = new TestAsyncEnumerable<Category>(new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = TestCategoryName,
                    ImageUrl = TestImageUrl,
                },
            }).AsQueryable();

            var mockCategoryRepo = new Mock<IDeletableEntityRepository<Category>>(MockBehavior.Strict);
            mockCategoryRepo.Setup(x => x.AllAsNoTracking()).Returns(list);

            var mockCategoryRecipeRepo = new Mock<IDeletableEntityRepository<CategoryRecipe>>();

            var service = new CategoriesService(mockCategoryRepo.Object, mockCategoryRecipeRepo.Object);

            var categories = await service.GetAllAsync<CategoryViewModel>();
            var categoryName = categories.FirstOrDefault().Name;
            var count = categories.Count();
            Assert.Equal(1, count);
        }
    }
}
