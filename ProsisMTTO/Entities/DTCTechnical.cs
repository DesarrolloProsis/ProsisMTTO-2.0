using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProsisMTTO.Entities
{
    public class DTCTechnical
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ReferenceNum { get; set; }
        public ICollection<DTCMovement> DTCMovements { get; set; }
        public string LanesCatalogId { get; set; }
        public string IdGare { get; set; }
        public int UserId { get; set; }
        public string DTCHeaderId { get; set; }
        public ICollection<DTCInventory> DTCInventories { get; set; }

        public string AxaNum { get; set; }
        public int FailureNum { get; set; }
        public string Status { get; set; }
        public DateTime FailureDate { get; set; }
        public DateTime IncidentDate { get; set; }
        public DateTime ElaborationDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public string OpinionType { get; set; }
        public string Description { get; set; }
        public string Diagnostic { get; set; }
        public string Observation { get; set; }
        public string Image { get; set; }
    }
}
