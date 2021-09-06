using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Contracts.Command
{
    public interface ISendRequestCommand
    {
        string Execute();
    }
}
