using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace assign2
{
    class Unit
    {
        public string UnitCode { get; set; } // e.g. KIT206
        public string UnitTitle { get; set; } // e.g. Software Design & Development
        public Staff UnitCoordinator { get; set; } // Staff Class / foreign key

        // constructor for returning full unit string
        public override string ToString()
        { 
            return $"{Code} {Title}";
        }
    }
}
