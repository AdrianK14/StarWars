using System;
using System.Collections.Generic;
using System.Text;
using Castle.Core.Logging;
using FluentAssertions;
using Functional.Maybe;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using StarWars.Contracts.Dto;
using StarWars.Contracts.Factory;
using StarWars.Controllers;
using static TddXt.AnyRoot.Root;


namespace StarWars.Specification.Controllers
{
    public class StarWarsControllerSpecification
    {
        [Test]
        public void Should_return_person_info_dto()
        {
            //Arrange
            var retrievePersonInfoCommandFactory = Any.Instance<IRetrievePersonInfoCommandFactory>();
            var logger = Any.Instance<ILogger<StarWarsController>>();
            var starWarsController = new StarWarsController(logger, retrievePersonInfoCommandFactory);

            //Act
            var actionResult = starWarsController.GetPersonInfo("HeroName");
            var objectResult = (ObjectResult)actionResult;


            //Assert
            actionResult.Should().NotBe(null);
            actionResult.Should().BeOfType<OkObjectResult>();
            objectResult.Value.Should().NotBe(null);
        }
    }
}
