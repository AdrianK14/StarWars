using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Ini;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using static TddXt.AnyRoot.Root;


namespace StarWars.Specification.Repositories
{
    public class PeopleRepositorySpecification
    {
        [Test]
        public void Should_find_person_by_id()
        {
            var config = Any.Instance<IConfiguration>();
        }
    }
}
