﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPoulinaDomain.Models
{
    public class PrixDTO
    {
        public Guid PrixId { get; set; }
        public DateTime Date { get; set; }
        public float prixx { get; set; }
        public Guid fk_Speculation { get; set; }
    }
}
