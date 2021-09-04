﻿using StarWars.Contracts.Factory;
using StarWars.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Factory
{
    public class PersonInfoDtoFactory : IPersonInfoDtoFactory
    {
        private readonly IStarWarsApiClient _starWarsApiClient;

        public PersonInfoDtoFactory(IStarWarsApiClient starWarsApiClient)
        {
            _starWarsApiClient = starWarsApiClient;
        }

        public PersonInfoDto Create(string personName)
        {
            var personInfoDto = new PersonInfoDto();
            var person = _starWarsApiClient.People.GetAll().Where(x => x.Name == personName).FirstOrDefault();

            if (person != null)
            {
                personInfoDto.Person = person;
                foreach (var filmUrl in person.Films)
                {
                    personInfoDto.Films.Add(_starWarsApiClient.Films.GetByUrl(filmUrl));
                }

                foreach (var vehicleUrl in person.Vehicles)
                {
                    personInfoDto.Vehicles.Add(_starWarsApiClient.Vehicles.GetByUrl(vehicleUrl));
                }

                foreach (var starshipUrl in person.Starships)
                {
                    personInfoDto.Starships.Add(_starWarsApiClient.Starships.GetByUrl(starshipUrl));
                }
            }
            return personInfoDto;
        }
    }
}