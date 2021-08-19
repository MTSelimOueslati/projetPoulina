using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPoulinaDomain.Models
{
    public class Stock
    {
        public Guid StockId { get; set; }
        public float ValeurDuStock { get; set; }
        public DateTime DateDu { get; set; }
        public DateTime DateAu { get; set; }
        public ICollection<TraitementStock> traitementStocks  { get; set; }
    }
}
