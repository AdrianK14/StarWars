using Microsoft.Extensions.Configuration;
using StarWars.Attributes;
using StarWars.Entities;
using StarWars.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StarWars.Repositories
{
    public class StarWarsRepository<TEntity> where TEntity : StarWarsEntity
    {
        private readonly string _apiUrl;
        private readonly string _proxyUrl;
        private readonly int _proxyPort;
        private readonly string _apiResource;

        protected StarWarsRepository(IConfiguration configuration)
        {
            _apiUrl = configuration.GetApiUrl();
            _proxyUrl = configuration.GetProxyUrl();
            _proxyPort = configuration.GetProxyPort();
            var entityAttributes = typeof(TEntity).GetCustomAttributes(false);
            var entityResourceAttribute = (ResourceAttribute)entityAttributes.SingleOrDefault(x => x.GetType() == typeof(ResourceAttribute));
            _apiResource = entityResourceAttribute.Name;
        }

        protected string SendRequest(string url, HttpMethod httpMethod)
        {
            string result = string.Empty;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = httpMethod.ToString();

            if (!string.IsNullOrWhiteSpace(_proxyUrl))
            {
                httpWebRequest.Proxy = new WebProxy(_proxyUrl, _proxyPort)
                {
                    Credentials = CredentialCache.DefaultCredentials
                };
            }

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }

        protected virtual TEntity GetById(int p_id)
        {
            return JsonSerializer.Deserialize<TEntity>(SendRequest(_apiUrl.CombineUrl(_apiResource).CombineUrl(p_id.ToString()), HttpMethod.Get));
        }

        protected virtual TEntity GetByUrl(string url)
        {
            return JsonSerializer.Deserialize<TEntity>(SendRequest(url, HttpMethod.Get));
        }

        protected virtual List<TEntity> GetAll()
        { 
            return JsonSerializer.Deserialize<GetAllResponse<TEntity>>(SendRequest(_apiUrl.CombineUrl(_apiResource), HttpMethod.Get)).Results;
        }
    }
}
