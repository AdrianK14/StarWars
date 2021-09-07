using System.Linq;
using Castle.Core.Logging;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using StarWars.Entities;
using StarWars.Repositories;
using StarWars.Specification.Mocks;
using static TddXt.AnyRoot.Root;


namespace StarWars.Specification.Repositories
{
    public class PeopleRepositorySpecification
    {
        [Test]
        public void Should_find_Luke_by_id()
        {
            //Arrange
            var testWebClient = new TestWebClient();
            var peopleRepo = new PeopleRepository(Any.Instance<ILogger<Person>>(),Any.Instance<IConfiguration>(), testWebClient);

            //Act
            var luke = peopleRepo.GetById(1);

            //Assert
            luke.Name.Should().Be("Luke Skywalker");
            luke.Height.Should().Be("172");
            luke.Mass.Should().Be("77");
            luke.BirthYear.Should().Be("19BBY");
            luke.EyeColor.Should().Be("blue");
            luke.SkinColor.Should().Be("fair");
            luke.HairColor.Should().Be("blond");
            luke.Gender.Should().Be("male");
            luke.Homeworld.Should().Be("https://swapi.dev/api/planets/1/");
        }

        [Test]
        public void Should_find_Luke_by_url()
        {
            //Arrange
            var testWebClient = new TestWebClient();
            var peopleRepo = new PeopleRepository(Any.Instance<ILogger<Person>>(), Any.Instance<IConfiguration>(), testWebClient);

            //Act
            var luke = peopleRepo.GetByUrl("https://swapi.dev/api/people/1/");

            //Assert
            luke.Name.Should().Be("Luke Skywalker");
        }

        [Test]
        public void Should_get_all_people()
        {
            //Arrange
            var testWebClient = new TestWebClient();
            var peopleRepo = new PeopleRepository(Any.Instance<ILogger<Person>>(), Any.Instance<IConfiguration>(), testWebClient);

            //Act
            var heroes = peopleRepo.GetAll();

            //Assert
            heroes.Count.Should().Be(10);
            heroes.First().Name.Should().Be("Luke Skywalker");
            heroes.Last().Name.Should().Be("Obi-Wan Kenobi");
        }
    }
}
