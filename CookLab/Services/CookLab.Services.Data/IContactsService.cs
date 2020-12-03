namespace CookLab.Services.Data
{
    using System.Threading.Tasks;

    using CookLab.Models.InputModels.ContactForms;

    public interface IContactsService
    {
        Task SendEmailToAdminAsync(ContactFormInputModel inputModel, string ipAddress);
    }
}
