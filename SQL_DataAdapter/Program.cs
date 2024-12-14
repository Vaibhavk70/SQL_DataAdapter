using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace SQL_DataAdapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            string cs = ConfigurationManager.ConnectionStrings["SQL_DA"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            //SqlDataAdapter SDA = new SqlDataAdapter("Select * from Student", con);
            SqlDataAdapter SDA = new SqlDataAdapter("StudentData", con);  // Here we pass Store Procedure.
            SDA.SelectCommand.CommandType = CommandType.StoredProcedure;
            SDA.SelectCommand.Parameters.AddWithValue("@ID", id);
            DataSet ds = new DataSet();
            SDA.Fill(ds);  // Fill method is very important method, it helps in "Open the connection" / "Execute the query" / "Also read the Data from dataset"/ and in end it Close the connection.

            foreach(DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", row[0], row[1], row[2], row[3], row[4]);
            }

            //Console.WriteLine("----------------------------");

            //DataTable dt = new DataTable();
            //SDA.Fill(dt);  

            //foreach (DataRow row in dt.Rows)
            //{
            //    Console.WriteLine("{0} {1} {2} {3} {4}", row[0], row[1], row[2], row[3], row[4]);
            //}
            Console.ReadLine(); 
        }
    }
}
