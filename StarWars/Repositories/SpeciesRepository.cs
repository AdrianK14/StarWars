using Microsoft.Extensions.Configuration;
using StarWars.Contracts.Repositories;
using StarWars.Contracts.SwApiClient;
using StarWars.Entities;
using System.Collections.Generic;

namespace StarWars.Repositories
{
    public class SpeciesRepository : StarWarsRepository<Species>, ISpeciesRepository
    {
        public SpeciesRepository(IConfiguration configuration, IWebClient webClient) : base(configuration, webClient) { }

        public List<Species> GetAll()
        {
            return GetAllEntities();
        }

        public Species GetById(int id)
        {
            return GetEntityById(id);
        }

        public Species GetByUrl(string url)
        {
            return GetEntityByUrl(url);
        }
    }
}
