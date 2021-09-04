using StarWars.Dto;

namespace StarWars.Contracts.Factory
{
    public interface IPersonInfoDtoFactory
    {
        PersonInfoDto Create(string personName);
    }
}