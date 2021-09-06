using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace StarWars.Contracts.Factory
{
    public interface IWebClientFactory
    {
        IRequest Create();
    }
}
