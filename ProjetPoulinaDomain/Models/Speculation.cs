using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPoulinaDomain.Models
{
    public class Speculation
    {
        public Guid SpeculationId { get; set; }
        public float Delai { get; set; }
        public Guid fk_centre { get; set; }

        public ICollection<Speculation_centre> speculation_centre { get; set; }
        public ICollection<Prix> prix { get; set; }


    }
}
