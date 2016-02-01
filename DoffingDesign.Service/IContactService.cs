using System.Threading.Tasks;
using DoffingDesign.Service.Models.Contact;

namespace DoffingDesign.Service
{
    public interface IContactService
    {
        Task<Confirmation> SendContactForm(ContactInformation information);
        Task<Confirmation> JoinNewsletter(BasicInformation information);
    }
}
