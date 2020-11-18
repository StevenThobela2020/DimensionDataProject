using System;
using System.Collections.Generic;

namespace DimensionData.Models
{
    public partial class JobRole
    {
        public JobRole()
        {
            Employee = new HashSet<Employee>();
        }

        public int JobRoleId { get; set; }
        public string JobRole1 { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
