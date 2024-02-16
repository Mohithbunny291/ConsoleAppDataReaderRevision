using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace ConsoleAppDataReaderRevision
{
    internal class SqlDataAdapterRevision
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataAdapter sqlDataAdapter;
        static string conStr = "Data Source=mohith-reddy-el;Initial Catalog=EmployeesDb;Integrated Security=True;TrustServerCertificate=True";
        static DataSet dataSet;

        static void Main(string[] args)
        {
            try
            {
                con = new SqlConnection(conStr);
                cmd = new SqlCommand("Select * from Employees", con);
                con.Open();
                sqlDataAdapter = new SqlDataAdapter(cmd);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                con.Close();
                Console.WriteLine("ID \t FirstName \t LastName \t\t Designation \t Salary \t DOJ");
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    Console.Write(dr["Id"] + "\t");
                    Console.Write(dr["Fname"] + "\t\t");
                    Console.Write(dr["Lname"] + "\t\t\t");
                    Console.Write(dr["Designation"] + "\t\t");
                    Console.Write(dr["Salary"] + "\t");
                    Console.Write(dr["Doj"] + "\t");
                    Console.WriteLine();
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { con.Close(); }
        }
    }
}
