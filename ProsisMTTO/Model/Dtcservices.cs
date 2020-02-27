using System;
using System.Collections.Generic;

namespace ProsisMTTO.Model
{
    public partial class Dtcservices
    {
        public string DtctechnicalId { get; set; }
        public int ComponentId { get; set; }
        public DateTime DateRecord { get; set; }

        public virtual Components Component { get; set; }
        public virtual Dtctechnical Dtctechnical { get; set; }
    }
}
