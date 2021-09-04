using StarWars.Contracts.Dto;
using StarWars.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Dto
{
    public class PersonInfoDto : IPersonInfoDto
    {
        public Person Person { get; set; } = new Person();
        public IList<Film> Films { get; set; } = new List<Film>();
        public IList<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public IList<Starship> Starships { get; set; } = new List<Starship>();
    }
}
