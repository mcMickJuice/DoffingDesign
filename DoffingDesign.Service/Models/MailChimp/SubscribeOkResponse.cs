using Newtonsoft.Json;

namespace DoffingDesign.Service.Models.MailChimp
{
    public class SubscribeOkResponse
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("euid")]
        public string Euid { get; set; }

        [JsonProperty("leid")]
        public string Leid { get; set; }
    }

    public class SubscribeErrorResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}