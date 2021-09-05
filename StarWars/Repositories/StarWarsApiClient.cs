using Microsoft.Extensions.Configuration;
using StarWars.Contracts.Repositories;

namespace StarWars.Repositories
{
    public class StarWarsApiClient : IStarWarsApiClient
    {
        public IFilmsRepository Films { get; }
        public IPeopleRepository People { get; }
        public IPlanetsRepository Planets { get; }
        public ISpeciesRepository Species { get; }
        public IStarshipsRepository Starships { get; }
        public IVehiclesRepository Vehicles { get; }

        public StarWarsApiClient(IConfiguration configuration)
        {
            Films = new FilmsRepository(configuration);
            People = new PeopleRepository(configuration);
            Planets = new PlanetsRepository(configuration);
            Species = new SpeciesRepository(configuration);
            Starships = new StarshipsRepository(configuration);
            Vehicles = new VehiclesRepository(configuration);
        }
    }
}
