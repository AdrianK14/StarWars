using StarWars.Contracts.Dto;

namespace StarWars.Contracts.Command
{
    public interface IRetrievePersonInfoCommand
    {
        IPersonInfoDto Execute();
    }
}
