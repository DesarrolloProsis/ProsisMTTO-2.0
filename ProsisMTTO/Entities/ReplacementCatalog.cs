using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsisMTTO.Entities
{
    public class ReplacementCatalog
    {

        public int ReplacementCatalogId { get; set; }
        public string Model { get; set; }
        

        public virtual Component component { get; set; }

    }
}
