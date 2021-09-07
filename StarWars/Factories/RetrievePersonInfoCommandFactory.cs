using Microsoft.Extensions.Configuration;
using StarWars.Command;
using StarWars.Contracts.Command;
using StarWars.Contracts.Factory;
using StarWars.Extensions;

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

        public IRetrievePersonInfoCommand Create(string personName)
        {
            return new RetrievePersonInfoCommand(_personInfoDtoFactory, personName, _configuration.GetOutputPath());
        }
    }
}
