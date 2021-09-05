using Microsoft.Extensions.Configuration;
using StarWars.Contracts.Repositories;
using StarWars.Entities;
using System.Collections.Generic;

namespace StarWars.Repositories
{
    public class PlanetsRepository : StarWarsRepository<Planet>, IPlanetsRepository
    {
        public PlanetsRepository(IConfiguration configuration) : base(configuration) { }

        List<Planet> IRepository<Planet>.GetAll()
        {
            return base.GetAll();
        }

        Planet IRepository<Planet>.GetById(int id)
        {
            return base.GetById(id);
        }

        Planet IRepository<Planet>.GetByUrl(string url)
        {
            return base.GetByUrl(url);
        }
    }
}
