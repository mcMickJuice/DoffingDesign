using System;
using System.Threading.Tasks;
using DoffingDesign.Common;
using DoffingDesign.Service.Models.Contact;
using DoffingDesign.Service.Models.MailChimp;
using iSynaptic.Commons;

namespace DoffingDesign.Service
{
    public class MailChimpService : INewsletterService
    {
        private readonly IHttpClient _client;
        private readonly MailChimpCredentials _credentials;
        private readonly IJsonSerializer _serializer;
        private const string SubscribeEndpoint = "lists/subscribe.json";

        public MailChimpService(IHttpClient client
            , IJsonSerializer serializer
            , MailChimpCredentials credentials
            )
        {
            _client = client;
            _credentials = credentials;
            _serializer = serializer;
        }

        public async Task<Result<SubscribeOkResponse, SubscribeErrorResponse>> Subscribe(BasicInformation information)
        {
            var subscriptionInfo = new Subscribe
            {
                ApiKey = _credentials.ApiKey,
                Email = new EmailStruct(information.Email),
                Id = _credentials.ListId
            };

            var json = _serializer.Serializer(subscriptionInfo);

            var url = string.Join("/", _credentials.ApiEndpoint, SubscribeEndpoint);
            var response = await _client.PostAsync(url, json);

            //per docs, any non-200 status code is a failure
            //TODO more descriptive error Message?
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode == false)
            {
                var errorResponse = _serializer.Deserialize<SubscribeErrorResponse>(responseString);
                return Result.Failure(errorResponse);
            }


            //check if empty Array!!!!
            var subscribeResponse = _serializer.Deserialize<SubscribeOkResponse>(responseString);

            return new Result<SubscribeOkResponse, SubscribeErrorResponse>(subscribeResponse);
        }
    }
}