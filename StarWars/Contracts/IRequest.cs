using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Contracts
{
    public interface IRequest
    {
        IResponse GetResponse(string url);
    }
}
