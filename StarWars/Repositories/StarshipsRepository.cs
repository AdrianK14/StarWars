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

        List<Starship> IRepository<Starship>.GetAll()
        {
            return base.GetAll();
        }

        Starship IRepository<Starship>.GetById(int id)
        {
            return base.GetById(id);
        }

        Starship IRepository<Starship>.GetByUrl(string url)
        {
            return base.GetByUrl(url);
        }
    }
}
