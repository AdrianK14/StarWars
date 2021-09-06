using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Contracts
{
    public interface IResponse
    {
        Stream GetStream();
    }
}
