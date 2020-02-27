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
        [StringLength(40, MinimumLength = 10, ErrorMessage = "El campo {0} tiene un minimo de {2} y un maximo de {1} caracteres")]
        public string ManagerName { get; set; }
        [StringLength(80, MinimumLength = 10, ErrorMessage = "El campo {0} tiene un minimo de {2} y un maximo de {1} caracteres")]
        public string Position { get; set; }
        [EmailAddress]
        public string Mail { get; set; }

        public ICollection<DTCTechnical> DTCTechnical { get; set; }
        public virtual ICollection<Component> Components{ get; set; }

    }
}
