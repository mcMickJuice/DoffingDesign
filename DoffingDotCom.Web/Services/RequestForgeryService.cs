using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Helpers;

namespace DoffingDotCom.Web.Services
{
    public class RequestForgeryService
    {
        public const string TokenHeader = "RequestVerificationToken";

        public static string GetTokenHeaderValue()
        {
            string cookieToken, formToken;
            AntiForgery.GetTokens(null, out cookieToken, out formToken);
            return $"{cookieToken}:{formToken}";
        }

        public bool ValidateTokenHeaderValue(HttpRequestHeaders headers)
        {
            var cookieToken = string.Empty;
            var formToken = string.Empty;
            
            IEnumerable<string> outHeaders;
            if (headers.TryGetValues(TokenHeader, out outHeaders))
            {
                var tokens = outHeaders.First().Split(':');
                if (tokens.Length == 2)
                {
                    cookieToken = tokens[0].Trim();
                    formToken = tokens[1].Trim();
                }

            }

            try
            {
                AntiForgery.Validate(cookieToken, formToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}