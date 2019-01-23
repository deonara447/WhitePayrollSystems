using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhitePayrollSystems
{
    public class Payment
    {
        public string EmployeeName { get; set; }
        public string HoursWorked { get; set; }
        public string UsedHealthDays { get; set; }
        public string UsedBenefits { get; set; }
        public string HourlyRate { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }

        public Payment(string employee, string hours, string healthdays, string usedbenefits, string hourlyrate, string date, string amount)
        {
            this.EmployeeName = employee;
            this.HoursWorked = hours;
            this.UsedHealthDays = healthdays;
            this.UsedBenefits = usedbenefits;
            this.HourlyRate = hourlyrate;
            this.Date = date;
            this.Amount = amount;
        }
    }
}
