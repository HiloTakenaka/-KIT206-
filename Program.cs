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
	    	    public void addConsultation{
		        
			Staff staffCheck;
			Day consulDay;
			int staffStart = 0;
			int staffEnd = 0;
			int consulStart = 0;
			int consulEnd = 0;
			selectStaff = MySqlCommand(@"SELECT Staff FROM UnitClass WHERE Staff = staffCheck");
			selectDay = MySqlCommand(@"SELECT Day FROM table_name WHERE Staff = selectStaff");
			classStartHour = MySqlCommand(@"SELECT startHour FROM UnitClass WHERE Staff = selectStaff AND Day = selectDay");
			classEndHour = MySqlCommand(@"SELECT endHour FROM UnitClass WHERE Staff = selectStaff AND Day = selectDay");
			addCmd = MySqlCommand("insert into consultation(Staff, Day, startHour, endHour) values (selectStaff, selectDay,consulStart, consulEnd)", conn);
			Console.WriteLine("Please Enter the Staff member you wish to consult");
			staffCheck = Console.ReadLine();
			selectStaff.ExecuteScalar();
			Console.WriteLine("Please Enter the Day of consultation");
			consulDay = Console.ReadLine();
			selectDay.ExecuteScalar();
			classStartHour.ExecuteScalar();
			classEndHour.ExecuteScalar();
			Console.WriteLine("Please Enter the starting hour of the consultation");
			consulStart = Console.ReadLine();
			Console.WriteLine("Please Enter the end hour of the consultation");
			consulEnd = Console.ReadLine();
			if (classStartHour > consulEnd || classEndHour < consulStart){
				addcmd.ExecuteScalar();
			} else{
				Console.WriteLine("Error: Please Enter Valid Times");
			}
		}
	    
	    public void addClass{
		        
			Staff staffCheck;
			Day classDay;
			int staffStart = 0;
			int staffEnd = 0;
			int classStart = 0;
			int classEnd = 0;
			selectStaff = MySqlCommand(@"SELECT Staff FROM UnitClass WHERE Staff = staffCheck");
			selectDay = MySqlCommand(@"SELECT Day FROM table_name WHERE Staff = selectStaff");
			classStartHour = MySqlCommand(@"SELECT startHour FROM UnitClass WHERE Staff = selectStaff AND Day = selectDay");
			classEndHour = MySqlCommand(@"SELECT endHour FROM UnitClass WHERE Staff = selectStaff AND Day = selectDay");
			addCmd = MySqlCommand("insert into unitClass(Staff, Day, startHour, endHour) values (selectStaff, selectDay,consulStart, consulEnd)", conn);
			Console.WriteLine("Please Enter the Staff member you wish to consult");
			staffCheck = Console.ReadLine();
			selectStaff.ExecuteScalar();
			Console.WriteLine("Please Enter the Day of consultation");
			consulDay = Console.ReadLine();
			selectDay.ExecuteScalar();
			classStartHour.ExecuteScalar();
			classEndHour.ExecuteScalar();
			Console.WriteLine("Please Enter the starting hour of the consultation");
			consulStart = Console.ReadLine();
			Console.WriteLine("Please Enter the end hour of the consultation");
			consulEnd = Console.ReadLine();
			if (classStartHour > classEnd || classEndHour < classStart){
				addcmd.ExecuteScalar();
			} else{
				Console.WriteLine("Error: Please Enter Valid Times");
			}
		}
                public void addStaff{
		        
			int inputID;
			Title inputTitle;
			string inputGivenName;
			string inputSurname;
			string inputEmail;
			string inputPhone;
			string inputRoom;
			string inputphoto;
			string inputCategory;
			string inputCampus;
			selectStaff = MySqlCommand(@"SELECT Staff FROM UnitClass WHERE Staff = staffCheck");
			selectDay = MySqlCommand(@"SELECT Day FROM table_name WHERE Staff = selectStaff");
			classStartHour = MySqlCommand(@"SELECT startHour FROM UnitClass WHERE Staff = selectStaff AND Day = selectDay");
			classEndHour = MySqlCommand(@"SELECT endHour FROM UnitClass WHERE Staff = selectStaff AND Day = selectDay");
			addCmd = MySqlCommand("insert into unitClass(Staff, Day, startHour, endHour) values (selectStaff, selectDay,consulStart, consulEnd)", conn);
			Console.WriteLine("Please Enter the Staff member you wish to consult");
			staffCheck = Console.ReadLine();
			selectStaff.ExecuteScalar();
			Console.WriteLine("Please Enter the Day of consultation");
			consulDay = Console.ReadLine();
			selectDay.ExecuteScalar();
			classStartHour.ExecuteScalar();
			classEndHour.ExecuteScalar();
			Console.WriteLine("Please Enter the starting hour of the consultation");
			consulStart = Console.ReadLine();
			Console.WriteLine("Please Enter the end hour of the consultation");
			consulEnd = Console.ReadLine();
			if (classStartHour > classEnd || classEndHour < classStart){
				addcmd.ExecuteScalar();
			} else{
				Console.WriteLine("Error: Please Enter Valid Times");
			}
		}
	    
	    */

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
