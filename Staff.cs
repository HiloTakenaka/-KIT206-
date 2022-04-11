using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign2
{
	//enum for selecting title
public enum Title { Mr, Mrs, Ms, Mx, Dr }
	//enum for selecting campus
public enum Campus { Hobart, Launceston }
	// enum for staff category
public enum Category { Academic, Technical, Admin, Casual }

    public class Staff // staff class for creating Staff objects
    {
        public int ID { get; set; }
        public Title Title { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public Campus Campus { get; set; }
        public string Email { get; set; } 
        public string PhoneNumber { get; set; } 
        public string RoomNumber { get; set; } // e.g. SB.AR15L02272
        public string Photo { get; set; } // string is URL of image
        public Category Category { get; set; }

        // formatted string to display staff name as "Family Name, Given Name"
        public string DisplayStaffName()
        {
            return String.Format("{0} {1}", FamilyName, GivenName);
        }

        // methods for turning enum values into strings

        public string TitleString()
        {
            switch (Title)
            {
                case Title.Mr:
                    return "Mr.";
                case Title.Mrs:
                    return "Mrs.";
                case Title.Ms:
                    return "Ms.";
                case Title.Mx:
                    return "Mx.";
                case Title.Dr:
                    return "Dr.";
                default:
                    return "";
            }
        }

        public string CampusString() 
        {
            switch (Campus)
	        {
		        case Campus.Hobart:
                    return "Hobart";
                case Campus.Launceston:
                    return "Launceston";
                default:
                    return "Invalid campus.";
	        }
        }

        public string CategoryString()
        {
            switch (Category)
            {
                case Category.Academic:
                    return "Academic";
                case Category.Technical:
                    return "Technical";
                case Category.Admin:
                    return "Admin";
                case Category.Casual:
                    return "Casual";
                default:
                    return "Invalid staff.";
            }
        }
    }
}
