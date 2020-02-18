using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsisMTTO.Entities
{
    public class DTCInventory
    {
        public string DTCTechnicalId { get; set; }
        public int InventoryId { get; set; }
        public DateTime DateRecord { get; set; }
    }
}
