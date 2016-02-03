using System;
using System.Threading.Tasks;
using System.Web.Http;
using DoffingDesign.Service;
using DoffingDesign.Service.Models.Contact;
using DoffingDotCom.Web.Filters;

namespace DoffingDotCom.Web.Controllers.api
{
    [RoutePrefix("api/contact")]
    public class ContactController : ApiController
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        [Route("")]
        public Task<Confirmation> Contact(ContactInformation contactInfo)
        {
            throw new NotImplementedException();
            //var confirmation = await _contactService.SendContactForm(contactInfo);
            //return confirmation;
        }

        [HttpPost]
        [Route("newsletter")]
        [ValidateAjaxToken]
        public async Task<Confirmation> JoinNewsletter(BasicInformation info)
        {
            var confirmation = await _contactService.JoinNewsletter(info);
            return confirmation;
        }
    }
}
