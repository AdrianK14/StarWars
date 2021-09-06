using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWars.Contracts.Command;
using StarWars.Contracts.Factory;

namespace StarWars.Factories
{
    public class SendRequestCommandFactory : ISendRequestCommandFactory
    {
        public SendRequestCommandFactory()
        {

        }

        public ISendRequestCommand Create()
        {
            throw new NotImplementedException();
        }
    }
}
