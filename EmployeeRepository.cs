using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EmployeePayroll_Ado.NET
{
    internal class EmployeeRepository
    {
        public static string connString = @"Data Source = DESKTOP-ENJC2S1\SQLEXPRESS;Initial Catalog = AdoDotNetPractice;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection connection = new SqlConnection(connString);

        public bool AddEmployee(EmployeeModel employee)
        {
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(@"EmpName", employee.EmpName);
                cmd.Parameters.AddWithValue(@"PhoneNumber", employee.PhoneNumber);
                cmd.Parameters.AddWithValue(@"Address", employee.Address);
                cmd.Parameters.AddWithValue(@"Department", employee.Department);
                cmd.Parameters.AddWithValue(@"Salary", employee.Salary);
                connection.Open();
                var result = cmd.ExecuteNonQuery();
                if (result != 0)
                {
                    return true;
                }
                return false;
            }
        }

        public void GetAllEmployee()
        {
            EmployeeModel employee = new EmployeeModel();
            using (this.connection)
            {
                string query = "select * from EmployeePayroll";
                this.connection.Open();
                SqlCommand command = new SqlCommand(query, this.connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employee.EmpId = reader.GetInt32(0);
                        employee.EmpName = reader.GetString(1);
                        employee.PhoneNumber = reader.GetString(2);
                        employee.Address = reader.GetString(3);
                        employee.Department = reader.GetString(4);
                        employee.Salary = reader.GetInt32(5);
                        Console.WriteLine("{0},{1},{2},{3},{4},{5}", employee.EmpId, employee.EmpName, employee.PhoneNumber, employee.Address, employee.Department, employee.Salary);
                    }
                }
                else
                {
                    Console.WriteLine("No employee data");
                }
            }
        }

        public void UpdateEmployeeDetails()
        {
            EmployeeModel employee = new EmployeeModel();
            using (this.connection)
            {
                //Console.WriteLine()
                string updateQuery = "update EmployeePayroll set EmpName = 'Sanchit', Department = 'Manager', Salary = 45000 where EmpId = 2";
                this.connection.Open();
                SqlCommand command = new SqlCommand(updateQuery, this.connection);
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("EmployeePayrole table updated successfully");
            }
        }

        public void DeleteEmployeeDetails()
        {
            EmployeeModel employee = new EmployeeModel();
            using (this.connection)
            {
                string deleteQuery = "delete EmployeePayroll where EmpId = 2";
                this.connection.Open();
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, this.connection);
                SqlDataReader reader = deleteCommand.ExecuteReader();
                Console.WriteLine("Data deleted successfully");
            }
        }
    }
}
