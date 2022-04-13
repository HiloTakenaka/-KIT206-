    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace assign2
    {
        //enum for selecting title
        public int staffID;
        public enum Day { Mon, Tues, Wed, Thurs, Fri }
        public int startHour;
        public int endHour;
        //enum for selecting campus
    
        // enum for staff category

        public class Consultation // Consultation Details for 
        {
            public int staffID{ get; set; }
            public enum Day { get; set; }
            public int startHour{ get; set; }
            public int endHour{ get; set; }


            // methods for turning enum values into strings

            public string DayString()
            {
                switch (Day)
                {
                case Title.Mon:
                    return "Monday";
                case Title.Tues:
                    return "Tuesday";
                case Title.Wed:
                    return "Wednesday";
                case Title.Thurs:
                    return "Thursday";
                case Title.Fri:
                    return "Friday";
                default:
                    return "";
                }
            }

        
        }
    }