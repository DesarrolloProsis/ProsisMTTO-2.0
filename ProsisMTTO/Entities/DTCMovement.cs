using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProsisMTTO.Entities
{
    public class DTCMovement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string MovementId { get; set; }
        public string DTCTechnicalId { get; set; }
        public DateTime ModificationDate { get; set; }
        public string Description { get; set; }

        public DTCTechnical DTCTechnical { get; set; }
    }
}
