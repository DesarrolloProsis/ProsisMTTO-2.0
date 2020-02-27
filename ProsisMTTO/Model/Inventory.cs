using System;
using System.Collections.Generic;

namespace ProsisMTTO.Model
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public string NumPart { get; set; }
        public string Name { get; set; }
        public int Unit { get; set; }
        public string PieceYear { get; set; }
        public string InventoryImage { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int ComponentId { get; set; }

        public virtual Components Component { get; set; }
        public virtual Dtcinventories Dtcinventories { get; set; }
    }
}
