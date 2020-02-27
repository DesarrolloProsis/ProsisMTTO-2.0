using System;
using System.Collections.Generic;

namespace ProsisMTTO.Model
{
    public partial class Dtcinventories
    {
        public string DtctechnicalId { get; set; }
        public int InventoryId { get; set; }
        public DateTime DateRecordRequest { get; set; }
        public bool Authorization { get; set; }
        public string Location { get; set; }

        public virtual Dtctechnical Dtctechnical { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}
