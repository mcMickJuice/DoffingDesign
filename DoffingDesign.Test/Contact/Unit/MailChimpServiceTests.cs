using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DoffingDesign.Common;
using DoffingDesign.Service;
using DoffingDesign.Service.Models.Contact;
using DoffingDesign.Service.Models.MailChimp;
using Moq;
using NUnit.Framework;

namespace DoffingDesign.Test.Contact.Unit
{
    [TestFixture]
    public class MailChimpServiceTests
    {
        private Mock<IHttpClient> _httpClientMock;
        private MailChimpService _mailChimpService;
        private Mock<IJsonSerializer> _jsonSerializerMock;

        [SetUp]
        public void Setup()
        {
            _httpClientMock = new Mock<IHttpClient>();
            _jsonSerializerMock = new Mock<IJsonSerializer>();

            _mailChimpService = new MailChimpService(_httpClientMock.Object, _jsonSerializerMock.Object, new MailChimpCredentials("","",""));
        }

        private HttpResponseMessage GetResponse(HttpStatusCode code)
        {
            return new HttpResponseMessage(code)
            {
                Content = new StringContent("oh hi")
            };
        }

        [Test]
        public async Task ShouldReturnSuccessResultOnSuccess()
        {
            var response = GetResponse(HttpStatusCode.OK);
            _httpClientMock.Setup(h => h.PostAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(response);

            var result = await _mailChimpService.Subscribe(new BasicInformation());

            Assert.IsTrue(result.WasSuccessful);
        }

        [Test]
        public async Task ShouldReturnResultValueWithSuccess()
        {
            var response = GetResponse(HttpStatusCode.OK);
            _httpClientMock.Setup(h => h.PostAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(response);
            var subscribeResponse = new SubscribeOkResponse();
            _jsonSerializerMock.Setup(j => j.Deserialize<SubscribeOkResponse>(It.IsAny<string>()))
                .Returns(subscribeResponse);

            var result = await _mailChimpService.Subscribe(new BasicInformation());

            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(subscribeResponse, result.Value);
        }

        [Test]
        public async Task ShouldReturnFailureResultOnFailure()
        {
            var response = GetResponse(HttpStatusCode.BadRequest);
            _httpClientMock.Setup(h => h.PostAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(response);

            var result = await _mailChimpService.Subscribe(new BasicInformation());

            Assert.IsFalse(result.WasSuccessful);
        }

        [Test]
        public async Task ShouldReturnErrorObservationOnFailure()
        {
            var response = GetResponse(HttpStatusCode.BadRequest);
            _httpClientMock.Setup(h => h.PostAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(response);
            var subscribeResponse = new SubscribeErrorResponse();
            _jsonSerializerMock.Setup(j => j.Deserialize<SubscribeErrorResponse>(It.IsAny<string>()))
                .Returns(subscribeResponse);

            var result = await _mailChimpService.Subscribe(new BasicInformation());

            Assert.IsFalse(result.HasValue);
            var errorObservation = result.Observations.FirstOrDefault();
            Assert.AreEqual(subscribeResponse, errorObservation);
        }
    }
}
