using Microsoft.Extensions.Configuration;
using StarWars.Attributes;
using StarWars.Contracts.SwApiClient;
using StarWars.Entities;
using StarWars.Extensions;
using StarWars.SwApiClient;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace StarWars.Repositories
{
    public class StarWarsRepository<TEntity> where TEntity : StarWarsEntity
    {
        private readonly string _apiUrl;
        private readonly string _apiResource;
        private readonly IWebClient _webClient;

        protected StarWarsRepository(IConfiguration configuration, IWebClient webClient)
        {
            _apiUrl = configuration.GetApiUrl();
            var entityAttributes = typeof(TEntity).GetCustomAttributes(false);
            var entityResourceAttribute = (ResourceAttribute)entityAttributes.SingleOrDefault(x => x.GetType() == typeof(ResourceAttribute));
            _apiResource = entityResourceAttribute.Name;
            _webClient = webClient;
        }

        protected virtual TEntity GetEntityById(int p_id)
        {
            return JsonSerializer.Deserialize<TEntity>(_webClient.SendRequest(_apiUrl.CombineUrl(_apiResource).CombineUrl(p_id.ToString())));
        }

        protected virtual TEntity GetEntityByUrl(string url)
        {
            return JsonSerializer.Deserialize<TEntity>(_webClient.SendRequest(url));
        }

        protected virtual List<TEntity> GetAllEntities()
        {
            return JsonSerializer.Deserialize<GetAllResponse<TEntity>>(_webClient.SendRequest(_apiUrl.CombineUrl(_apiResource))).Results;
        }
    }
}
