using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using StarWars.Command;
using StarWars.Dto;
using StarWars.Specification.Mocks;
using StarWars.SwApiClient;
using System.IO;
using System.Text.Json;
using StarWars.Entities;
using StarWars.Factories;
using StarWars.Repositories;
using static TddXt.AnyRoot.Root;

namespace StarWars.Specification.Command
{
    public class RetrievePersonInfoCommandSpecification
    {
        [SetUp]
        public void Setup()
        {
            Directory.CreateDirectory("results");
            RemoveResultFiles();
        }

        [TearDown]
        public void TearDown()
        {
            RemoveResultFiles();
        }

        private static void RemoveResultFiles()
        {
            foreach (var file in Directory.GetFiles("results"))
            {
                File.Delete(file);
            }
        }

        [Test]
        public void Should_return_Luke_Skywalker_info_dto()
        {
            //Arrange
            var webClient = new TestWebClient();
            var configuration = Any.Instance<IConfiguration>();
            var peopleRepo = new PeopleRepository(Any.Instance<ILogger<Person>>(), configuration, webClient);
            var vehiclesRepo = new VehiclesRepository(Any.Instance<ILogger<Vehicle>>(), configuration, webClient);
            var starshipsRepo = new StarshipsRepository(Any.Instance<ILogger<Starship>>(), configuration, webClient);
            var filmsRepo = new FilmsRepository(Any.Instance<ILogger<Film>>(), configuration, webClient);
            var apiClient = new StarWarsApiClient(peopleRepo, filmsRepo, starshipsRepo, vehiclesRepo);
            var personInfoDtoFactory = new PersonInfoDtoFactory(Any.Instance<ILogger<PersonInfoDtoFactory>>(), apiClient);
            var retrieveInfoCommand = new RetrievePersonInfoCommand(personInfoDtoFactory, "Luke Skywalker", "results");

            //Act
            var dto = retrieveInfoCommand.Execute();

            //Assert
            dto.Should().NotBeNull();
            dto.Should().BeOfType(typeof(PersonInfoDto));
            dto.Films.Count.Should().Be(4);
            dto.Vehicles.Count.Should().Be(2);
            dto.Starships.Count.Should().Be(2);
        }

        [Test]
        public void Should_save_valid_json_to_file()
        {
            //Arrange
            var webClient = new TestWebClient();
            var configuration = Any.Instance<IConfiguration>();
            var peopleRepo = new PeopleRepository(Any.Instance<ILogger<Person>>(), configuration, webClient);
            var vehiclesRepo = new VehiclesRepository(Any.Instance<ILogger<Vehicle>>(), configuration, webClient);
            var starshipsRepo = new StarshipsRepository(Any.Instance<ILogger<Starship>>(), configuration, webClient);
            var filmsRepo = new FilmsRepository(Any.Instance<ILogger<Film>>(), configuration, webClient);
            var apiClient = new StarWarsApiClient(peopleRepo, filmsRepo, starshipsRepo, vehiclesRepo);
            var personInfoDtoFactory = new PersonInfoDtoFactory(Any.Instance<ILogger<PersonInfoDtoFactory>>(), apiClient);
            var retrieveInfoCommand = new RetrievePersonInfoCommand(personInfoDtoFactory, "Luke Skywalker", "results");

            //Act
            retrieveInfoCommand.Execute();
            var dto = JsonSerializer.Deserialize<PersonInfoDto>(File.ReadAllText(Directory.GetFiles("results", "*Luke_Skywalker.json")[0]));

            //Assert
            dto.Should().NotBeNull();
            dto.Should().BeOfType(typeof(PersonInfoDto));
        }
    }
}