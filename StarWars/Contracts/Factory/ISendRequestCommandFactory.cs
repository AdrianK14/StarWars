using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWars.Contracts.Command;

namespace StarWars.Contracts.Factory
{
    public interface ISendRequestCommandFactory
    {
        ISendRequestCommand Create();
    }
}
