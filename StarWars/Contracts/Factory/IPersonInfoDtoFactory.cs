using StarWars.Contracts.Dto;

namespace StarWars.Contracts.Factory
{
    public interface IPersonInfoDtoFactory
    {
        IPersonInfoDto Create(string personName);
    }
}