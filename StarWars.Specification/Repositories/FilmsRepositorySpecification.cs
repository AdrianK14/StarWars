using System.Linq;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using StarWars.Repositories;
using StarWars.Specification.Mocks;
using static TddXt.AnyRoot.Root;

namespace StarWars.Specification.Repositories
{
    public class filmsRepositorySpecification
    {
        [Test]
        public void Should_find_A_new_hope_by_id()
        {
            //Arrange
            var testWebClient = new TestWebClient();
            var filmsRepo = new FilmsRepository(Any.Instance<IConfiguration>(), testWebClient);

            //Act
            var film = filmsRepo.GetById(1);

            //Assert
            film.Title.Should().Be("A New Hope");
        }

        [Test]
        public void Should_find_A_new_hope_by_url()
        {
            //Arrange
            var testWebClient = new TestWebClient();
            var filmsRepo = new FilmsRepository(Any.Instance<IConfiguration>(), testWebClient);

            //Act
            var luke = filmsRepo.GetByUrl("https://swapi.dev/api/films/1/");

            //Assert
            luke.Title.Should().Be("A New Hope");
        }

        [Test]
        public void Should_get_all_films()
        {
            //Arrange
            var testWebClient = new TestWebClient();
            var filmsRepo = new FilmsRepository(Any.Instance<IConfiguration>(), testWebClient);

            //Act
            var heroes = filmsRepo.GetAll();

            //Assert
            heroes.Count.Should().Be(6);
            heroes.First().Title.Should().Be("A New Hope");
            heroes.Last().Title.Should().Be("Revenge of the Sith");
        }
    }
}
