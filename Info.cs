using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhitePayrollSystems
{
    public static class Info
    {
        public static List<Admin> admins = new List<Admin>();
        public static List<Employee> employees = new List<Employee>();
        public static List<Payment> payments = new List<Payment>();
        public static List<Notification> notifications = new List<Notification>();

        public static string reportEmployeeName;
        public static DateTime lastPaymentDate;
    }
}
