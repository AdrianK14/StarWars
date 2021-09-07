using Microsoft.Extensions.Configuration;
using StarWars.Contracts.Repositories;
using StarWars.Contracts.SwApiClient;
using StarWars.Entities;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace StarWars.Repositories
{
    public class StarshipsRepository : StarWarsRepository<Starship>, IStarshipsRepository
    {
        public StarshipsRepository(ILogger<Starship> logger, IConfiguration configuration, IWebClient webClient) : base(logger, configuration, webClient) { }

        public List<Starship> GetAll()
        {
            return GetAllEntities();
        }

        public Starship GetById(int id)
        {
            return GetEntityById(id);
        }

        public Starship GetByUrl(string url)
        {
            return GetEntityByUrl(url);
        }
    }
}
