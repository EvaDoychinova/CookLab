namespace CookLab.Models.ViewModels.ContactForms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class ContactFormViewModel : IMapFrom<ContactForm>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
