using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EmployeePayroll_Ado.NET
{
    internal class Program
    {
        static void Main()
        {
            EmployeeRepository repo = new EmployeeRepository();
            //EmployeeInput();
            // repo.GetAllEmployee();
            //repo.UpdateEmployeeDetails();
            repo.DeleteEmployeeDetails();
        }

        public static void EmployeeInput()
        {
            EmployeeRepository repo = new EmployeeRepository();
            EmployeeModel model = new EmployeeModel();
            //model.EmpName = "Pooja";
            //model.PhoneNumber = "1234567890";
            //model.Address = "#86, HSR, Bangalore";
            //model.Department = "Enginneering";
            //model.Salary = 20000;
            Console.WriteLine("Enter the name");
            model.EmpName = Console.ReadLine();
            Console.WriteLine("Enter Phone number");
            model.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter address");
            model.Address = Console.ReadLine();
            Console.WriteLine("Enter department");
            model.Department = Console.ReadLine();
            Console.WriteLine("Enter salary");
            model.Salary = int.Parse(Console.ReadLine());
            Console.WriteLine(repo.AddEmployee(model) ? "Record inserted successfully" : "Failed to add");

        }
    }
}


       