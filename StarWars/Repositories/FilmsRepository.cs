using Microsoft.Extensions.Configuration;
using StarWars.Contracts.Repositories;
using StarWars.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Repositories
{
    public class FilmsRepository : StarWarsRepository<Film>, IFilmsRepository
    {
        public FilmsRepository(IConfiguration configuration) : base(configuration) { }

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
