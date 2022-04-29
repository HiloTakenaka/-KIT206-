using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KIT206
{
    class Consultation
    {
        public Staff Staff { get; set; } // Staff Class / foreign key
        public Day Day { get; set; } // Day enum (in UnitClass Class)
        public int StartTime { get; set; }
        public int EndTime { get; set; }

        public override string ToString()
        {
            return "Consultation: " + Staff + Day + " " + StartTime + "-" + EndTime;
        }
    }
}
