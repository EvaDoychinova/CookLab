namespace CookLab.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Common.Repositories;
    using CookLab.Data.Models;
    using CookLab.Models.InputModels.ContactForms;
    using CookLab.Services.Messaging;
    using Moq;

    using Xunit;

    public class ContactsServiceTests
    {
        private const string TestContactName = "TestContactName";
        private const string TestContactEmail = "TestContactEmail@email.com";
        private const string TestContactTitle = "TestContactTitle";
        private const string TestContactMessage = "TestContactMessage";

        [Fact]
        public async Task DoesSendEmailToAdminAsyncWorkCorrectly()
        {
            var list = new List<ContactForm>();

            var service = this.CreateMockAndConfigureService(list, new List<ContactFormReply>());

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

            var service = this.CreateMockAndConfigureService(list, new List<ContactFormReply>());

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

        private IContactsService CreateMockAndConfigureService(
            IList<ContactForm> list,
            IList<ContactFormReply> contactReplyList)
        {
            var mockContactFormRepo = new Mock<IRepository<ContactForm>>();
            mockContactFormRepo.Setup(x => x.All())
                .Returns(list.AsQueryable());
            mockContactFormRepo.Setup(x => x.AddAsync(It.IsAny<ContactForm>()))
                .Callback((ContactForm contactForm) => list.Add(contactForm));

            var mockContactReplyRepo = new Mock<IRepository<ContactFormReply>>();

            var mockSender = new Mock<IEmailSender>();

            var service = new ContactsService(
                mockContactFormRepo.Object,
                mockContactReplyRepo.Object,
                mockSender.Object);

            return service;
        }
    }
}
