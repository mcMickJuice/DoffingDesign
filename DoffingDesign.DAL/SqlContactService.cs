using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoffingDesign.DAL.EntityModels;
using DoffingDesign.DAL.Mapping;
using DoffingDesign.Service;
using DoffingDesign.Service.Models.Contact;

namespace DoffingDesign.DAL
{
    public class SqlContactService: IContactService
    {
        private readonly IDoffingDotComModel _context;
        private readonly INewsletterService _newsletterService;
        private readonly IContactMapper _mapper;
        private readonly IDiagnosticLogger _logger;

        public SqlContactService(IDoffingDotComModel context, INewsletterService newsletterService, IContactMapper mapper, IDiagnosticLogger logger)
        {
            _context = context;
            _newsletterService = newsletterService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Confirmation> SendContactForm(ContactInformation information)
        {
            var contactInfo = _mapper.ToEmailContactInfo(information);
            List<Task<Confirmation>> tasks = new List<Task<Confirmation>>();
            List<ContactInfo> infosToAdd = new List<ContactInfo> {contactInfo};
            
            if (information.NewsletterSubscribe)
            {
                var subscribeInfo = _mapper.ToNewsletterContact(information);
                infosToAdd.Add(subscribeInfo);
                //
            }
            var contactTask = InsertContactInfo(infosToAdd);
            tasks.Add(contactTask);

            var results = await Task.WhenAll(tasks);

            if (results.All(r => r.IsSuccess)) return Confirmation.Success();

            var errorMessages = results.Where(r => r.IsSuccess == false)
                .Select(r => r.ErrorMessage);


            return new Confirmation(string.Join("\r\n", errorMessages));
        }

        public async Task<Confirmation> JoinNewsletter(BasicInformation information)
        {
            //save off email address
            var result = await _newsletterService.Subscribe(information);

            if (result.WasSuccessful == false)
            {
                return new Confirmation(result.Observations.FirstOrDefault()?.Error);
            }

            return Confirmation.Success();
        }

        private async Task<Confirmation> InsertContactInfo(IEnumerable<ContactInfo> infos)
        {
            var set = _context.Set<ContactInfo>();

            set.AddRange(infos);

            try
            {
                await _context.SaveChangesAsync();
                return Confirmation.Success();
            }
            catch (Exception ex)
            {
                var msg = string.Format("Error Adding ContactInfo(s): {0}", ex.Message);
                _logger.LogError(msg);

                return new Confirmation(msg);
            }
        }
    }
}
