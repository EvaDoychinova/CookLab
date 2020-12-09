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
        private const int TestCategoryId = 1;
        private const int TestCategoryId2 = 2;
        private const string TestRecipeId = "TestRecipeId";
        private const string TestCategoryName = "TestCategory1";
        private const string TestCategoryName2 = "TestCategory2";
        private const string TestImageUrl = "assets/img/categories/test.jpg";
        private const string TestImageName = "Test.jpg";
        private const string TestImageContentType = "image/jpg";

        [Fact]
        public async Task DoesCategoryCreateAsyncWorksCorrectly()
        {
            var categoryList = new List<Category>();

            var service = this.CreateMockAndConfigureService(categoryList, new List<CategoryRecipe>());

            var rootPath = @"D:/SoftUni/07.C# Web/02.ASP.NET Core/NEW/PROJECT/CookLab/CookLab/Tests/CookLab.Services.Data.Tests";

            using FileStream stream = File.OpenRead(TestImageName);
            var file = new FormFile(stream, 0, stream.Length, null, stream.Name)
            {
                Headers = new HeaderDictionary(),
                ContentType = TestImageContentType,
            };

            var categoryToAdd = new CategoryInputModel
            {
                Name = TestCategoryName,
                Image = file,
            };

            await service.CreateAsync(categoryToAdd, rootPath);
            var count = categoryList.Count();

            Assert.Equal(1, count);
        }

        [Fact]
        public async Task DoesCategoryCreateAsyncThrowArgumentExceptionWhenCategoryExists()
        {
            var categoryList = new List<Category>();

            var service = this.CreateMockAndConfigureService(categoryList, new List<CategoryRecipe>());

            var rootPath = @"D:/SoftUni/07.C# Web/02.ASP.NET Core/NEW/PROJECT/CookLab/CookLab/Tests/CookLab.Services.Data.Tests";

            using FileStream stream = File.OpenRead(TestImageName);
            var file = new FormFile(stream, 0, stream.Length, null, stream.Name)
            {
                Headers = new HeaderDictionary(),
                ContentType = TestImageContentType,
            };

            var categoryToAdd = new CategoryInputModel
            {
                Name = TestCategoryName,
                Image = file,
            };

            await service.CreateAsync(categoryToAdd, rootPath);

            await Assert.ThrowsAsync<ArgumentException>(async () => await service.CreateAsync(categoryToAdd, rootPath));
        }

        [Fact]
        public async Task DoesCategoryEditAsyncWorkCorrectlyWhenImageIsNotChanged()
        {
            var categoryList = new List<Category>
            {
                new Category
                {
                    Id = TestCategoryId,
                    Name = TestCategoryName,
                    ImageUrl = TestImageUrl,
                },
            };

            var service = this.CreateMockAndConfigureService(categoryList, new List<CategoryRecipe>());

            var categoryToEdit = new CategoryEditViewModel
            {
                Id = TestCategoryId,
                Name = "New name",
            };

            await service.EditAsync(categoryToEdit, string.Empty);
            var count = categoryList.Count();

            Assert.Equal("New name", categoryList.First().Name);
            Assert.Equal(1, count);
        }

        [Fact]
        public async Task DoesCategoryEditAsyncWorkCorrectlyWhenImageIsChanged()
        {
            var categoryList = new List<Category>
            {
                new Category
                {
                    Id = TestCategoryId,
                    Name = TestCategoryName,
                    ImageUrl = TestImageUrl,
                },
            };

            var service = this.CreateMockAndConfigureService(categoryList, new List<CategoryRecipe>());

            var rootPath = @"D:/SoftUni/07.C# Web/02.ASP.NET Core/NEW/PROJECT/CookLab/CookLab/Tests/CookLab.Services.Data.Tests";

            using FileStream stream = File.OpenRead(TestImageName);
            var file = new FormFile(stream, 0, stream.Length, null, stream.Name)
            {
                Headers = new HeaderDictionary(),
                ContentType = TestImageContentType,
            };

            var categoryToEdit = new CategoryEditViewModel
            {
                Id = TestCategoryId,
                Name = "New name",
                Image = file,
            };

            await service.EditAsync(categoryToEdit, rootPath);
            var count = categoryList.Count();

            Assert.Equal("New name", categoryList.First().Name);
            Assert.Equal(1, count);
        }

        [Fact]
        public async Task DoesCategoryEditAsyncThrowsNullReferenceExceptionWhenCategoryDoesNotExist()
        {
            var categoryList = new List<Category>
            {
                new Category
                {
                    Id = TestCategoryId,
                    Name = TestCategoryName,
                    ImageUrl = TestImageUrl,
                },
            };

            var service = this.CreateMockAndConfigureService(categoryList, new List<CategoryRecipe>());

            var categoryToEdit = new CategoryEditViewModel
            {
                Id = TestCategoryId2,
                Name = "New name",
            };

            await Assert.ThrowsAsync<NullReferenceException>(async () => await service.EditAsync(categoryToEdit, string.Empty));
        }

        [Fact]
        public async Task DoesCategoryEditAsyncThrowsArgumentExceptionWhenCategoryWithThatNameAlreadyExists()
        {
            var categoryList = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = TestCategoryName,
                    ImageUrl = TestImageUrl,
                },
                new Category
                {
                    Id = 2,
                    Name = TestCategoryName2,
                    ImageUrl = TestImageUrl,
                },
            };

            var service = this.CreateMockAndConfigureService(categoryList, new List<CategoryRecipe>());

            var categoryToEdit = new CategoryEditViewModel
            {
                Id = 2,
                Name = TestCategoryName,
            };

            await Assert.ThrowsAsync<ArgumentException>(async () => await service.EditAsync(categoryToEdit, string.Empty));
        }

        //[Fact]
        //public async Task DoesCategoryDeleteAsyncWorkCorrectly()
        //{
        //    var categoryList = new List<Category>
        //    {
        //        new Category
        //        {
        //            Id = TestCategoryId,
        //            Name = TestCategoryName,
        //            ImageUrl = TestImageUrl,
        //        },
        //    };

        //    var service = this.CreateMockAndConfigureService(categoryList, new List<CategoryRecipe>());

        //    await service.DeleteAsync(TestCategoryId);

        //    Assert.True(categoryList.First().IsDeleted);
        //}

        [Fact]
        public async Task DoesCategoryDeleteAsyncWorkCorrectlyWhenItHasRecipes()
        {
            var categoryList = new List<Category>
            {
                new Category
                {
                    Id = TestCategoryId,
                    Name = TestCategoryName,
                    ImageUrl = TestImageUrl,
                },
            };

            var categoryRecipe = new List<CategoryRecipe>
            {
                new CategoryRecipe
                {
                    CategoryId = TestCategoryId,
                    RecipeId = TestRecipeId,
                },
            };

            var service = this.CreateMockAndConfigureService(categoryList, categoryRecipe);

            await service.DeleteAsync(TestCategoryId);

            Assert.True(categoryList.First().IsDeleted);
        }

        [Fact]
        public async Task DoesCategoryDeleteAsyncThrowsNullReferenceExceptionWhenCategoryDoesNotExist()
        {
            var categoryList = new List<Category>
            {
                new Category
                {
                    Id = TestCategoryId,
                    Name = TestCategoryName,
                    ImageUrl = TestImageUrl,
                },
            };

            var service = this.CreateMockAndConfigureService(categoryList, new List<CategoryRecipe>());

            await Assert.ThrowsAsync<NullReferenceException>(async () => await service.DeleteAsync(TestCategoryId2));
        }

        [Fact]
        public async Task DoesGetAllCategoriesSelectListAsyncWorkCorrectly()
        {
            var categoryList = new List<Category>
            {
                new Category
                {
                    Id = TestCategoryId,
                    Name = TestCategoryName,
                    ImageUrl = TestImageUrl,
                },
            };

            var service = this.CreateMockAndConfigureService(categoryList, new List<CategoryRecipe>());

            var categories = await service.GetAllCategoriesSelectListAsync();

            Assert.Equal(1, categories.Count());
        }

        private ICategoriesService CreateMockAndConfigureService(IList<Category> categoryList, IList<CategoryRecipe> catgeoryRecipeList)
        {
            var mockCategoryRepo = new Mock<IDeletableEntityRepository<Category>>();
            mockCategoryRepo.Setup(x => x.All()).Returns(categoryList.AsQueryable());
            mockCategoryRepo.Setup(x => x.AllAsNoTracking()).Returns(new TestAsyncEnumerable<Category>(categoryList).AsQueryable());
            mockCategoryRepo.Setup(x => x.AddAsync(It.IsAny<Category>()))
                .Callback((Category category) => categoryList.Add(category));
            mockCategoryRepo.Setup(x => x.Delete(It.IsAny<Category>()))
                .Callback((Category category) => category.IsDeleted = true);
            mockCategoryRepo.Setup(x => x.Update(It.IsAny<Category>()))
                .Callback((Category category) =>
                {
                    categoryList.FirstOrDefault(x => x.Id == category.Id).Name = category.Name;
                    categoryList.FirstOrDefault(x => x.Id == category.Id).ImageUrl = category.ImageUrl;

                });

            var mockCategoryRecipeRepo = new Mock<IDeletableEntityRepository<CategoryRecipe>>();
            mockCategoryRecipeRepo.Setup(x => x.AllAsNoTracking())
                .Returns(new TestAsyncEnumerable<CategoryRecipe>(catgeoryRecipeList).AsQueryable());
            mockCategoryRecipeRepo.Setup(x => x.Delete(It.IsAny<CategoryRecipe>()))
                .Callback((CategoryRecipe categoryRecipe) => categoryRecipe.IsDeleted = true);

            var service = new CategoriesService(mockCategoryRepo.Object, mockCategoryRecipeRepo.Object);

            return service;
        }
    }
}
