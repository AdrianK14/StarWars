using Microsoft.Extensions.Configuration;
using StarWars.Contracts.Repositories;
using StarWars.Contracts.SwApiClient;
using StarWars.Entities;
using System.Collections.Generic;

namespace StarWars.Repositories
{
    public class FilmsRepository : StarWarsRepository<Film>, IFilmsRepository
    {
        public FilmsRepository(IConfiguration configuration, IWebClient webClient) : base(configuration, webClient) { }

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
