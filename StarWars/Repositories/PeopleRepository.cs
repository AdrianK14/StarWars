﻿using Microsoft.Extensions.Configuration;
using StarWars.Contracts.Repositories;
using StarWars.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Repositories
{
    public class PeopleRepository : StarWarsRepository<Person>, IPeopleRepository
    {
        public PeopleRepository(IConfiguration configuration) : base(configuration) { }

        List<Person> IRepository<Person>.GetAll()
        {
            return base.GetAll();
        }

        Person IRepository<Person>.GetById(int id)
        {
            return base.GetById(id);
        }

        Person IRepository<Person>.GetByUrl(string url)
        {
            return base.GetByUrl(url);
        }
    }
}