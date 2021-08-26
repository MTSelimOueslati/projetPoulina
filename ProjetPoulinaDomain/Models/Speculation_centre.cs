using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPoulinaDomain.Models
{
   public class Speculation_centre
    {
        public Guid speculation_centre_Id { get; set; }
        public Guid fk_centre { get; set; }
        public Guid fk_speculation { get; set; }
        public Centre centre { get; set; }
        public Speculation speculation { get; set; }
        
        public ICollection<Stock> ListeStock { get; set; }
    }
}
