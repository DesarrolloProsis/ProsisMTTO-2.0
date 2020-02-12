using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProsisMTTO.Entities
{
    public class LanesCatalog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CapufeLaneNum { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string IdGare { get; set; }
        public string Lane { get; set; }
        public int LaneType { get; set; }
        public string SquaresCatalogId { get; set; }

        public DTCTechnical DTCTechnical { get; set; }
        public TypeCarril TypeCarril { get; set; }
    }
}
