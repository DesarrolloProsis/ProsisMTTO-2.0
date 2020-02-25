using System;
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

        public ICollection<Inventory> Inventories { get; set; }
        public ICollection<DTCService> DTCServices { get; set; }
        public int UnitId { get; set; }
        public int ServiceTypeId { get; set; }
        public string Model { get; set; }
        public Boolean AutomaticSignature { get; set; }


        public virtual ICollection<ReplacementCatalog> Replacements { get; set; }

    }
}
