using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProsisMTTO.Entities
{
    public class SquaresCatalog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SquareNum { get; set; }
        public string SquareName { get; set; }
        public string Delegation { get; set; }

        public ICollection<LanesCatalog> LanesCatalogs { get; set; }
        public ICollection<AdminSquare> AdminSquares{ get; set; }


    }
}
