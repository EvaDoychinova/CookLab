namespace CookLab.Models.ViewModels.ContactForms
{
    using System;

    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class ContactFormAllViewModel : IMapFrom<ContactForm>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
