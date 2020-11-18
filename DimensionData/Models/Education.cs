using System;
using System.Collections.Generic;

namespace DimensionData.Models
{
    public partial class Education
    {
        public Education()
        {
            Employee = new HashSet<Employee>();
        }

        public int EducatoinId { get; set; }
        public int Education1 { get; set; }
        public string EducationField { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
