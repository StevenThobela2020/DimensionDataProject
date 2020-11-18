using System;
using System.Collections.Generic;

namespace DimensionData.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int DepartmentId { get; set; }
        public int EmployeeNumber { get; set; }
        public int HourlyRate { get; set; }
        public int DailyRate { get; set; }
        public int MonthlyIncome { get; set; }
        public int MonthlyRate { get; set; }
        public int PercentSalaryHike { get; set; }

        public virtual Department Department { get; set; }
        public virtual Employee EmployeeNumberNavigation { get; set; }
    }
}
