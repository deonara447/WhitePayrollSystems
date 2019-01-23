using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhitePayrollSystems
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            // getting number of employees
            lblNumberEmployees.Text = Info.employees.Count().ToString();


            if (Info.payments.Count > 0)
            {
                // showing payment history only if any
                // data grid only visible if payment history exists
                dataGridViewPaymentHistory.Visible = true;
                // binding data to datagrid by getting list of payments from Info class
                dataGridViewPaymentHistory.DataSource = new BindingList<Payment>(Info.payments);

            }

            if (Info.notifications.Count > 0)
            {
                // showing notification history only if any
                // data grid only visible if payment history exists
                dataGridViewNotifications.Visible = true;
                // binding data to datagrid by getting list of notifications from Info class
                dataGridViewNotifications.DataSource = new BindingList<Notification>(Info.notifications);

            }

            // updating pay cycle info by getting (15 - last payment date)
            updatePaymentCycle();


        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            // opening employee management form
            EmployeeManagement employeeManagement = new EmployeeManagement();
            employeeManagement.Show();
            this.Close();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            // opening payment management form
            PaymentManagement paymentManagement = new PaymentManagement();
            paymentManagement.Show();
            this.Close();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            // exiting application
            Application.Exit();
        }


        private void btnTimeSheet_Click(object sender, EventArgs e)
        {
            // opening Time Sheet Management form
            TimeSheetManagement timeSheetManagement = new TimeSheetManagement();
            timeSheetManagement.Show();
            this.Close();

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            // opening Reports Sheet Management form
            ReportsManagement reportsManagement = new ReportsManagement();
            reportsManagement.Show();
            this.Close();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // logging user out
            // opening login form
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void updatePaymentCycle()
        {
            // updating payment cycle by getting difference in days from last payment date
            lblPayCycle.Text = (15 - (DateTime.Today - Info.lastPaymentDate).TotalDays).ToString() + " Days";
        }
        
    }
}
