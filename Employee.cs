using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhitePayrollSystems
{
    public class Employee
    {
        // employee class to store employee information
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string DOB { get; set; }
        public string EmploymentStartDate { get; set; }
        public string AccountNumber { get; set; }
        public string SocialInsuranceNumber { get; set; }
        public double PayRate { get; set; }
        public string PayCycle { get; set; }
        public string StartOfPayCycle { get; set; }
        public string AllocatedHours { get; set; }
        public string AllocatedVacation { get; set; }
        public string AllocatedHealthDays { get; set; }
        public string AllocatedBenefits { get; set; }

        // constructor for employee class
        public Employee(string fname, string lname, string phone, string email, string title, string dob, string startdate, string accountnumber, string socialinsurancenumber,
            double payrate, string paycycle, string startofpaycycle, string allocatedhours, string allocatedvacation, string allocatedhealthdays, string allocatedbenefits)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.PhoneNumber = phone;
            this.Email = email;
            this.Title = title;
            this.DOB = dob;
            this.EmploymentStartDate = startdate;
            this.AccountNumber = accountnumber;
            this.SocialInsuranceNumber = socialinsurancenumber;
            this.PayRate = payrate;
            this.PayCycle = paycycle;
            this.StartOfPayCycle = startofpaycycle;
            this.AllocatedHours = allocatedhours;
            this.AllocatedVacation = allocatedvacation;
            this.AllocatedHealthDays = allocatedhealthdays;
            this.AllocatedBenefits = allocatedbenefits;
        }
    }
}
