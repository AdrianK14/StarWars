using System.IO;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using StarWars.Contracts.SwApiClient;
using StarWars.Extensions;

namespace StarWars.SwApiClient
{
    public class WebClient : IWebClient
    {
        private readonly IConfiguration _configuration;

        public WebClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string SendRequest(string url)
        {
            string response;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = HttpMethod.Get.ToString();

            if (!string.IsNullOrWhiteSpace(_configuration.GetProxyUrl()))
            {
                httpWebRequest.Proxy = new WebProxy(_configuration.GetProxyUrl(), _configuration.GetProxyPort())
                {
                    Credentials = CredentialCache.DefaultCredentials
                };
            }

            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var reader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = reader.ReadToEnd();
            }
            return response;
        }
    }
}
