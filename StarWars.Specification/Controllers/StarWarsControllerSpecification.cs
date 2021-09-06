using System;
using System.Collections.Generic;
using System.Text;
using Castle.Core.Logging;
using FluentAssertions;
using Functional.Maybe;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using static TddXt.AnyRoot.Root;


namespace StarWars.Specification.Controllers
{
    public class StarWarsControllerSpecification
    {
        [Test]
        public void Should_return_Luke_Skywalker_info_dto_and_save_it_to_file()
        {
            
        }
    }
}
