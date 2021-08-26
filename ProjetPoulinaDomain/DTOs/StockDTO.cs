using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPoulinaDomain.Models
{
    public class StockDTO
    {
        public Guid StockId { get; set; }
        public float ValeurDuStock { get; set; }
        public DateTime DateDu { get; set; }
        public DateTime DateAu { get; set; }
        public Guid fk_TraitementStock { get; set; }
        public Guid fk_centre { get; set; }
        public Guid fk_speculation { get; set; }
    }
}
