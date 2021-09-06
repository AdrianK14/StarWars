using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using StarWars.Contracts;

namespace StarWars.SwApiClient
{
    public class RestClient : IRequest, IResponse
    {
        public IResponse GetResponse(string url)
        {
            string response;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = HttpMethod.Get.ToString();

            //if (!string.IsNullOrWhiteSpace(_proxyUrl))
            //{
            //    httpWebRequest.Proxy = new WebProxy(_proxyUrl, _proxyPort)
            //    {
            //        Credentials = CredentialCache.DefaultCredentials
            //    };
            //}

            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var reader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = reader.ReadToEnd();
            }

            return response;
        }

        public Stream GetStream()
        {
            throw new NotImplementedException();
        }
    }
}
