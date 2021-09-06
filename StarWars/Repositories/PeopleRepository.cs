using Microsoft.Extensions.Configuration;
using StarWars.Contracts.Repositories;
using StarWars.Contracts.SwApiClient;
using StarWars.Entities;
using System.Collections.Generic;

namespace StarWars.Repositories
{
    public class PeopleRepository : StarWarsRepository<Person>, IPeopleRepository
    {
        public PeopleRepository(IConfiguration configuration, IWebClient webClient) : base(configuration, webClient) { }

        public List<Person> GetAll()
        {
            return GetAllEntities();
        }

        public Person GetById(int id)
        {
            return GetEntityById(id);
        }

        public Person GetByUrl(string url)
        {
            return GetEntityByUrl(url);
        }
    }
}
