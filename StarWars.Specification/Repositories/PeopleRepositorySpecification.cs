﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Ini;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using StarWars.Contracts.Repositories;
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
            var peopleRepo = new PeopleRepository(Any.Instance<IConfiguration>(), testWebClient);

            //Act
            var luke = peopleRepo.GetById(1);

            //Assert
            luke.Name.Should().Be("Luke Skywalker");
        }

        [Test]
        public void Should_find_Luke_by_url()
        {
            //Arrange
            var testWebClient = new TestWebClient();
            var peopleRepo = new PeopleRepository(Any.Instance<IConfiguration>(), testWebClient);

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
            var peopleRepo = new PeopleRepository(Any.Instance<IConfiguration>(), testWebClient);

            //Act
            var heroes = peopleRepo.GetAll();

            //Assert
            heroes.Count.Should().Be(10);
            heroes.First().Name.Should().Be("Luke Skywalker");
            heroes.Last().Name.Should().Be("Obi-Wan Kenobi");
        }
    }
}
