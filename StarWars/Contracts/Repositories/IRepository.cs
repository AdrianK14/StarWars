using StarWars.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Contracts.Repositories
{
    public interface IRepository<TEntity> where TEntity : StarWarsEntity
    {
        TEntity GetById(int id);
        TEntity GetByUrl(string url);
        List<TEntity> GetAll();
        //List<TEntity> GetPage(int pageNumber, int itemsPerPage);
    }
}
