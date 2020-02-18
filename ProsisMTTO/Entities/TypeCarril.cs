using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsisMTTO.Entities
{
    public class TypeCarril
    {
        public int TypeCarrilId { get; set; }
        public string Name { get; set; }
        public ICollection<LanesCatalog> LanesCatalogs { get; set; }
    }
}
