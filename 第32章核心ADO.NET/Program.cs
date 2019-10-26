using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace 第32章核心ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            string select = "UPDATE Customers " +
                           "SET ContactName = 'Bob' " +
                           "WHERE ContactName = 'Bill'";
            SqlConnection conn = new SqlConnection(GetDatabaseConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand(select, conn);
            int rowsReturned = cmd.ExecuteNonQuery();
            Console.WriteLine("{0} rows returned.", rowsReturned);
            conn.Close();
        }
    }
}
