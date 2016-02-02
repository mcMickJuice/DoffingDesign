using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DoffingDesign.Service.Models.MailChimp
{
    //https://apidocs.mailchimp.com/api/2.0/lists/subscribe.php
    public class Subscribe
    {
        [JsonProperty("apikey")]
        public string ApiKey { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("email")]
        public EmailStruct Email { get; set; }

        //dont send confirmation to subscribe emails
        [JsonProperty("double_optin")]
        public bool DoubleOptIn => false;
    }

    
    public class EmailStruct
    {
        [JsonProperty("email")]
        public string Email { get; private set; }

        public EmailStruct(string email)
        {
            Email = email;
        }
    }
}
