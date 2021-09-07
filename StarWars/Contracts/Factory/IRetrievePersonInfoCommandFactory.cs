using StarWars.Contracts.Command;

namespace StarWars.Contracts.Factory
{
    public interface IRetrievePersonInfoCommandFactory
    {
        IRetrievePersonInfoCommand Create(string personName);
    }
}