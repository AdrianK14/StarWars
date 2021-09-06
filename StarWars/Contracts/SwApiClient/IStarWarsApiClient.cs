﻿using StarWars.Contracts.Repositories;

namespace StarWars.Contracts.SwApiClient
{
    public interface IStarWarsApiClient
    {
        IFilmsRepository Films { get; }
        IPeopleRepository People { get; }
        IPlanetsRepository Planets { get; }
        ISpeciesRepository Species { get; }
        IStarshipsRepository Starships { get; }
        IVehiclesRepository Vehicles { get; }
    }
}