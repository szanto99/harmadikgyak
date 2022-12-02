using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KilencedikGyak.Entities
{
    class DeathProbability
    {
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public int BirthYear { get; set; }
        public double Death_Prob { get; set; }
    }
}
