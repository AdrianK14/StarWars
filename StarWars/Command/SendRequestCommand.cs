using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using StarWars.Contracts;
using StarWars.Contracts.Command;
using StarWars.Contracts.Factory;

namespace StarWars.Command
{
    public class SendRequestCommand : ISendRequestCommand
    {
        private readonly string _url;
        private readonly string _proxyUrl;
        private readonly string _proxyPort;
        private readonly IWebClientFactory _webClientFactory;

        public SendRequestCommand(IWebClientFactory webClientFactory, string url, string proxyUrl = null, string proxyPort = null)
        {
            _webClientFactory = webClientFactory;
            _url = url;
            _proxyUrl = proxyUrl;
            _proxyPort = proxyPort;
        }


        public string Execute()
        {
            string result;
            var client = _webClientFactory.Create();
            //httpWebRequest.Method = HttpMethod.Get.ToString();

            //if (!string.IsNullOrWhiteSpace(_proxyUrl))
            //{
            //    httpWebRequest.Proxy = new WebProxy(_proxyUrl, _proxyPort)
            //    {
            //        Credentials = CredentialCache.DefaultCredentials
            //    };
            //}

            var response = client.GetResponse(_url);
            using (var reader = new StreamReader(response.GetStream()))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}
