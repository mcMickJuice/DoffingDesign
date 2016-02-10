using System.Threading.Tasks;
using DoffingDesign.DAL;
using DoffingDesign.DAL.EntityModels;
using DoffingDesign.DAL.Mapping;
using DoffingDesign.Service;
using DoffingDesign.Service.Models.Contact;
using DoffingDesign.Test.Tools;
using DoffingDotCom.Web.Secrets;
using Moq;
using NUnit.Framework;

namespace DoffingDesign.Test.Contact.Integration
{
    [TestFixture]
    public class SqlContactService_AddEmailContactTests
    {
        private IContactService _contactService;

        [SetUp]
        public void Setup()
        {
            var connString = EnvironmentSettings.GetConnectionString("test");
            var context = new DoffingDotComModel(connString);
            var newsLetterServiceMock = new Mock<INewsletterService>();

            _contactService = new SqlContactService(context, newsLetterServiceMock.Object, new ContactMapper(), new SystemClock(), new ConsoleDiagnosticLogger());
        }

        [Test]
        public async Task SendContactInfo()
        {
            var contactInformation = new ContactInformation
            {
                Email = "mikejoyce@mike.com",
                Message = "Hi I'm a message",
                Name = "Mike",
                Website = "www.mickjuice.com"
            };

            var confirm = await _contactService.SendContactForm(contactInformation);

            Assert.IsTrue(confirm.IsSuccess);
        }

        [Test]
        public async Task SendContactInfoAndNewsletter()
        {
            var contactInformation = new ContactInformation
            {
                Email = "mikejoyceNewsletter@mike.com",
                Message = "Hi I'm a message for Newsletter",
                Name = "Newsletter",
                Website = "www.mickjuiceNewsletter.com",
                NewsletterSubscribe = true
            };

            var confirm = await _contactService.SendContactForm(contactInformation);

            Assert.IsTrue(confirm.IsSuccess);
        }
    }
}
