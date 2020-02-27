using System;
using System.Collections.Generic;

namespace ProsisMTTO.Model
{
    public partial class AdminSquares
    {
        public string AdminId { get; set; }
        public string SquaresCatalogId { get; set; }
        public string NumCapufe { get; set; }
        public string NumGea { get; set; }
        public string NomOperador { get; set; }

        public virtual SquaresCatalogs SquaresCatalog { get; set; }
    }
}
