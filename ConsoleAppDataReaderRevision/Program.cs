using System;
using System.Data.SqlClient;
using System.Threading;

namespace ConsoleAppDataReaderRevision
{
    internal class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader sqlDataReader;
        static string conStr = "server=mohith-reddy-el;database=EmployeesDb;trusted_conniction=true";
        static void Main(string[] args)
        {
            try
            {
                con = new SqlConnection(conStr);
                cmd = new SqlCommand("Select * from Employees", con);
                con.Open();
                sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Console.WriteLine("Id: " + sqlDataReader["Id"]);
                    Console.WriteLine("Fname: " + sqlDataReader["Fname"]);
                    Console.WriteLine("Lname: " + sqlDataReader["Lname"]);
                    Console.WriteLine("Designation: " + sqlDataReader["Designation"]);
                    Console.WriteLine("Salary: " + sqlDataReader["Salary"]);
                    Console.WriteLine("Doj: " + sqlDataReader["Doj"]);
                    Thread.Sleep(1000);
                    Console.WriteLine("\n");
                }
            }catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }finally { con.Close(); }
        }
    }
}
