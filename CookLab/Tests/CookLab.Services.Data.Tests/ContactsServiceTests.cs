namespace CookLab.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.InputModels.ContactForms;

    using Moq;

    using Xunit;

    public class ContactsServiceTests
    {
        public const string TestContactName = "TestContactName";
        public const string TestContactEmail = "TestContactEmail@email.com";
        public const string TestContactTitle = "TestContactTitle";
        public const string TestContactMessage = "TestContactMessage";

        [Fact]
        public async Task DoesSendEmailToAdminAsyncWorkCorrectly()
        {
            var list = new List<ContactForm>();

            var service = this.CreateMockAndConfigureService(list);

            var contactFormEntity = new ContactFormInputModel
            {
                Name = TestContactName,
                Email = TestContactEmail,
                Title = TestContactTitle,
                Message = TestContactMessage,
            };

            await service.SendEmailToAdminAsync(contactFormEntity);

            Assert.Equal(TestContactName, list.First().Name);
        }

        [Fact]
        public async Task DoesSendEmailToAdminAsyncThrowsArgumentExceptionWhenSuchContactAlreadyExists()
        {
            var list = new List<ContactForm>();

            var service = this.CreateMockAndConfigureService(list);

            var contactFormEntity = new ContactFormInputModel
            {
                Name = TestContactName,
                Email = TestContactEmail,
                Title = TestContactTitle,
                Message = TestContactMessage,
            };

            await service.SendEmailToAdminAsync(contactFormEntity);

            await Assert.ThrowsAsync<ArgumentException>(async () => await service.SendEmailToAdminAsync(contactFormEntity));
        }

        private IContactsService CreateMockAndConfigureService(IList<ContactForm> list)
        {
            var mockContactFormRepo = new Mock<IDeletableEntityRepository<ContactForm>>();
            mockContactFormRepo.Setup(x => x.All())
                .Returns(list.AsQueryable());
            mockContactFormRepo.Setup(x => x.AddAsync(It.IsAny<ContactForm>()))
                .Callback((ContactForm contactForm) => list.Add(contactForm));

            var service = new ContactsService(mockContactFormRepo.Object);

            return service;
        }
    }
}
