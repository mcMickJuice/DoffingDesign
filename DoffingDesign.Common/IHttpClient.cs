using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DoffingDesign.Common
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> GetAsync(Uri url);
        Task<HttpResponseMessage> PostAsync(string url, string jsonContent);
        Task<HttpResponseMessage> PostAsync(Uri url, string jsonContent);
    }

    public class HttpClientWrapper : IHttpClient
    {
        private readonly HttpClient _httpClient;

        public HttpClientWrapper()
        {
            _httpClient = new HttpClient();
        }

        public Task<HttpResponseMessage> GetAsync(string url)
        {
            return GetAsync(new Uri(url));
        }

        public Task<HttpResponseMessage> GetAsync(Uri url)
        {
            return _httpClient.GetAsync(url);
        }

        public Task<HttpResponseMessage> PostAsync(string url, string jsonContent)
        {

            return PostAsync(new Uri(url), jsonContent);
        }

        public Task<HttpResponseMessage> PostAsync(Uri url, string jsonContent)
        {
            var stringContent = new StringContent(jsonContent);
            return _httpClient.PostAsync(url, stringContent);
        }
    }
}
