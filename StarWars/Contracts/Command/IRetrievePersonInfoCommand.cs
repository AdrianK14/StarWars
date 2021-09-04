using StarWars.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Contracts.Command
{
    public interface IRetrievePersonInfoCommand
    {
        IPersonInfoDto Execute();
    }
}
