using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StarWars.Command;
using StarWars.Contracts.Factory;
using StarWars.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Factory
{
    public class RetrievePersonInfoCommandFactory : IRetrievePersonInfoCommandFactory
    {
        private readonly IConfiguration _configuration;
        private readonly IPersonInfoDtoFactory _personInfoDtoFactory;

        public RetrievePersonInfoCommandFactory(IConfiguration configuration, IPersonInfoDtoFactory personInfoDtoFactory)
        {
            _configuration = configuration;
            _personInfoDtoFactory = personInfoDtoFactory;
        }

        public RetrievePersonInfoCommand Create(string personName)
        {
            return new RetrievePersonInfoCommand(_personInfoDtoFactory, personName, _configuration.GetOutputPath());
        }
    }
}
