using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll_Ado.NET
{
    internal class EmployeeModel
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
    }
}
