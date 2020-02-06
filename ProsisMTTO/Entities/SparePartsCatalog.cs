﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProsisMTTO.Entities
{
    public class SparePartsCatalog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string NumPart { get; set; }
        public string TypeService { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public float Price { get; set; }
        public int Unit { get; set; }
        public string PieceYear { get; set; }
        public string SparePartImage { get; set; }
        public string Description { get; set; }

        public DTCTechnical DTCTechnical { get; set; }
    }
}