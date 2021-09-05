using StarWars.Entities;
using System.Collections.Generic;

namespace StarWars.Contracts.Repositories
{
    public interface IRepository<TEntity> where TEntity : StarWarsEntity
    {
        TEntity GetById(int id);
        TEntity GetByUrl(string url);
        List<TEntity> GetAll();
    }
}
