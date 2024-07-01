using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.Entities
{
    public class Employee
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public decimal Salary { get; set; }
        public bool Status { get; set; }
        public string MobileNumber { get; set; }
    }
}
