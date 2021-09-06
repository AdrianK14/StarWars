using Microsoft.Extensions.Configuration;
using StarWars.Contracts.Repositories;
using StarWars.Contracts.SwApiClient;
using StarWars.Entities;
using System.Collections.Generic;

namespace StarWars.Repositories
{
    public class StarshipsRepository : StarWarsRepository<Starship>, IStarshipsRepository
    {
        public StarshipsRepository(IConfiguration configuration, IWebClient webClient) : base(configuration, webClient) { }

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
