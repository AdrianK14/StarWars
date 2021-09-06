using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using StarWars.Contracts;
using StarWars.Contracts.Factory;

namespace StarWars.Factories
{
    public class WebClientFactory : IWebClientFactory
    {
        private readonly IConfiguration _configuration;

        public WebClientFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public IRequest Create()
        {
            throw new NotImplementedException();
        }
    }
}
