using System;
using System.Collections.Generic;

namespace ProsisMTTO.Model
{
    public partial class Dtcheaders
    {
        public Dtcheaders()
        {
            Components = new HashSet<Components>();
            Dtctechnical = new HashSet<Dtctechnical>();
        }

        public int AgreementNum { get; set; }
        public string ManagerName { get; set; }
        public string Position { get; set; }
        public string Mail { get; set; }

        public virtual ICollection<Components> Components { get; set; }
        public virtual ICollection<Dtctechnical> Dtctechnical { get; set; }
    }
}
