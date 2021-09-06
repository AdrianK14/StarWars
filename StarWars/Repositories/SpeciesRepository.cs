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
