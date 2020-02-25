using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProsisMTTO.Entities
{
    public class DTCHeader
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string DTCHeaderId { get; set; }
        public int AgreementNum { get; set; }
        public string ManagerName { get; set; }
        public string Position { get; set; }
        public string Mail { get; set; }

        public ICollection<DTCTechnical> DTCTechnical { get; set; }
    }
}
