﻿using hatodikgyakorlat.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hatodikgyakorlat.Entities
{
    public class Present:Toy
    {
        public Color ribbon { get; set; }
        public Color box { get; set; }

        protected override void DrawImage(Graphics g)
        {
            
        }
    }
}
