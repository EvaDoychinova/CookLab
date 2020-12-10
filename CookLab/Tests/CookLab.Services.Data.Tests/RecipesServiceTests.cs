namespace CookLab.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Data.Models.Enums;
    using CookLab.Models.InputModels.RecipeIngredients;
    using CookLab.Models.InputModels.Recipes;
    using CookLab.Services.Data.Tests.AsyncClasses;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Internal;
    using Moq;

    using Xunit;

    public class RecipesServiceTests
    {
        private const string TestRecipeId = "TestRecipeId";
        private const string TestRecipeName = "TestRecipeName";
        private const int TestPortionsCount = 20;
        private const int TestPreparationTime = 20;
        private const int TestCookingTime = 20;
        private const string TestPreparation = "TestPreparationForRecipe";
        private const string TestNotes = "TestNotesForRecipe";
        private const int TestCookingVesselId = 20;
        private const string TestCookingVesselName = "TestCookingVesselName";
        private const double TestCookingVesselArea = 320;
        private const double TestCookingVesselHeight = 7;
        private const double TestCookingVesselVolume = 1320;
        private const int TestCategoryId = 20;
        private const string TestCategoryName = "TestCategoryName";
        private const string TestUserId = "TestUserId";
        private const string TestUserUsername = "TestUserUsername";
        private const string TestIngredientId = "TestIngredientId";
        private const string TestIngredientName = "TestIngredientName";
        private const double TestWeightIngredient = 20;
        private const IngredientPartOfRecipe TestPartOfRecipeIngredient = IngredientPartOfRecipe.All;

        private const string TestImageContentType = "image/jpg";
        private const string TestImageUrl = "assets/img/Recipes/test.jpg";
        private const string TestImageName = "Test.jpg";
        private const string TestRootPath = @"D:/SoftUni/07.C# Web/02.ASP.NET Core/NEW/PROJECT/CookLab/CookLab/Tests/CookLab.Services.Data.Tests";

        [Fact]
        public async Task DoesRecipeCreateAsyncWorkCorrectly()
        {
            var recipesList = new List<Recipe>();

            var cookingVesselList = new List<CookingVessel>
            {
                new CookingVessel
                {
                    Id = TestCookingVesselId,
                    Name = TestCookingVesselName,
                    Height = TestCookingVesselHeight,
                    Area = TestCookingVesselArea,
                    Volume = TestCookingVesselVolume,
                },
            };

            var userList = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = TestUserId,
                    UserName = TestUserUsername,
                },
            };

            var categoryList = new List<Category>
            {
                new Category
                {
                    Id = TestCategoryId,
                    Name = TestCategoryName,
                },
            };

            var ingredientList = new List<Ingredient>
            {
                new Ingredient
                {
                    Id = TestIngredientId,
                    Name = TestIngredientName,
                },
            };

            var service = this.CreateMockAndConfigureService(
                recipesList,
                categoryList,
                new List<CategoryRecipe>(),
                ingredientList,
                new List<Nutrition>(),
                new List<RecipeIngredient>(),
                new List<RecipeImage>(),
                cookingVesselList,
                new List<UserRecipe>(),
                userList);

            using FileStream stream = File.OpenRead(TestImageName);
            var file = new FormFile(stream, 0, stream.Length, null, stream.Name)
            {
                Headers = new HeaderDictionary(),
                ContentType = TestImageContentType,
            };

            var recipeToCreate = new RecipeInputModel
            {
                Name = TestRecipeName,
                CookingTime = TestCookingTime,
                CookingVesselId = TestCookingVesselId,
                Notes = TestNotes,
                Preparation = TestPreparation,
                PreparationTime = TestPreparationTime,
                Portions = TestPortionsCount,
                Images = new List<IFormFile>
                {
                    file,
                },
                SelectedCategories = new List<int>
                {
                    TestCategoryId,
                },
                SelectedIngredients = new List<RecipeIngredientInputModel>
                {
                    new RecipeIngredientInputModel
                    {
                        IngredientId = TestIngredientId,
                        PartOfRecipe = TestPartOfRecipeIngredient,
                        WeightInGrams = TestWeightIngredient,
                    },
                },
            };

            await service.CreateAsync(TestUserId, recipeToCreate, TestRootPath);
            var count = recipesList.Count();

            Assert.Equal(1, count);
        }

        [Fact]
        public async Task DoesRecipeCreateAsyncThrowsArgumentExceptionWhenRecipeWithSuchNameAlreadyExists()
        {
            var recipesList = new List<Recipe>
            {
                new Recipe
                {
                    Name = TestRecipeName,
                },
            };

            var service = this.CreateMockAndConfigureService(
                recipesList,
                new List<Category>(),
                new List<CategoryRecipe>(),
                new List<Ingredient>(),
                new List<Nutrition>(),
                new List<RecipeIngredient>(),
                new List<RecipeImage>(),
                new List<CookingVessel>(),
                new List<UserRecipe>(),
                new List<ApplicationUser>());

            var recipeToCreate = new RecipeInputModel
            {
                Name = TestRecipeName,
            };

            await Assert.ThrowsAsync<ArgumentException>(async () =>
                await service.CreateAsync(TestUserId, recipeToCreate, TestRootPath));
        }

        [Fact]
        public async Task DoesRecipeCreateAsyncThrowsNullReferenceExceptionWhenNoSuchCookingVessel()
        {
            var recipesList = new List<Recipe>();

            var service = this.CreateMockAndConfigureService(
                recipesList,
                new List<Category>(),
                new List<CategoryRecipe>(),
                new List<Ingredient>(),
                new List<Nutrition>(),
                new List<RecipeIngredient>(),
                new List<RecipeImage>(),
                new List<CookingVessel>(),
                new List<UserRecipe>(),
                new List<ApplicationUser>());

            var recipeToCreate = new RecipeInputModel
            {
                Name = TestRecipeName,
                CookingVesselId = TestCookingVesselId,
            };

            await Assert.ThrowsAsync<NullReferenceException>(async () =>
                await service.CreateAsync(TestUserId, recipeToCreate, TestRootPath));
        }

        [Fact]
        public async Task DoesRecipeCreateAsyncThrowsNullReferenceExceptionWhenNoSuchCategory()
        {
            var recipesList = new List<Recipe>();

            var cookingVesselList = new List<CookingVessel>
            {
                new CookingVessel
                {
                    Id = TestCookingVesselId,
                    Name = TestCookingVesselName,
                    Height = TestCookingVesselHeight,
                    Area = TestCookingVesselArea,
                    Volume = TestCookingVesselVolume,
                },
            };

            var userList = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = TestUserId,
                    UserName = TestUserUsername,
                },
            };

            var service = this.CreateMockAndConfigureService(
                recipesList,
                new List<Category>(),
                new List<CategoryRecipe>(),
                new List<Ingredient>(),
                new List<Nutrition>(),
                new List<RecipeIngredient>(),
                new List<RecipeImage>(),
                cookingVesselList,
                new List<UserRecipe>(),
                userList);

            using FileStream stream = File.OpenRead(TestImageName);
            var file = new FormFile(stream, 0, stream.Length, null, stream.Name)
            {
                Headers = new HeaderDictionary(),
                ContentType = TestImageContentType,
            };

            var recipeToCreate = new RecipeInputModel
            {
                Name = TestRecipeName,
                CookingTime = TestCookingTime,
                CookingVesselId = TestCookingVesselId,
                Notes = TestNotes,
                Preparation = TestPreparation,
                PreparationTime = TestPreparationTime,
                Portions = TestPortionsCount,
                Images = new List<IFormFile>
                {
                    file,
                },
                SelectedCategories = new List<int>
                {
                    TestCategoryId,
                },
            };

            await Assert.ThrowsAsync<NullReferenceException>(async () =>
                await service.CreateAsync(TestUserId, recipeToCreate, TestRootPath));
        }

        [Fact]
        public async Task DoesRecipeCreateAsyncThrowsNullReferenceExceptionWhenNoSuchIngredient()
        {
            var recipesList = new List<Recipe>();
            var cookingVesselList = new List<CookingVessel>
            {
                new CookingVessel
                {
                    Id = TestCookingVesselId,
                    Name = TestCookingVesselName,
                    Height = TestCookingVesselHeight,
                    Area = TestCookingVesselArea,
                    Volume = TestCookingVesselVolume,
                },
            };

            var userList = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = TestUserId,
                    UserName = TestUserUsername,
                },
            };

            var categoryList = new List<Category>
            {
                new Category
                {
                    Id = TestCategoryId,
                    Name = TestCategoryName,
                },
            };

            var service = this.CreateMockAndConfigureService(
                recipesList,
                categoryList,
                new List<CategoryRecipe>(),
                new List<Ingredient>(),
                new List<Nutrition>(),
                new List<RecipeIngredient>(),
                new List<RecipeImage>(),
                cookingVesselList,
                new List<UserRecipe>(),
                userList);

            using FileStream stream = File.OpenRead(TestImageName);
            var file = new FormFile(stream, 0, stream.Length, null, stream.Name)
            {
                Headers = new HeaderDictionary(),
                ContentType = TestImageContentType,
            };

            var recipeToCreate = new RecipeInputModel
            {
                Name = TestRecipeName,
                CookingTime = TestCookingTime,
                CookingVesselId = TestCookingVesselId,
                Notes = TestNotes,
                Preparation = TestPreparation,
                PreparationTime = TestPreparationTime,
                Portions = TestPortionsCount,
                Images = new List<IFormFile>
                {
                    file,
                },
                SelectedCategories = new List<int>
                {
                    TestCategoryId,
                },
                SelectedIngredients = new List<RecipeIngredientInputModel>
                {
                    new RecipeIngredientInputModel
                    {
                        IngredientId = TestIngredientId,
                        PartOfRecipe = TestPartOfRecipeIngredient,
                        WeightInGrams = TestWeightIngredient,
                    },
                },
            };

            await Assert.ThrowsAsync<NullReferenceException>(async () =>
                await service.CreateAsync(TestUserId, recipeToCreate, TestRootPath));
        }

        [Fact]
        public async Task DoesRecipeEditAsyncWorksCorrectly()
        {
            Assert.True(false);
        }

        [Fact]
        public async Task DoesRecipeEditAsyncThrowsNullReferenceExceptionWhenNoSuchRecipe()
        {
            Assert.True(false);
        }

        [Fact]
        public async Task DoesRecipeEditAsyncThorwsArgumentExceptionWhenRecipeWithSuchNameAlreadyExists()
        {
            Assert.True(false);
        }

        [Fact]
        public async Task DoesRecipeEditAsyncThrowsNullReferenceExceptionWhenNoSuchCookingVessel()
        {
            Assert.True(false);
        }

        [Fact]
        public async Task DoesRecipeEditAsyncThrowsNullReferenceExceptionWhenNoSuchCategory()
        {
            Assert.True(false);
        }

        [Fact]
        public async Task DoesRecipeEditAsyncThrowsNullReferenceExceptionWhenNoSuchIngredient()
        {
            Assert.True(false);
        }

        [Fact]
        public async Task DoesRecipeDeleteAsyncWorksCorrectly()
        {
            Assert.True(false);
        }

        [Fact]
        public async Task DoesRecipeDeleteAsyncThrowsNullReferenceExceptionWhenNoSuchRecipe()
        {
            Assert.True(false);
        }

        private IRecipesService CreateMockAndConfigureService(
            IList<Recipe> recipeList,
            IList<Category> categoryList,
            IList<CategoryRecipe> categoryRecipeList,
            IList<Ingredient> ingredientList,
            IList<Nutrition> nutritionList,
            IList<RecipeIngredient> recipeIngredientList,
            IList<RecipeImage> recipeImageList,
            IList<CookingVessel> cookingVesselList,
            IList<UserRecipe> userRecipeList,
            IList<ApplicationUser> userList)
        {
            var mockRecipeRepo = new Mock<IDeletableEntityRepository<Recipe>>();
            mockRecipeRepo.Setup(x => x.All()).Returns(recipeList.AsQueryable());
            mockRecipeRepo.Setup(x => x.AllAsNoTracking())
                .Returns(new TestAsyncEnumerable<Recipe>(recipeList).AsQueryable());
            mockRecipeRepo.Setup(x => x.AddAsync(It.IsAny<Recipe>()))
                .Callback((Recipe recipe) => recipeList.Add(recipe));

            mockRecipeRepo.Setup(x => x.Delete(It.IsAny<Recipe>()))
                .Callback((Recipe recipe) => recipe.IsDeleted = true);
            mockRecipeRepo.Setup(x => x.Update(It.IsAny<Recipe>()))
                .Callback((Recipe recipe) =>
                {
                    recipeList.FirstOrDefault(x => x.Id == recipe.Id).Name = recipe.Name;
                    recipeList.FirstOrDefault(x => x.Id == recipe.Id).CookingTime = recipe.CookingTime;
                    recipeList.FirstOrDefault(x => x.Id == recipe.Id).PreparationTime = recipe.PreparationTime;
                    recipeList.FirstOrDefault(x => x.Id == recipe.Id).Portions = recipe.Portions;
                    recipeList.FirstOrDefault(x => x.Id == recipe.Id).Preparation = recipe.Preparation;
                    recipeList.FirstOrDefault(x => x.Id == recipe.Id).Notes = recipe.Notes;
                    recipeList.FirstOrDefault(x => x.Id == recipe.Id).CookingVesselId = recipe.CookingVesselId;
                    recipeList.FirstOrDefault(x => x.Id == recipe.Id).Categories = recipe.Categories;
                    recipeList.FirstOrDefault(x => x.Id == recipe.Id).Images = recipe.Images;
                    recipeList.FirstOrDefault(x => x.Id == recipe.Id).Ingredients = recipe.Ingredients;
                    recipeList.FirstOrDefault(x => x.Id == recipe.Id).Nutrition = recipe.Nutrition;
                });

            var mockCategoryRepo = new Mock<IDeletableEntityRepository<Category>>();
            mockCategoryRepo.Setup(x => x.All()).Returns(categoryList.AsQueryable());

            var mockCategoryRecipeRepo = new Mock<IDeletableEntityRepository<CategoryRecipe>>();
            mockCategoryRecipeRepo.Setup(x => x.All()).Returns(categoryRecipeList.AsQueryable());
            mockCategoryRecipeRepo.Setup(x => x.All())
                .Returns(new TestAsyncEnumerable<CategoryRecipe>(categoryRecipeList).AsQueryable());
            mockCategoryRecipeRepo.Setup(x => x.Delete(It.IsAny<CategoryRecipe>()))
                .Callback((CategoryRecipe categoryRecipe) => categoryRecipe.IsDeleted = true);
            mockCategoryRecipeRepo.Setup(x => x.HardDelete(It.IsAny<CategoryRecipe>()))
                .Callback((CategoryRecipe categoryRecipe) => categoryRecipeList.Remove(categoryRecipe));

            var mockIngredientRepo = new Mock<IDeletableEntityRepository<Ingredient>>();
            mockIngredientRepo.Setup(x => x.All()).Returns(ingredientList.AsQueryable());

            var mockNutritionRepo = new Mock<IDeletableEntityRepository<Nutrition>>();
            mockNutritionRepo.Setup(x => x.All()).Returns(nutritionList.AsQueryable());
            mockNutritionRepo.Setup(x => x.HardDelete(It.IsAny<Nutrition>()))
                .Callback((Nutrition nutrition) => nutritionList.Remove(nutrition));

            var mockIngredientRecipeRepo = new Mock<IDeletableEntityRepository<RecipeIngredient>>();
            mockIngredientRecipeRepo.Setup(x => x.All()).Returns(recipeIngredientList.AsQueryable());
            mockIngredientRecipeRepo.Setup(x => x.All())
                .Returns(new TestAsyncEnumerable<RecipeIngredient>(recipeIngredientList).AsQueryable());
            mockIngredientRecipeRepo.Setup(x => x.Delete(It.IsAny<RecipeIngredient>()))
                .Callback((RecipeIngredient recipeIngredient) => recipeIngredient.IsDeleted = true);
            mockIngredientRecipeRepo.Setup(x => x.HardDelete(It.IsAny<RecipeIngredient>()))
                .Callback((RecipeIngredient recipeIngredient) => recipeIngredientList.Remove(recipeIngredient));

            var mockImageRecipeRepo = new Mock<IDeletableEntityRepository<RecipeImage>>();
            mockImageRecipeRepo.Setup(x => x.All()).Returns(recipeImageList.AsQueryable());
            mockImageRecipeRepo.Setup(x => x.All())
                .Returns(new TestAsyncEnumerable<RecipeImage>(recipeImageList).AsQueryable());
            mockImageRecipeRepo.Setup(x => x.Delete(It.IsAny<RecipeImage>()))
                .Callback((RecipeImage recipeImage) => recipeImage.IsDeleted = true);
            mockImageRecipeRepo.Setup(x => x.HardDelete(It.IsAny<RecipeImage>()))
                .Callback((RecipeImage recipeImage) => recipeImageList.Remove(recipeImage));

            var mockCookingVesselRepo = new Mock<IDeletableEntityRepository<CookingVessel>>();
            mockCookingVesselRepo.Setup(x => x.All()).Returns(cookingVesselList.AsQueryable());

            var mockUserRecipeRepo = new Mock<IDeletableEntityRepository<UserRecipe>>();
            mockUserRecipeRepo.Setup(x => x.All())
                .Returns(new TestAsyncEnumerable<UserRecipe>(userRecipeList).AsQueryable());
            mockUserRecipeRepo.Setup(x => x.Delete(It.IsAny<UserRecipe>()))
                .Callback((UserRecipe userRecipe) => userRecipe.IsDeleted = true);

            var mockUserRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockUserRepo.Setup(x => x.All()).Returns(userList.AsQueryable());

            var mockNutritionService = new Mock<NutritionsService>(
                mockNutritionRepo.Object,
                mockIngredientRepo.Object,
                mockIngredientRecipeRepo.Object,
                mockRecipeRepo.Object);

            var service = new RecipesService(
                mockRecipeRepo.Object,
                mockIngredientRepo.Object,
                mockCategoryRepo.Object,
                mockImageRecipeRepo.Object,
                mockCategoryRecipeRepo.Object,
                mockIngredientRecipeRepo.Object,
                mockUserRecipeRepo.Object,
                mockNutritionRepo.Object,
                mockCookingVesselRepo.Object,
                mockUserRepo.Object,
                mockNutritionService.Object);

            return service;
        }
    }
}
