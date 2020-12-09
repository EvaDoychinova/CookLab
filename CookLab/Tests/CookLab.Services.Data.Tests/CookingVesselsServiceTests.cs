namespace CookLab.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Data.Models.Enums;
    using CookLab.Models.InputModels.CookingVessel;
    using CookLab.Services.Data.Tests.AsyncClasses;

    using Moq;

    using Xunit;

    public class CookingVesselsServiceTests
    {
        public const string TestName = "Circle 20cm";
        public const int TestId = 2;
        public const double TestDiameter = 20;
        public const double Height = 7;

        public const string TestRecipeId = "TestRecipeId";

        [Theory]
        [InlineData(PanForm.Circle, 20, 0, 0, 7, null, 0)]
        [InlineData(PanForm.Custom, 0, 0, 0, 7, "Butterfly", 250)]
        [InlineData(PanForm.Rectangular, 0, 20, 25, 7, null, 0)]
        [InlineData(PanForm.Square, 0, 20, 0, 7, null, 0)]
        public async Task DoesCookingVesselsCreateAsyncWorkCorrectly(
            PanForm form, double diameter, double sideA, double sideB, double height, string name, double area)
        {
            var list = new List<CookingVessel>();

            var service = this.CreateMockAndConfigureService(list, new List<Recipe>());

            var newCookingVessel = new CookingVesselInputModel
            {
                Form = form,
                Diameter = diameter,
                SideA = sideA,
                SideB = sideB,
                Height = height,
                Name = name,
                Area = area,
            };

            await service.CreateAsync(newCookingVessel);
            var count = list.Count();
            var heightToCheck = list.First().Height;

            Assert.Equal(1, count);
            Assert.Equal(7d, heightToCheck);
        }

        [Fact]
        public async Task DoesCookingVesselsCreateAsyncThrowArgumentExceptionWhenSuchNameExists()
        {
            var list = new List<CookingVessel>();

            var service = this.CreateMockAndConfigureService(list, new List<Recipe>());

            var newCookingVessel = new CookingVesselInputModel
            {
                Form = PanForm.Circle,
                Diameter = 20,
                Height = 7,
            };

            await service.CreateAsync(newCookingVessel);

            await Assert.ThrowsAsync<ArgumentException>(async () => await service.CreateAsync(newCookingVessel));
        }

        [Fact]
        public async Task DoesCookingVesselsDeleteAsyncWorkCorrectly()
        {
            var list = new List<CookingVessel>
            {
                new CookingVessel
                {
                    Id = TestId,
                    Name = TestName,
                    Form = PanForm.Circle,
                    Height = 7,
                    Area = 314.33,
                    Volume = 2200.33,
                },
            };

            var recipesList = new List<Recipe>
            {
                new Recipe
                {
                    Id = TestRecipeId,
                    CookingVessel = list.First(x => x.Id == TestId),
                    CookingVesselId = TestId,
                },
            };

            var service = this.CreateMockAndConfigureService(list, recipesList);

            await service.DeleteAsync(TestId);

            Assert.True(list.First().IsDeleted);
        }

        [Theory]
        [InlineData(3, "New Name", PanForm.Circle, 7d, 314.25, 2199.3)]
        [InlineData(3, "New Name", PanForm.Circle, 7d, 313.25, 2189.4)]
        [InlineData(3, "New Name", PanForm.Circle, 7d, 300.25, 2250.4)]
        public async Task DoesCookingVesselsDeleteAsyncReassingsCookingVesselCorrectly(
            int id, string name, PanForm form, double height, double area, double volume)
        {
            var list = new List<CookingVessel>
            {
                new CookingVessel
                {
                    Id = TestId,
                    Name = TestName,
                    Form = PanForm.Circle,
                    Height = 7,
                    Area = 314.33,
                    Volume = 2200.33,
                },
                new CookingVessel
                {
                    Id = id,
                    Name = name,
                    Form = form,
                    Height = height,
                    Area = area,
                    Volume = volume,
                },
            };

            var recipesList = new List<Recipe>
            {
                new Recipe
                {
                    Id = TestRecipeId,
                    CookingVessel = list.First(x => x.Id == TestId),
                    CookingVesselId = TestId,
                },
            };

            var service = this.CreateMockAndConfigureService(list, recipesList);

            await service.DeleteAsync(TestId);

            Assert.Equal(3, recipesList.First().CookingVesselId);
        }

        [Fact]
        public async Task DoesCookingVesselsDeleteAsyncThrowNullReferenceExceptionWhenNoSuchCookingVessel()
        {
            var list = new List<CookingVessel>
            {
                new CookingVessel
                {
                    Id = TestId,
                    Name = TestName,
                    Form = PanForm.Circle,
                    Diameter = 20,
                    Height = 7,
                    Area = 314.33,
                    Volume = 2200.33,
                },
            };

            var recipesList = new List<Recipe>
            {
                new Recipe
                {
                    CookingVesselId = TestId,
                },
            };

            var service = this.CreateMockAndConfigureService(list, recipesList);

            await Assert.ThrowsAsync<NullReferenceException>(async () => await service.DeleteAsync(3));
        }

        [Fact]
        public async Task DoesGetAllCookingVesselsSelectListAsyncWorkCorrectly()
        {
            var list = new TestAsyncEnumerable<CookingVessel>(new List<CookingVessel>
            {
                new CookingVessel
                {
                    Name = TestName,
                    Form = PanForm.Circle,
                    Diameter = 20,
                    Height = 7,
                    Area = 314.33,
                    Volume = 2200.33,
                },
            }).AsQueryable();

            var mockCookingVesselsRepo = new Mock<IDeletableEntityRepository<CookingVessel>>(MockBehavior.Strict);
            mockCookingVesselsRepo.Setup(x => x.AllAsNoTracking()).Returns(list);

            var mockRecipesRepo = new Mock<IDeletableEntityRepository<Recipe>>();

            var service = new CookingVesselsService(mockCookingVesselsRepo.Object, mockRecipesRepo.Object);

            var cookingVessels = await service.GetAllCookingVesselsSelectListAsync();
            var count = cookingVessels.ToList().Count();

            Assert.Equal(1, count);
        }

        private ICookingVesselsService CreateMockAndConfigureService(IList<CookingVessel> list, IList<Recipe> recipesList)
        {
            var mockCookingVesselsRepo = new Mock<IDeletableEntityRepository<CookingVessel>>();
            mockCookingVesselsRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockCookingVesselsRepo.Setup(x => x.AddAsync(It.IsAny<CookingVessel>()))
                .Callback((CookingVessel cookingVessel) => list.Add(cookingVessel));
            mockCookingVesselsRepo.Setup(x => x.Delete(It.IsAny<CookingVessel>()))
                .Callback((CookingVessel cookingVessel) => cookingVessel.IsDeleted = true);

            var mockRecipesRepo = new Mock<IDeletableEntityRepository<Recipe>>();
            mockRecipesRepo.Setup(x => x.All()).Returns(new TestAsyncEnumerable<Recipe>(recipesList).AsQueryable());
            mockRecipesRepo.Setup(x => x.Update(It.IsAny<Recipe>()))
                .Callback((Recipe recipe) =>
                {
                    recipesList.FirstOrDefault(x => x.Id == TestRecipeId).CookingVessel = recipe.CookingVessel;
                    recipesList.FirstOrDefault(x => x.Id == TestRecipeId).CookingVesselId = recipe.CookingVesselId;
                });

            var service = new CookingVesselsService(mockCookingVesselsRepo.Object, mockRecipesRepo.Object);

            return service;
        }
    }
}
