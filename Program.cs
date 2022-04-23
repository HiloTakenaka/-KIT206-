using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace assign2
{
    class Program
    {
        //Note that ordinarily these would (1) be stored in a settings file and (2) have some basic encryption applied
        private const string db = "hris";
        private const string user = "kit206g8a";
        private const string pass = "group8a";
        private const string server = "alacritas.cis.utas.edu.au";

        private MySqlConnection conn;

        public Program()
        {
            /*
             * Create the connection object (does not actually make the connection yet)
             * Note that the RAP case study database has the same values for its name, user name and password (to keep things simple)
             */
            string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
            conn = new MySqlConnection(connectionString);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("testing has begun");

            Program demo = new Program();

            int count = demo.GetNumberOfRecords();
            Console.WriteLine("Number of units records: {0}", count);
            Console.WriteLine();
            Console.WriteLine("Names from units table:");
            demo.ReadData();
            Console.WriteLine();
            demo.AddData();
            Console.WriteLine("Names read into a DataSet (should be the same as above):");
            demo.ReadIntoDataSet();
            Console.ReadLine();
        }

        /*
         * Using the ExecuteReader method to select from a single table
         */
        public void ReadData()
        {
            MySqlDataReader rdr = null;

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
        public void AddData()
        {

            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("insert into unit(code, title, coordinator) values ('KIT401', 'Research Methods','123465')", conn);

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
        public void ReadIntoDataSet()
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
                    Console.WriteLine("Name: {0}{1}", row["code"], row["title"]);
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
        public int GetNumberOfRecords()
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

        /*public void changeUnitCoord(int id, Unit x){
            bool has = db.Any(Staff=>Staff.id == id);
            if (has == true){
                Console.WriteLine("!!ID MATCH!!");
                //command.Commandtext
            }
        }*/
    }
}
