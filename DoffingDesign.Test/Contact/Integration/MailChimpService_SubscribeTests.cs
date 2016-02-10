using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoffingDesign.Common;
using DoffingDesign.Service;
using DoffingDesign.Service.Models.Contact;
using DoffingDotCom.Web.Secrets;
using NUnit.Framework;

namespace DoffingDesign.Test.Contact.Integration
{
    [TestFixture]
    public class MailChimpService_SubscribeTests
    {
        private MailChimpService _mailChimpService;

        [SetUp]
        public void Setup()
        {
            var credentials = ThirdPartyCredentials.GetCredentialsForEnvironment();
            _mailChimpService = new MailChimpService(new HttpClientWrapper(), new JsonNetSerializer(), credentials);
        }

        [Test]
        public async Task SubscribeToList()
        {
            var information = new BasicInformation { Email = "mikejoyce19@gmail.com" };
            var result = await _mailChimpService.Subscribe(information);

            Assert.IsTrue(result.WasSuccessful);
        }

        [Test]
        public async Task SubscribeToListWithDuplicateEmail()
        {
            var information = new BasicInformation { Email = "mikejoyce19@gmail.com" };
            var result = await _mailChimpService.Subscribe(information);

            Assert.IsFalse(result.WasSuccessful);
        }
    }
}
