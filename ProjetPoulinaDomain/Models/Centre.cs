using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPoulinaDomain.Models
{
    public class Centre
    {
        public Guid CentreId { get; set; }
        public float Delai { get; set; }
        public Guid fk_amortissement { get; set; }
        public Amortissement amortissment { get; set; }
        public Guid fk_speculation { get; set; }

        public ICollection<Speculation_centre> speculation_centre { get; set; }
    }
}
