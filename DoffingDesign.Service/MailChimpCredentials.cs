namespace DoffingDesign.Service
{
    public class MailChimpCredentials
    {
        public string ApiKey { get; private set; }
        public string ApiEndpoint { get; private set; }
        public string ListId { get; private set; }

        public MailChimpCredentials(string key, string endpoint, string listId)
        {
            ApiKey = key;
            ApiEndpoint = endpoint;
            ListId = listId;
        }
    }
}