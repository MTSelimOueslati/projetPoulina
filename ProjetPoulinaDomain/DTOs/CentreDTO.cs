using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPoulinaDomain.Models
{
    public class CentreDTO
    {
        public Guid CentreId { get; set; }
        public float Delai { get; set; }
        public Guid fk_amortissement { get; set; }
        public Guid fk_speculation { get; set; }
        public DateTime DateDu { get; set; }
        public DateTime DateAu { get; set; }
    }
}
