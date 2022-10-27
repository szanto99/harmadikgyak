﻿using hatodikgyakorlat.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hatodikgyakorlat.Entities
{
    public class CarFactory:IToyFactory
    {
        public Toy CreateNew()
        {
            return new Car();
        }
    }
}
