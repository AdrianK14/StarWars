using Microsoft.Extensions.Configuration;
using StarWars.Contracts.Repositories;
using StarWars.Contracts.SwApiClient;
using StarWars.Entities;
using System.Collections.Generic;

namespace StarWars.Repositories
{
    public class VehiclesRepository : StarWarsRepository<Vehicle>, IVehiclesRepository
    {
        public VehiclesRepository(IConfiguration configuration, IWebClient webClient) : base(configuration, webClient) { }

        public List<Vehicle> GetAll()
        {
            return GetAllEntities();
        }

        public Vehicle GetById(int id)
        {
            return GetEntityById(id);
        }

        public Vehicle GetByUrl(string url)
        {
            return GetEntityByUrl(url);
        }
    }
}
