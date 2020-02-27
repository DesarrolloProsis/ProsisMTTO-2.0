using System;
using System.Collections.Generic;

namespace ProsisMTTO.Model
{
    public partial class LanesCatalogs
    {
        public LanesCatalogs()
        {
            Dtctechnical = new HashSet<Dtctechnical>();
        }

        public string CapufeLaneNum { get; set; }
        public string IdGare { get; set; }
        public string Lane { get; set; }
        public int LaneType { get; set; }
        public string SquaresCatalogId { get; set; }
        public int? TypeCarrilId { get; set; }

        public virtual SquaresCatalogs SquaresCatalog { get; set; }
        public virtual TypeCarrils TypeCarril { get; set; }
        public virtual ICollection<Dtctechnical> Dtctechnical { get; set; }
    }
}
