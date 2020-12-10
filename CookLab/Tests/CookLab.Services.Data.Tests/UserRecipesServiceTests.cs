namespace CookLab.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;

    using Moq;

    using Xunit;

    public class UserRecipesServiceTests
    {
        private const string TestUserId = "userId";
        private const string TestRecipeId = "recipeId";

        [Fact]
        public async Task DoesAddRecipeToUserListAsyncWorkCorrectly()
        {
            var userRecipesList = new List<UserRecipe>();

            var service = this.CreateMockAndConfigureService(userRecipesList, new List<Recipe>());

            await service.AddRecipeToUserListAsync("userId", "recipeId");
            var count = userRecipesList.Count;

            Assert.Equal(1, count);
        }

        [Fact]
        public async Task DoesAddRecipeToUserListAsyncWorkCorrectlyWhenSuchUserRecipeAlreadyWasDeleted()
        {
            var userRecipesList = new List<UserRecipe>
            {
                new UserRecipe
                {
                    UserId = TestUserId,
                    RecipeId = TestRecipeId,
                    IsDeleted = true,
                },
            };

            var service = this.CreateMockAndConfigureService(userRecipesList, new List<Recipe>());

            await service.AddRecipeToUserListAsync(TestUserId, TestRecipeId);

            Assert.False(userRecipesList.First().IsDeleted);
        }

        [Fact]
        public async Task DoesRemoveRecipeFromUserListAsyncWorkCorrectly()
        {
            var userRecipesList = new List<UserRecipe>
            {
                new UserRecipe
                {
                    UserId = TestUserId,
                    RecipeId = TestRecipeId,
                    IsDeleted = true,
                },
            };

            var service = this.CreateMockAndConfigureService(userRecipesList, new List<Recipe>());

            await service.RemoveRecipeFromUserListAsync(TestUserId, TestRecipeId);

            Assert.True(userRecipesList.First().IsDeleted);
        }

        [Fact]
        public void DoesGetUsersForRecipeWorkCorrcetly()
        {
            var userRecipesList = new List<UserRecipe>
            {
                new UserRecipe
                {
                    UserId = TestUserId,
                    RecipeId = TestRecipeId,
                    IsDeleted = true,
                },
            };

            var recipesList = new List<Recipe>
            {
                new Recipe
                {
                    Id = TestRecipeId,
                    Users = new HashSet<UserRecipe>
                    {
                        userRecipesList.First(),
                    },
                },
            };

            var service = this.CreateMockAndConfigureService(userRecipesList, recipesList);

            var count = service.GetUsersForRecipe(TestRecipeId);

            Assert.Equal(1, count);
        }

        [Fact]
        public void DoesGetUsersForRecipeThrowNullReferenceExceptionWhenNoSuchRecipe()
        {
            var userRecipesList = new List<UserRecipe>
            {
                new UserRecipe
                {
                    UserId = TestUserId,
                    RecipeId = TestRecipeId,
                    IsDeleted = true,
                },
            };

            var recipesList = new List<Recipe>
            {
                new Recipe
                {
                    Id = TestRecipeId,
                    Users = new HashSet<UserRecipe>
                    {
                        userRecipesList.First(),
                    },
                },
            };

            var service = this.CreateMockAndConfigureService(userRecipesList, recipesList);

            Assert.Throws<NullReferenceException>(() => service.GetUsersForRecipe("TestRecipe2"));
        }

        private IUserRecipesService CreateMockAndConfigureService(IList<UserRecipe> userRecipesList, IList<Recipe> recipesList)
        {
            var mockUserRecipesRepo = new Mock<IDeletableEntityRepository<UserRecipe>>();
            mockUserRecipesRepo.Setup(x => x.All())
                .Returns(userRecipesList.AsQueryable());
            mockUserRecipesRepo.Setup(x => x.AllWithDeleted())
                .Returns(userRecipesList.AsQueryable());
            mockUserRecipesRepo.Setup(x => x.AddAsync(It.IsAny<UserRecipe>()))
                .Callback((UserRecipe userRecipe) => userRecipesList.Add(userRecipe));
            mockUserRecipesRepo.Setup(x => x.Delete(It.IsAny<UserRecipe>()))
                .Callback((UserRecipe userRecipe) => userRecipe.IsDeleted = true);
            mockUserRecipesRepo.Setup(x => x.Undelete(It.IsAny<UserRecipe>()))
                .Callback((UserRecipe userRecipe) => userRecipe.IsDeleted = false);

            var mockRecipesRepo = new Mock<IDeletableEntityRepository<Recipe>>();
            mockRecipesRepo.Setup(x => x.All())
                .Returns(recipesList.AsQueryable());

            var service = new UserRecipesService(mockUserRecipesRepo.Object, mockRecipesRepo.Object);

            return service;
        }
    }
}
