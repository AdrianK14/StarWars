using System.IO;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using StarWars.Contracts.Factory;
using StarWars.Controllers;
using StarWars.Entities;
using StarWars.Factories;
using StarWars.Repositories;
using StarWars.SwApiClient;
using TddXt.AnyRoot.Strings;
using static TddXt.AnyRoot.Root;

namespace StarWars.Specification.Controllers
{
    public class StarWarsControllerSpecification
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
        public void Should_return_valid_object()
        {
            //Arrange
            var retrievePersonInfoCommandFactory = Any.Instance<IRetrievePersonInfoCommandFactory>();
            var logger = Any.Instance<ILogger<StarWarsController>>();
            var controller = new StarWarsController(logger, retrievePersonInfoCommandFactory);

            //Act
            var actionResult = controller.GetPersonInfo(Any.String());

            //Assert
            actionResult.Should().NotBeNull();
            actionResult.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public void Should_return_bad_request()
        {
            //Arrange
            var configuration = Any.Instance<IConfiguration>();
            var logger = Any.Instance<ILogger<StarWarsController>>();
            var webClient = new WebClient(configuration);
            var peopleRepo = new PeopleRepository(Any.Instance<ILogger<Person>>(), configuration, webClient);
            var vehiclesRepo = new VehiclesRepository(Any.Instance<ILogger<Vehicle>>(), configuration, webClient);
            var starshipsRepo = new StarshipsRepository(Any.Instance<ILogger<Starship>>(), configuration, webClient);
            var filmsRepo = new FilmsRepository(Any.Instance<ILogger<Film>>(), configuration, webClient);
            var apiClient = new StarWarsApiClient(peopleRepo, filmsRepo, starshipsRepo, vehiclesRepo);
            var personInfoDtoFactory = new PersonInfoDtoFactory(Any.Instance<ILogger<PersonInfoDtoFactory>>(), apiClient);
            var retrievePersonInfoCommandFactory = new RetrievePersonInfoCommandFactory(configuration, personInfoDtoFactory);
            var controller = new StarWarsController(logger, retrievePersonInfoCommandFactory);

            //Act
            var actionResult = controller.GetPersonInfo(Any.String());

            //Assert
            actionResult.Should().NotBeNull();
            actionResult.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
