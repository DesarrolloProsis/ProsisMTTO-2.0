using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProsisMTTO.Entities
{
    public class Component
    {
        public int ComponentId { get; set; }
        public string ComponentName { get; set; }
        public string Year { get; set; }
        public double Price { get; set; }

        public ICollection<Inventory> Inventories { get; set; }
    }
}
