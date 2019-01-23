using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhitePayrollSystems
{
    public partial class PaymentProcessing : Form
    {
        public PaymentProcessing()
        {
            InitializeComponent();
            // setting company name label
            populateEmployees();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (validateFields())
            {
                // getting and storing data in relevant classes
                DateTime dt = DateTime.Today;
                Payment payment = new Payment(cmbEmployeeName.Text, txtHoursWorked.Text, txtUsedHealthDays.Text, txtUsedBenefits.Text, txtHourlyRate.Text, dt.ToString(), txtAmount.Text);
                // adding a new payment to list of payments
                Info.payments.Add(payment);
                Notification notification = new Notification("Payment made, Name: " + cmbEmployeeName.Text + ", Amount: " + txtAmount.Text, DateTime.Today.ToString());
                // adding a new notification to list of notifications
                Info.notifications.Add(notification);
                // opening and showing payment management form
                PaymentManagement paymentManagement = new PaymentManagement();
                paymentManagement.Show();
                this.Close();
            }
        }

        private bool validateFields()
        {
            // validating all fields
            if (
                cmbEmployeeName.Text == "" || txtHoursWorked.Text == "" || txtUsedHealthDays.Text == "" || txtHourlyRate.Text == "" || txtUsedBenefits.Text == "" || txtAmount.Text == "")
            {
                // showing error if invalid data is input
                MessageBox.Show("Make sure to fill all fields.");
                // returning false
                return false;
            }
            int i = 0;
            double j = 0;
            // validating fields where numeric values are expected
            if (double.TryParse(txtHoursWorked.Text, out j) == false || int.TryParse(txtUsedHealthDays.Text, out i) == false || double.TryParse(txtHourlyRate.Text, out j) == false || int.TryParse(txtUsedBenefits.Text, out i) == false || double.TryParse(txtAmount.Text, out j) == false)
            {
                // showing error if invalid data is input
                MessageBox.Show("Invalid data. Numeric values expected in hours worked, used health or benefits days, hourly rate and amount.");
                // returning false
                return false;
            }
            // returning true if all input data is valid
            return true;
        }

        private void populateEmployees()
        {
            // populating employee name in employees combobox
            foreach (Employee employee in Info.employees)
            {
                // concatenating first and last name
                cmbEmployeeName.Items.Add(employee.FirstName + " " + employee.LastName);
            }
            if (cmbEmployeeName.Items.Count < 1)
            {
                // showing warning if no employees found
                MessageBox.Show("Warning: No employees found.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // cancelling and going back to payment management
            PaymentManagement payment = new PaymentManagement();
            payment.Show();
            this.Close();
        }
    }
}
