using Microsoft.Extensions.Configuration;
using StarWars.Contracts.Repositories;
using StarWars.Contracts.SwApiClient;
using StarWars.Entities;
using System.Collections.Generic;

namespace StarWars.Repositories
{
    public class FilmsRepository : StarWarsRepository<Film>, IFilmsRepository
    {
        public FilmsRepository(IConfiguration configuration, IWebClient webClient) : base(configuration, webClient) { }

        List<Film> IRepository<Film>.GetAll()
        {
            return base.GetAll();
        }

        Film IRepository<Film>.GetById(int id)
        {
            return base.GetById(id);
        }

        Film IRepository<Film>.GetByUrl(string url)
        {
            return base.GetByUrl(url);
        }

    }
}
