using Microsoft.Extensions.Configuration;
using StarWars.Contracts.Repositories;
using StarWars.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Repositories
{
    public class SpeciesRepository : StarWarsRepository<Species>, ISpeciesRepository
    {
        public SpeciesRepository(IConfiguration configuration) : base(configuration) { }

        List<Species> IRepository<Species>.GetAll()
        {
            return base.GetAll();
        }

        Species IRepository<Species>.GetById(int id)
        {
            return base.GetById(id);
        }

        Species IRepository<Species>.GetByUrl(string url)
        {
            return base.GetByUrl(url);
        }
    }
}
