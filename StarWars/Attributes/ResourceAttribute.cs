﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Attributes
{
    public class ResourceAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
