using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPoulinaDomain.Models
{
    public class SpeculationDTO
    {
        public Guid SpeculationId { get; set; }
        public float Delai { get; set; }
        public Guid fk_centre { get; set; }
    }
}
