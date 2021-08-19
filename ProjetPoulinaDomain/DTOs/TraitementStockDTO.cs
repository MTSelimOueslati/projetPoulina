using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPoulinaDomain.Models
{
    public class TraitementStockDTO
    {
        public Guid TraitementStockId { get; set; }
        public float Cout { get; set; }
        public float Amortissement { get; set; }
        public float ValeurResiduel { get; set; }
        public int EffectifRestant { get; set; }
        public StockDTO stock { get; set; }
    }
}
