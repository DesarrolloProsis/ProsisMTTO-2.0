using System;
using System.Collections.Generic;

namespace ProsisMTTO.Model
{
    public partial class Components
    {
        public Components()
        {
            Dtcservices = new HashSet<Dtcservices>();
            Inventory = new HashSet<Inventory>();
            ReplacementCatalogs = new HashSet<ReplacementCatalogs>();
        }

        public int ComponentId { get; set; }
        public string ComponentName { get; set; }
        public string Year { get; set; }
        public float Price { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int UnitId { get; set; }
        public int ServiceTypeId { get; set; }
        public string Model { get; set; }
        public bool AutomaticSignature { get; set; }
        public int? AgreementNumId { get; set; }

        public virtual Dtcheaders AgreementNum { get; set; }
        public virtual ServiceTypes ServiceType { get; set; }
        public virtual Units Unit { get; set; }
        public virtual ICollection<Dtcservices> Dtcservices { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<ReplacementCatalogs> ReplacementCatalogs { get; set; }
    }
}
