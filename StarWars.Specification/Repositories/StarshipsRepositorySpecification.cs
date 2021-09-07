using System.Linq;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using StarWars.Repositories;
using StarWars.Specification.Mocks;
using static TddXt.AnyRoot.Root;

namespace StarWars.Specification.Repositories
{
    public class StarshipsRepositorySpecification
    {
        [Test]
        public void Should_find_Corvette_by_id()
        {
            //Arrange
            var testWebClient = new TestWebClient();
            var starshipsRepo = new StarshipsRepository(Any.Instance<IConfiguration>(), testWebClient);

            //Act
            var luke = starshipsRepo.GetById(2);

            //Assert
            luke.Name.Should().Be("CR90 corvette");
        }

        [Test]
        public void Should_find_Corvette_by_url()
        {
            //Arrange
            var testWebClient = new TestWebClient();
            var starshipsRepo = new StarshipsRepository(Any.Instance<IConfiguration>(), testWebClient);

            //Act
            var luke = starshipsRepo.GetByUrl("https://swapi.dev/api/starships/2/");

            //Assert
            luke.Name.Should().Be("CR90 corvette");
        }

        [Test]
        public void Should_get_all_starships()
        {
            //Arrange
            var testWebClient = new TestWebClient();
            var starshipsRepo = new StarshipsRepository(Any.Instance<IConfiguration>(), testWebClient);

            //Act
            var heroes = starshipsRepo.GetAll();

            //Assert
            heroes.Count.Should().Be(10);
            heroes.First().Name.Should().Be("CR90 corvette");
            heroes.Last().Name.Should().Be("Rebel transport");
        }
    }
}
