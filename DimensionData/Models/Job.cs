using System;
using System.Collections.Generic;

namespace DimensionData.Models
{
    public partial class Job
    {
        public Job()
        {
            Employee = new HashSet<Employee>();
        }

        public int JobId { get; set; }
        public int JobInvolvement { get; set; }
        public int JobLevel { get; set; }
        public int JobSatisfaction { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
