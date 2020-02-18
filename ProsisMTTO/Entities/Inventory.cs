using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProsisMTTO.Entities
{
    public class Inventory
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string NumPart { get; set; }
        public string TypeService { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public float Price { get; set; }
        public int Unit { get; set; }
        public string PieceYear { get; set; }
        public string InventoryImage { get; set; }
        public string Description { get; set; }
        public int ComponentId { get; set; }
        public bool Status { get; set; }

        public DTCInventory DTCInventory { get; set; }

    }
}
