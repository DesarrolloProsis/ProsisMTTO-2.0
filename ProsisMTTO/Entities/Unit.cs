﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsisMTTO.Entities
{
    public class Unit
    {
        public int UnitTypeId { get; set; }
        public string Name { get; set; }
        public Component Component { get; set; }
    }
}
