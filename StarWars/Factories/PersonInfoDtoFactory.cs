using Microsoft.Extensions.Logging;
using StarWars.Contracts.Dto;
using StarWars.Contracts.Factory;
using StarWars.Contracts.SwApiClient;
using StarWars.Dto;
using System.Diagnostics;
using System.Linq;

namespace StarWars.Factories
{
    public class PersonInfoDtoFactory : IPersonInfoDtoFactory
    {
        private readonly ILogger<PersonInfoDtoFactory> _logger;
        private readonly IStarWarsApiClient _starWarsApiClient;

        public PersonInfoDtoFactory(ILogger<PersonInfoDtoFactory> logger, IStarWarsApiClient starWarsApiClient)
        {
            _logger = logger;
            _starWarsApiClient = starWarsApiClient;
        }

        public IPersonInfoDto Create(string personName)
        {
            var stopWatch = new Stopwatch();
            var personInfoDto = new PersonInfoDto();

            stopWatch.Start();
            var person = _starWarsApiClient.People.GetAll().FirstOrDefault(x => x.Name == personName);

            if (person != null)
            {
                foreach (var filmUrl in person.Films)
                {
                    personInfoDto.Films.Add(_starWarsApiClient.Films.GetByUrl(filmUrl).ToDto());
                }

                foreach (var vehicleUrl in person.Vehicles)
                {
                    personInfoDto.Vehicles.Add(_starWarsApiClient.Vehicles.GetByUrl(vehicleUrl).ToDto());
                }

                foreach (var starshipUrl in person.Starships)
                {
                    personInfoDto.Starships.Add(_starWarsApiClient.Starships.GetByUrl(starshipUrl).ToDto());
                }
            }
            stopWatch.Stop();
            _logger.LogInformation($"Total swapi.dev communication time: {stopWatch.ElapsedMilliseconds}ms");
            return personInfoDto;
        }
    }
}
