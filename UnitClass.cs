using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KIT206
{
    public enum ClassType { Tut, Lec, Prac, Wrkshp } // enum for selecting type of class
    public enum Day { M, T, W, Th, F } // enum for selecting day of week
    public class UnitClass // Unit Class for creating unit objects
    {
        public string UnitCode { get; set; } // Unit Class / foreign key
        public Campus Campus { get; set; } // Campus enum (in Staff Class)
        public Day Day { get; set; } // Day enum
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public string Type { get; set; } // ClassType enum
        public string Room { get; set; } 
        public int Staff { get; set; } // Staff Class / foreign key

        // methods below are for turning enum values into strings

        /*public string TypeString()
        {
            switch (Type)
            {
                case ClassType.Lec:
                    return "Lecture";
                case ClassType.Prac:
                    return "Practical";
                case ClassType.Tut:
                    return "Tutorial";
                case ClassType.Wrkshp:
                    return "Workshop";
                default:
                    return "No class type selected.";
            }
        }*/ //Commented due to incompatibility with SQL. Type datatype changed to String.

        public string DayString()
        {
            switch (Day)
            {
                case Day.M:
                    return "Monday";
                case Day.T:
                    return "Tuesday";
                case Day.W:
                    return "Wednesday";
                case Day.Th:
                    return "Thursday";
                case Day.F:
                    return "Friday";
                default:
                    return "Weekday has not been selected.";
            }
        }
        public override string ToString()
        {
            //For the purposes of this week's demonstration this returns only the name
            return UnitCode;
        }


    }
}
