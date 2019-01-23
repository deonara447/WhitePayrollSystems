using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhitePayrollSystems
{
    public class Admin
    {
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string AccountNumber { get; set; }
        public string Password { get; set; }

        public Admin(string company, string fname, string lname, string email, string username, string phone, string account, string password)
        {
            this.CompanyName = company;
            this.FirstName = fname;
            this.LastName = lname;
            this.Email = email;
            this.Username = username;
            this.PhoneNumber = phone;
            this.AccountNumber = account;
            this.Password = password;
        }
    }
}
