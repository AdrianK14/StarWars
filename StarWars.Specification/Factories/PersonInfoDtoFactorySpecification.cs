﻿using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using StarWars.Contracts.Repositories;
using StarWars.Dto;
using StarWars.Factory;
using StarWars.Repositories;
using static TddXt.AnyRoot.Root;

namespace StarWars.Specification.Factories
{
    public class PersonInfoDtoFactorySpecification
    {
        [Test]
        public void Should_return_person_info_dto()
        {
            //Arrange
            var config = Substitute.For<IConfiguration>();

            var starWarsApiClient = new StarWarsApiClient(config);
            var personInfoDtoFactory = new PersonInfoDtoFactory(starWarsApiClient);

            //Act
            var dto = personInfoDtoFactory.Create(Any.Instance<string>());

            //Assert
            dto.Should().NotBe(null);
            dto.Should().BeOfType<PersonInfoDto>();
        }
    }
}