using Microsoft.Extensions.Configuration;
using StarWars.Contracts.Repositories;
using StarWars.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Repositories
{
    public class VehiclesRepository : StarWarsRepository<Vehicle>, IVehiclesRepository
    {
        public VehiclesRepository(IConfiguration configuration) : base(configuration) { }

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
