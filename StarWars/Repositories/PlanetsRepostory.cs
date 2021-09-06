using Microsoft.Extensions.Configuration;
using StarWars.Contracts.Repositories;
using StarWars.Contracts.SwApiClient;
using StarWars.Entities;
using System.Collections.Generic;

namespace StarWars.Repositories
{
    public class PlanetsRepository : StarWarsRepository<Planet>, IPlanetsRepository
    {
        public PlanetsRepository(IConfiguration configuration, IWebClient webClient) : base(configuration, webClient) { }

        public List<Planet> GetAll()
        {
            return GetAllEntities();
        }

        public Planet GetById(int id)
        {
            return GetEntityById(id);
        }

        public Planet GetByUrl(string url)
        {
            return GetEntityByUrl(url);
        }
    }
}
