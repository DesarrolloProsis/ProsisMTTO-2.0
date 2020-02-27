using System;
using System.Collections.Generic;

namespace ProsisMTTO.Model
{
    public partial class Units
    {
        public Units()
        {
            Components = new HashSet<Components>();
        }

        public int UnitTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Components> Components { get; set; }
    }
}
