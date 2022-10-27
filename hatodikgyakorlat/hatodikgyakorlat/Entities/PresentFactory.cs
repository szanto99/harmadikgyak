using hatodikgyakorlat.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hatodikgyakorlat.Entities
{
    public class PresentFactory:IToyFactory
    {
        public Color PresentColor { get; set; }

        public Toy CreateNew()
        {
            return new Ball(PresentColor);
        }
    }
}
