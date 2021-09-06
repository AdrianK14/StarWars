using Microsoft.Extensions.Configuration;
using StarWars.Contracts.Repositories;
using StarWars.Contracts.SwApiClient;
using StarWars.Repositories;

namespace StarWars.SwApiClient
{
    public class StarWarsApiClient : IStarWarsApiClient
    {
        public IFilmsRepository Films { get; }
        public IPeopleRepository People { get; }
        public IPlanetsRepository Planets { get; }
        public ISpeciesRepository Species { get; }
        public IStarshipsRepository Starships { get; }
        public IVehiclesRepository Vehicles { get; }

        public StarWarsApiClient(IConfiguration configuration, IWebClient webClient)
        {
            Films = new FilmsRepository(configuration, webClient);
            People = new PeopleRepository(configuration, webClient);
            Planets = new PlanetsRepository(configuration, webClient);
            Species = new SpeciesRepository(configuration, webClient);
            Starships = new StarshipsRepository(configuration, webClient);
            Vehicles = new VehiclesRepository(configuration, webClient);
        }
    }
}
