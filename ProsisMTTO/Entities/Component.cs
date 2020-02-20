﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProsisMTTO.Entities
{
    public class Component
    {
        [Key]
        public int ComponentId { get; set; }
        public string ComponentName { get; set; }
        public string Year { get; set; }
        public double Price { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int ServiceTypeNum { get; set; }
        public int UnitTypeNum { get; set; }

        public ICollection<Inventory> Inventories { get; set; }
        public DTCService DTCService { get; set; }
        public ServiceType ServiceType { get; set; }
        public Unit Unit { get; set; }
    }
}
