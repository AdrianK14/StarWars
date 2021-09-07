using StarWars.Contracts.Dto;
using System.Collections.Generic;

namespace StarWars.Dto
{
    public class PersonInfoDto : IPersonInfoDto
    {
        public IList<FilmDto> Films { get; set; } = new List<FilmDto>();
        public IList<VehicleDto> Vehicles { get; set; } = new List<VehicleDto>();
        public IList<StarshipDto> Starships { get; set; } = new List<StarshipDto>();
    }
}
