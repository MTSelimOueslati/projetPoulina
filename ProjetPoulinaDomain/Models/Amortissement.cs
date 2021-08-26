﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPoulinaDomain.Models
{
    public class Amortissement
    {
        public Guid AmortissementId { get; set; }
        public DateTime DateDu { get; set; }
        public DateTime DateAu { get; set; }
        public float Prix { get; set; }
        public float TotalAmortissement { get; set; }
     
        public ICollection<Centre> centre { get; set; }
    }
}
