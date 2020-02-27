using System;
using System.Collections.Generic;

namespace ProsisMTTO.Model
{
    public partial class SquaresCatalogs
    {
        public SquaresCatalogs()
        {
            AdminSquares = new HashSet<AdminSquares>();
            LanesCatalogs = new HashSet<LanesCatalogs>();
        }

        public string SquareNum { get; set; }
        public string SquareName { get; set; }
        public string Delegation { get; set; }

        public virtual ICollection<AdminSquares> AdminSquares { get; set; }
        public virtual ICollection<LanesCatalogs> LanesCatalogs { get; set; }
    }
}
