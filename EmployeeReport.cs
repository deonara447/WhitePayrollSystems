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
    public partial class EmployeeReport : Form
    {
        Bitmap memoryImage;
        private PrintDocument printDocument1 = new PrintDocument();


        public EmployeeReport()
        {
            InitializeComponent();
            // getting employee name from list
            // getting employee name by concating first and last name from employees list
            lblEmployeeName.Text= Info.employees.Find(p => p.FirstName.Contains(Info.reportEmployeeName.ToString())).FirstName + " " + Info.employees.Find(p => p.FirstName.Contains(Info.reportEmployeeName.ToString())).LastName;
            // getting company name of the employee
            lblCompanyName.Text = Info.admins[0].CompanyName;
            label1.Text = Info.admins[0].CompanyName;
            // calling total earnings function
            lblAmountPaid.Text = getTotalEarnings();
            // calling total tax due function
            lblTaxDue.Text = getTaxDue();

        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Email Sent.");
        }

        private void CaptureScreen()
        {
            // attempting to capture screen for print, however, right now capturing blank screen
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void printDocument1_PrintPage(System.Object sender,
               System.Drawing.Printing.PrintPageEventArgs e)
        {
            //drawing image of the form
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // attempting to print current print
            CaptureScreen();
            printDocument1.Print();
        }

        private string getTotalEarnings()
        {
            // getting total earnings of an employee
            double total = 0;
            string employeeName = lblEmployeeName.Text;
            foreach (Payment payment in Info.payments)
            {
                if (payment.EmployeeName == employeeName)
                    // adding total to previous total
                    total += Double.Parse(payment.Amount);
            }
            // returning total as string
            return total.ToString("C");
        }

        private string getTaxDue()
        {
            // getting tax due on employee
            double totalTax = 0;
            string employeeName = lblEmployeeName.Text;
            foreach (Payment payment in Info.payments)
            {
                // checking if employee name matches
                if (payment.EmployeeName == employeeName)
                    // adding 15% tax on amount
                    totalTax += (Double.Parse(payment.Amount) * 0.15);
            }
            // returning total tax
            return totalTax.ToString("C");
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // opening dashboard form
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }
    }
}
