using System;
using System.Collections.Generic;

namespace ProsisMTTO.Model
{
    public partial class TypeCarrils
    {
        public TypeCarrils()
        {
            LanesCatalogs = new HashSet<LanesCatalogs>();
        }

        public int TypeCarrilId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<LanesCatalogs> LanesCatalogs { get; set; }
    }
}
