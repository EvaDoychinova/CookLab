namespace CookLab.Services.Data.Tests
{
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

        [Fact]
        public async Task DoesCookingVesselsCreateAsyncWorkCorrectly()
        {
            var list = new List<CookingVessel>();

            var service = this.CreateMockAndConfigureService(list);

            var newCookingVessel = new CookingVesselInputModel
            {
                Form = PanForm.Circle,
                Diameter = 20,
                Height = 7,
            };

            await service.CreateAsync(newCookingVessel);
            var count = list.Count();

            Assert.Equal(1, count);
            Assert.Equal(7, list.First().Height);
        }

        [Fact]
        public async Task DoesCookingVesselsDeleteAsyncWorkCorrectly()
        {
            var list = new TestAsyncEnumerable<CookingVessel>(new List<CookingVessel>
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
            }).AsQueryable();

            var recipesList = new TestAsyncEnumerable<Recipe>(new List<Recipe>
            {
                new Recipe
                {
                    CookingVesselId = TestId,
                },
            }).AsQueryable();

            var mockCookingVesselsRepo = new Mock<IDeletableEntityRepository<CookingVessel>>();
            mockCookingVesselsRepo.Setup(x => x.All()).Returns(list);
            mockCookingVesselsRepo.Setup(x => x.Delete(It.IsAny<CookingVessel>()))
                .Callback((CookingVessel cookingVessel) => cookingVessel.IsDeleted = true);

            var mockRecipesRepo = new Mock<IDeletableEntityRepository<Recipe>>();
            mockRecipesRepo.Setup(x => x.All()).Returns(recipesList);

            var service = new CookingVesselsService(mockCookingVesselsRepo.Object, mockRecipesRepo.Object);

            await service.DeleteAsync(TestId);

            Assert.True(list.First().IsDeleted);
        }

        [Fact]
        public async Task DoesGetAllCookingVesselsSelectListAsyncWorkCrrectly()
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

        private ICookingVesselsService CreateMockAndConfigureService(IList<CookingVessel> list)
        {
            var mockCookingVesselsRepo = new Mock<IDeletableEntityRepository<CookingVessel>>();
            mockCookingVesselsRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockCookingVesselsRepo.Setup(x => x.AddAsync(It.IsAny<CookingVessel>()))
                .Callback((CookingVessel cookingVessel) => list.Add(cookingVessel));

            var mockRecipesRepo = new Mock<IDeletableEntityRepository<Recipe>>();

            var service = new CookingVesselsService(mockCookingVesselsRepo.Object, mockRecipesRepo.Object);

            return service;
        }
    }
}
