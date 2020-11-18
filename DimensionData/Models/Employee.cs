using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DimensionData.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Payment = new HashSet<Payment>();
        }

        public int EmployeeNumber { get; set; }
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        public int EducationId { get; set; }
        public int JobId { get; set; }
        public int JobRoleId { get; set; }
        public int Age { get; set; }
        public string Attrition { get; set; }
        public int DistanceFromHome { get; set; }
        public int EmployeeCount { get; set; }
        public int EnvironmentSatisfaction { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Over18 { get; set; }
        public string OverTime { get; set; }
        public int PerformanceRating { get; set; }
        public int RelationshipSatisfaction { get; set; }
        public int StandardHours { get; set; }
        public int StockOptionLevel { get; set; }
        public int WorkLifeBalance { get; set; }
        public string BusinessTravel { get; set; }

        public virtual Department Department { get; set; }
        public virtual Education Education { get; set; }
        public virtual Job Job { get; set; }
        public virtual JobRole JobRole { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
