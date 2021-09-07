using System.Collections.Generic;
using StarWars.Dto;

namespace StarWars.Contracts.Dto
{
    public interface IPersonInfoDto
    {
        IList<FilmDto> Films { get; set; }
        IList<StarshipDto> Starships { get; set; }
        IList<VehicleDto> Vehicles { get; set; }
    }
}