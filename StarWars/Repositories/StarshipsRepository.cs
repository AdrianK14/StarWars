using Microsoft.Extensions.Configuration;
using StarWars.Contracts.Repositories;
using StarWars.Entities;
using System.Collections.Generic;

namespace StarWars.Repositories
{
    public class StarshipsRepository : StarWarsRepository<Starship>, IStarshipsRepository
    {
        public StarshipsRepository(IConfiguration configuration) : base(configuration) { }

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
