using StarWars.Contracts.Repositories;
using StarWars.Contracts.SwApiClient;

namespace StarWars.SwApiClient
{
    public class StarWarsApiClient : IStarWarsApiClient
    {
        public IFilmsRepository Films { get; }
        public IPeopleRepository People { get; }
        public IStarshipsRepository Starships { get; }
        public IVehiclesRepository Vehicles { get; }

        public StarWarsApiClient(IPeopleRepository peopleRepository, IFilmsRepository filmsRepository,
            IStarshipsRepository starshipsRepository, IVehiclesRepository vehiclesRepository)
        {
            Films = filmsRepository;
            People = peopleRepository;
            Starships = starshipsRepository;
            Vehicles = vehiclesRepository;
        }
    }
}
