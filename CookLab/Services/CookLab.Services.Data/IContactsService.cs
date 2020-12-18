namespace CookLab.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CookLab.Models.InputModels.ContactForms;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface IContactsService
    {
        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<T> GetByIdAsync<T>(int id);

        Task SendEmailToAdminAsync(ContactFormInputModel inputModel);

        Task SendEmailToUserAsync(ContactFormReplyInputModel inputModel);

        //Task<IEnumerable<SelectListItem>> GetAllContactsSelectListAsync();
    }
}
