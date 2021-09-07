using Microsoft.Extensions.Configuration;
using StarWars.Contracts.Repositories;
using StarWars.Contracts.SwApiClient;
using StarWars.Entities;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace StarWars.Repositories
{
    public class FilmsRepository : StarWarsRepository<Film>, IFilmsRepository
    {
        public FilmsRepository(ILogger<Film> logger, IConfiguration configuration, IWebClient webClient) : base(logger, configuration, webClient) { }

        public List<Film> GetAll()
        {
            return GetAllEntities();
        }

        public Film GetById(int id)
        {
            return GetEntityById(id);
        }

        public Film GetByUrl(string url)
        {
            return GetEntityByUrl(url);
        }
    }
}
