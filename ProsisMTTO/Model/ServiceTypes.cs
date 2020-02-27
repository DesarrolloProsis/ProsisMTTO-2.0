using System;
using System.Collections.Generic;

namespace ProsisMTTO.Model
{
    public partial class ServiceTypes
    {
        public ServiceTypes()
        {
            Components = new HashSet<Components>();
        }

        public int ServiceTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Components> Components { get; set; }
    }
}
