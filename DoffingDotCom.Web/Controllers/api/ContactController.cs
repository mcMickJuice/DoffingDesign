using System;
using System.Threading.Tasks;
using System.Web.Http;
using DoffingDesign.Service;
using DoffingDesign.Service.Models.Contact;

namespace DoffingDotCom.Web.Controllers.api
{
    [RoutePrefix("api/contact")]
    //TODO LOCK THIS DOWN WITH A SECURITY ATTRIBUTE
    public class ContactController : ApiController
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        [Route("contact")]
        public Task<Confirmation> Contact(ContactInformation contactInfo)
        {
            throw new NotImplementedException();
            //var confirmation = await _contactService.SendContactForm(contactInfo);
            //return confirmation;
        }

        [HttpPost]
        [Route("newsletter")]
        public async Task<Confirmation> JoinNewsletter(BasicInformation basicInfo)
        {
            var confirmation = await _contactService.JoinNewsletter(basicInfo);
            return confirmation;
        }
    }
}
