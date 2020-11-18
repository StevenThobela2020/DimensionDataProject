using System;
using System.Collections.Generic;

namespace DimensionData.Models
{
    public partial class Department
    {
        public Department()
        {
            EmpHistory = new HashSet<EmpHistory>();
            Employee = new HashSet<Employee>();
            Payment = new HashSet<Payment>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<EmpHistory> EmpHistory { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
