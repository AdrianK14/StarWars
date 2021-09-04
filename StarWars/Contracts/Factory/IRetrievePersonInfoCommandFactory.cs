using StarWars.Command;

namespace StarWars.Contracts.Factory
{
    public interface IRetrievePersonInfoCommandFactory
    {
        RetrievePersonInfoCommand Create(string personName);
    }
}