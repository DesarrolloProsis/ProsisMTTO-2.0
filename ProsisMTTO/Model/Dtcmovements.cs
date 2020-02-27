using System;
using System.Collections.Generic;

namespace ProsisMTTO.Model
{
    public partial class Dtcmovements
    {
        public string MovementId { get; set; }
        public string DtctechnicalId { get; set; }
        public DateTime ModificationDate { get; set; }
        public string Description { get; set; }

        public virtual Dtctechnical Dtctechnical { get; set; }
    }
}
