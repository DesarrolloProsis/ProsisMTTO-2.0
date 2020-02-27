using System;
using System.Collections.Generic;

namespace ProsisMTTO.Model
{
    public partial class ReplacementCatalogs
    {
        public int ReplacementCatalogId { get; set; }
        public string Model { get; set; }
        public int? ComponentId { get; set; }

        public virtual Components Component { get; set; }
    }
}
