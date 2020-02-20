using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsisMTTO.Entities
{
    public class ServiceType
    {
        public int ServiceTypeId { get; set; }
        public string Name { get; set; }
        public ICollection<Component> Components { get; set; }
    }
}
