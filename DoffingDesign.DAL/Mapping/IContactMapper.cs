using DoffingDesign.DAL.EntityModels;
using DoffingDesign.Service.Models.Contact;

namespace DoffingDesign.DAL.Mapping
{
    public interface IContactMapper
    {
        ContactInfo ToEmailContactInfo(ContactInformation contactInfo);
        ContactInfo ToNewsletterContact(BasicInformation basicInfo);
    }

    public class ContactMapper : IContactMapper
    {
        public ContactInfo ToEmailContactInfo(ContactInformation contactInfo)
        {
            return new ContactInfo
            {
                Name = contactInfo.Name,
                ContactType = ContactType.Contact,
                Message = contactInfo.Message,
                Website = contactInfo.Website,
                Email = contactInfo.Email
            };
        }

        public ContactInfo ToNewsletterContact(BasicInformation basicInfo)
        {
            return new ContactInfo
            {
                ContactType = ContactType.Newsletter,
                Email = basicInfo.Email,
                Name = basicInfo.Name
            };
        }
    }
}
