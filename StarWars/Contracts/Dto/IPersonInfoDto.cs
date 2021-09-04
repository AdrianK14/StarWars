using StarWars.Entities;
using System.Collections.Generic;

namespace StarWars.Contracts.Dto
{
    public interface IPersonInfoDto
    {
        IList<Film> Films { get; set; }
        Person Person { get; set; }
        IList<Starship> Starships { get; set; }
        IList<Vehicle> Vehicles { get; set; }
    }
}