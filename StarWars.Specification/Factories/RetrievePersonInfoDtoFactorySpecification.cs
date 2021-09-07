using FluentAssertions;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using StarWars.Command;
using StarWars.Contracts.Factory;
using StarWars.Factory;
using TddXt.AnyRoot.Strings;
using static TddXt.AnyRoot.Root;

namespace StarWars.Specification.Factories
{
    public class RetrievePersonInfoDtoCommandFactorySpecification
    {
        [Test]
        public void Should_return_retrieve_person_info_command()
        {
            //Arrange
            var personName = Any.String();
            var configuration = Any.Instance<IConfiguration>();
            var personInfoDtoFactory = Any.Instance<IPersonInfoDtoFactory>();
            var retrievePersonInfoCommandFactory = new RetrievePersonInfoCommandFactory(configuration, personInfoDtoFactory);

            //Act
            var command = retrievePersonInfoCommandFactory.Create(personName);

            //Assert
            command.Should().NotBeNull();
            command.Should().BeOfType<RetrievePersonInfoCommand>();
        }
    }
}
