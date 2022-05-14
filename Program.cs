using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace KIT206
{
    abstract class Program
    {

        private static bool reportingErrors = false;

        //Note that ordinarily these would (1) be stored in a settings file and (2) have some basic encryption applied
        private const string db = "hris";
        private const string user = "kit206g8a";
        private const string pass = "group8a";
        private const string server = "alacritas.cis.utas.edu.au";

        private static MySqlConnection conn = null;

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                /*
                 * Create the connection object (does not actually make the connection yet)
                 * Note that the RAP case study database has the same values for its name, user name and password (to keep things simple)
                 */
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }

        /*
         * !!PROGRAM WILL NOT RUN IF ADDDATA TEST COMMAND IS ADDING A PRE-EXISTING UNIT!!
         */

        /*static void Main(string[] args) //for testing
        {
            
            Console.WriteLine("testing has begun");

            MySqlConnection conn = GetConnection();
            int count = GetNumberOfRecords();
            Console.WriteLine("Number of units records: {0}", count);
            Console.WriteLine();
            Console.WriteLine("Names from units table:");
            ReadData();
            Console.WriteLine();
            AddData();
            Console.WriteLine("Names read into a DataSet (should be the same as above):");
            ReadIntoDataSet();
            Console.ReadLine();
            
        }

        /*
         * Using the ExecuteReader method to select from a single table
         */
        public static void ReadData()
        {
            MySqlDataReader rdr = null;
            MySqlConnection conn = GetConnection();

            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("select code, title from unit", conn);

                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();

                // print the CategoryName of each record
                while (rdr.Read())
                {
                    //This illustrates how the raw data can be obtained using an indexer [] or a particular data type can be obtained using a GetTYPENAME() method.
                    Console.WriteLine("{0} {1}", rdr[0], rdr[1]);
                }
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        /*
         * Using the ExecuteReader method to add data into a single table
         */
        public static void AddData()
        {

            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("insert into unit(code, title, coordinator) values ('KIT421', 'SomeStuff','123456')", conn);

                // 2. Call Execute reader to get query results
                cmd.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");

                // print the CategoryName of each record

            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                conn.Close();
            }

        }

        /*
         * Using the ExecuteReader method to select from a single table
         */
        public static void ReadIntoDataSet()
        {
            try
            {
                var groupDataSet = new DataSet();
                var groupAdapter = new MySqlDataAdapter("select * from unit", conn);
                groupAdapter.Fill(groupDataSet, "unit");

                foreach (DataRow row in groupDataSet.Tables["unit"].Rows)
                {
                    //Again illustrating that indexer (based on column name) gives access to whatever data
                    //type was obtained from a given column, but can call ToString() on an entry if needed.
                    Console.WriteLine("Name: {0} {1}", row["code"], row["title"]);
                }
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public static List<UnitClass> LoadAll()
        {
            List<UnitClass> units = new List<UnitClass>();
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT unit_code, type, staff FROM class", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Note that in your assignment you will need to inspect the *type* of the
                    //employee/researcher before deciding which kind of concrete class to create.
                    units.Add(new UnitClass { UnitCode = rdr.GetString(0), Type = rdr.GetString(1), Staff = rdr.GetInt32(2) });

                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("loading staff", e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return units;
        }

        /*    
        FUNCTIONS:
        Note, not fully implemented into the program 
        */
        /*
    public class staffTest
{
        public int ID { get; set; }
        public Title title { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public Campus campus { get; set; }
        public string Email { get; set; } 
        public string PhoneNumber { get; set; } 
        public string RoomNumber { get; set; }
        public string Photo { get; set; } 
        public Category category { get; set; }
    public staffTest(int selectID, Title selectTitle, string selectGiven, string selectSur, Campus selectCampus, string selectEmail, string selectPhone, string selectRoom, string selectPhoto, Category selectCate)
    {
        ID = selectID;
	    title = selectTitle;
	    GivenName = selectGiven;
	    FamilyName = selectSur;
    	campus = selectCampus;
	    Email = selectEmail;
	    PhoneNumber = selectPhone;
	    RoomNumber = selectRoom;
	    Photo = selectPhoto;
	    category = selectCate;
    }
}	
	
	
	
public static List<staffTest> AddStaff(){
    var list = new List<staffTest>();
    int selectID;
    Title selectTitle;
    string selectGivenName;
    string selectFamilyName;
    Campus selectCampus;
    string selectEmail;
    string selectPhoneNumber;
    string selectRoomNumber;
    string selectPhoto;
    Category selectCategory;
    try
    {
    	Console.WriteLine("Please Enter the Staff ID");
    	selectID = int.Parse(Console.ReadLine());
    	Console.WriteLine("Please Enter the desired Day");
    	selectTitle = (Title)int.Parse((Console.ReadLine()));
    	Console.WriteLine("Please Enter the Staff member's given name");
    	selectGivenName = Console.ReadLine();
        Console.WriteLine("Please Enter the Staff member's surname");
    	selectFamilyName = Console.ReadLine(); 
	Console.WriteLine("Please Enter the Staff member's campus");
    	selectCampus = (Campus)int.Parse((Console.ReadLine())); 
	Console.WriteLine("Please Enter the Staff member's email");
    	selectEmail = Console.ReadLine(); 
	Console.WriteLine("Please Enter the Staff member's phone number");
    	selectPhoneNumber = Console.ReadLine(); 
	Console.WriteLine("Please Enter the Staff member's room number");
    	selectRoomNumber = Console.ReadLine(); 
	Console.WriteLine("Please Enter the Staff member's photo");
    	selectPhoto = Console.ReadLine(); 
	Console.WriteLine("Please Enter the Staff member's category");
    	selectCategory = (Category)int.Parse((Console.ReadLine())); 
        list.Add(new staffTest(selectID, selectTitle, selectGivenName, selectFamilyName, selectCampus, selectEmail, selectPhoneNumber, selectRoomNumber, selectPhoto, selectCategory));
    }
    finally
    {
        // Close the connection
        if (conn != null)
        {
            conn.Close();
        }
    }
            return list;
}
      */
        public class classTest{
            public string UnitCode { get; set; }
            public Campus campus { get; set; } 
            public Day day { get; set; } 
            public int StartTime { get; set; }
            public int EndTime { get; set; }
            public string Type { get; set; } 
            public string Room { get; set; } 
            public int Staff { get; set; } 


        public classTest(string finalUnit, Campus finalCampus, Day finalDay, int finalStart, int finalEnd, string finalType, string finalRoom, int finalStaff)
        {
            UnitCode = finalUnit;
            campus = finalCampus;
            day = finalDay;
            StartTime = finalStart;
            EndTime = finalEnd;
            Type = finalType;
            Room = finalRoom;
            Staff = finalStaff;
        }
    }	



    public static List<classTest> classAdd(){
        var list = new List<classTest>();
        String selectUnit;
        Campus selectCampus;
        Day selectDay;
        int selectStart;
        int selectEnd;
        string selectType;
        string selectRoom;
        int selectStaff;
        bool checked = false;

        try
        {
            var classDataSet = new DataSet();
            var classAdapter = new MySqlDataAdapter("select * from Unit", conn);
            classAdapter.Fill(classDataSet, "Unit");
            Console.WriteLine("Please Enter the Unit of the class you're entering");
            selectUnit = Console.ReadLine();
            Console.WriteLine("Please Enter the desired Campus");
            selectCampus = (Campus)int.Parse(Console.ReadLine());
        Console.WriteLine("Please Enter the desired Day");
            selectDay = (Day)int.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter the class start Hour");
            selectStart = int.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter the class end Hour");
            selectEnd = int.Parse(Console.ReadLine()); 
        Console.WriteLine("Please Enter the desired class Type");
            selectType = Console.ReadLine();
        Console.WriteLine("Please Enter the desired room");
            selectRoom = Console.ReadLine();
        Console.WriteLine("Please Enter the desired staff member");
            selectStaff = int.Parse(Console.ReadLine());

            foreach (DataRow row in classDataSet.Tables["Unit"].Rows)
            {
                if (row["UnitCode"] == selectUnit{
                String finalUnit = row["UnitCode"];
                if (checked == false){
             checked = true;
             list.Add(new consultationTest(finalUnit, selectCampus, selectDay, selectStart, selectEnd, selectType, selectRoom, selectStaff));
                    }
                }
            }
        }
        finally
        {
            // Close the connection
            if (conn != null)
            {
                conn.Close();
            }
        }
        return list;
    } 

            /*
        public class unitTest
        {
    	public string UnitCode { get; set; } 
        public string UnitTitle { get; set; } 
        public int UnitCoordinator { get; set; }


            public unitTest(string finalUnitCode, string finalUnitTitle, finalUnitCoor)
            {
                UnitCode = finalUnitCode;
                UnitTitle = finalUnitTitle;
	        UnitCoordinator = finalUnitCoor;
            }
        }	
	
	
	
        public void unitAdd()
        {
        var list = new List<unitTest>();
        var selectUnit;
        var selectTitle;
        var selectStaff;
        var checked = false;

            try
            {
                var unitDataSet = new DataSet();
                var unitAdapter = new MySqlDataAdapter("select * from Staff", conn);
                unitAdapter.Fill(groupDataSet, "Staff");
    	        Console.WriteLine("Please Enter the Unit code");
    	        selectUnit = Console.ReadLine();
    	        Console.WriteLine("Please Enter the desired unit name");
    	        selectTitle = Console.ReadLine();
	            Console.WriteLine("Please Enter the desired staff member");
    	        selectStaff = Console.ReadLine();

                foreach (DataRow row in consulDataSet.Tables["Staff"].Rows)
                {
                    if (row["ID"] == selectStaff{
                    var finalStaff = row["ID"];
        	        if (checked == false)
                    {
		             checked = true;
		             list.Add(new unitTest(selectUnit, selectTitle, finalStaff));
                    }
                }
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        } 
            
        public class consultationTest
        {
            public Staff staff { get; set; }
            public Day day { get; set; }
            public int startHour { get; set; }
            public int endHour { get; set; }

            public consultationTest(Staff inputStaff, Day inputDay, int inputStart, int inputEnd)
            {
                staff = inputStaff;
                day = inputDay;
                startHour = inputStart;
                endHour = inputEnd;
            }
        }



        public void consultationAdd()
        {
            var list = new List<consultationTest>();
            var staffSelect;
            var desiredDay;
            var desiredStart;
            var desiredEnd;
            var checked = false;

            try
            {
                var consulDataSet = new DataSet();
                var consulAdapter = new MySqlDataAdapter("select * from unitClass", conn);
                consulAdapter.Fill(groupDataSet, "unitClass");
                Console.WriteLine("Please Enter the Staff member you wish to consult");
                staffSelect = Console.ReadLine();
                Console.WriteLine("Please Enter the desired Day");
                desiredDay = Console.ReadLine();
                Console.WriteLine("Please Enter the consultation start Hour");
                desiredStart = Console.ReadLine();
                Console.WriteLine("Please Enter the consultation end Hour");
                desiredEnd = Console.ReadLine();

                foreach (DataRow row in consulDataSet.Tables["unitClass"].Rows)
                {
                    if (row["ID"] == staffSelect)
                    {
                        var finalStaff = row["Staff"];
                        var finalDay = desiredDay;
                        if (row[Day] == desiredDay && (row["StartHour"] < desiredEnd || row["EndHour"] > desiredStart))
                        {
                            Console.WriteLine("Please Enter Valid Hours");
                        } else if (checked == false) {
                            var finalStart = desiredStart;
                            var finalEnd = desiredEnd;
                            checked = true;
                            list.Add(new consultationTest(finalStaff, finalDay, finalStart, finalEnd));
                        }
                    }
                }
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }



            /*
             * Using the ExecuteScalar method
             * returns number of records
             */
            public static int GetNumberOfRecords()
            {
                int count = -1;
                try
                {
                    // Open the connection
                    conn.Open();

                    // 1. Instantiate a new command
                    MySqlCommand cmd = new MySqlCommand("select COUNT(*) from unit", conn);

                    // 2. Call ExecuteScalar to send command
                    // This convoluted approach is safe since cannot predict actual return type
                    count = int.Parse(cmd.ExecuteScalar().ToString());
                }
                finally
                {
                    // Close the connection
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
                return count;
            }
            }
        }
    }
}
