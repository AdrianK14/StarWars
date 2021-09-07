using System.Linq;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using StarWars.Repositories;
using StarWars.Specification.Mocks;
using static TddXt.AnyRoot.Root;

namespace StarWars.Specification.Repositories
{
    public class VehiclesFactorySpecification
    {
        [Test]
        public void Should_find_Sand_Crawler_by_id()
        {
            //Arrange
            var testWebClient = new TestWebClient();
            var peopleRepo = new VehiclesRepository(Any.Instance<IConfiguration>(), testWebClient);

            //Act
            var luke = peopleRepo.GetById(4);

            //Assert
            luke.Name.Should().Be("Sand Crawler");
        }

        [Test]
        public void Should_find_Sand_Crawler_by_url()
        {
            //Arrange
            var testWebClient = new TestWebClient();
            var peopleRepo = new VehiclesRepository(Any.Instance<IConfiguration>(), testWebClient);

            //Act
            var luke = peopleRepo.GetByUrl("https://swapi.dev/api/vehicles/4/");

            //Assert
            luke.Name.Should().Be("Sand Crawler");
        }

        [Test]
        public void Should_get_all_vehicles()
        {
            //Arrange
            var testWebClient = new TestWebClient();
            var peopleRepo = new VehiclesRepository(Any.Instance<IConfiguration>(), testWebClient);

            //Act
            var heroes = peopleRepo.GetAll();

            //Assert
            heroes.Count.Should().Be(10);
            heroes.First().Name.Should().Be("Sand Crawler");
            heroes.Last().Name.Should().Be("Sail barge");
        }
    }
}
