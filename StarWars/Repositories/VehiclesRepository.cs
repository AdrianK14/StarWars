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

        List<Vehicle> IRepository<Vehicle>.GetAll()
        {
            return base.GetAll();
        }

        Vehicle IRepository<Vehicle>.GetById(int id)
        {
            return base.GetById(id);
        }

        Vehicle IRepository<Vehicle>.GetByUrl(string url)
        {
            return base.GetByUrl(url);
        }
    }
}
