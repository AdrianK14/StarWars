using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
    public abstract class StarWarsRepository<TEntity> where TEntity : StarWarsEntity
    {
        private readonly string _apiUrl;
        private readonly string _apiResource;
        private readonly ILogger<TEntity> _logger;
        private readonly IWebClient _webClient;

        protected StarWarsRepository(ILogger<TEntity> logger, IConfiguration configuration, IWebClient webClient)
        {
            _apiUrl = configuration.GetApiUrl();
            var entityAttributes = typeof(TEntity).GetCustomAttributes(false);
            var entityResourceAttribute = (ResourceAttribute)entityAttributes.SingleOrDefault(x => x.GetType() == typeof(ResourceAttribute));
            _apiResource = entityResourceAttribute.Name;
            _logger = logger;
            _webClient = webClient;
        }

        protected virtual TEntity GetEntityById(int id)
        {
            _logger.LogInformation($"Sending request to StarWarsAPI | ({_apiResource}) | get by id: {id}");
            return JsonSerializer.Deserialize<TEntity>(_webClient.SendRequest(_apiUrl.CombineUrl(_apiResource).CombineUrl(id.ToString())));
        }

        protected virtual TEntity GetEntityByUrl(string url)
        {
            _logger.LogInformation($"Sending request to StarWarsAPI | ({_apiResource}) | get by url: {url}");
            return JsonSerializer.Deserialize<TEntity>(_webClient.SendRequest(url));
        }

        protected virtual List<TEntity> GetAllEntities()
        {
            _logger.LogInformation($"Sending request to StarWarsAPI | ({_apiResource}) | get all");
            return JsonSerializer.Deserialize<GetAllResponse<TEntity>>(_webClient.SendRequest(_apiUrl.CombineUrl(_apiResource))).Results;
        }
    }
}
