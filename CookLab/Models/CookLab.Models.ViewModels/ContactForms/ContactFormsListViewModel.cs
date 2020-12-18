namespace CookLab.Models.ViewModels.ContactForms
{
    using System.Collections.Generic;

    public class ContactFormsListViewModel : PaginationViewModel
    {
        public IEnumerable<ContactFormAllViewModel> ContactForms { get; set; }
    }
}
