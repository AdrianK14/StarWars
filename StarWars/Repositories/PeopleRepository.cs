using Microsoft.Extensions.Configuration;
using StarWars.Contracts.Repositories;
using StarWars.Contracts.SwApiClient;
using StarWars.Entities;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace StarWars.Repositories
{
    public class PeopleRepository : StarWarsRepository<Person>, IPeopleRepository
    {
        public PeopleRepository(ILogger<Person> logger, IConfiguration configuration, IWebClient webClient) : base(logger, configuration, webClient) { }

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
