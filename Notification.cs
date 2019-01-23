using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhitePayrollSystems
{
    public class Notification
    {
        public string name { get; set; }
        public string date { get; set; }

        public Notification(string name, string date)
        {
            this.name = name;
            this.date = date;
        }
    }
}
