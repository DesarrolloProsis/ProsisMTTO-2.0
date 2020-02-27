using System;
using System.Collections.Generic;

namespace ProsisMTTO.Model
{
    public partial class Dtctechnical
    {
        public Dtctechnical()
        {
            Dtcinventories = new HashSet<Dtcinventories>();
            Dtcmovements = new HashSet<Dtcmovements>();
            Dtcservices = new HashSet<Dtcservices>();
        }

        public string ReferenceNum { get; set; }
        public int UserId { get; set; }
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
        public string LanesCatalogCapufeLaneNum { get; set; }
        public string LanesCatalogIdGare { get; set; }
        public int? AgreementNumId { get; set; }

        public virtual Dtcheaders AgreementNum { get; set; }
        public virtual LanesCatalogs LanesCatalog { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Dtcinventories> Dtcinventories { get; set; }
        public virtual ICollection<Dtcmovements> Dtcmovements { get; set; }
        public virtual ICollection<Dtcservices> Dtcservices { get; set; }
    }
}
