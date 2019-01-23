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
    public partial class RegisterEmployee : Form
    {
        public RegisterEmployee()
        {
            InitializeComponent();
            // populating paycycle combobox
            PopulatePayCycleComboBox();
            // populating benefits combobox
            PopulateAllocatedBenefitsComboBox();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // validating all 
            if (validateFields())
            {
                // concatenating account number in one variable
                string accountNumber = txtAccountNumber.Text + txtAccountTransit.Text + txtAccountBranch.Text;
                // making an object of class employee
                Employee employee = new Employee(txtFirstName.Text, txtLastName.Text, txtPhoneNumber.Text, txtEmail.Text, txtTitle.Text, txtDOB.Text, txtEmploymentStartDate.Text,
                        accountNumber, txtSocialInsuranceNumber.Text, Int32.Parse(txtPayRate.Text), cmbPayCycle.Text, txtPayRate.Text, txtAllocatedHours.Text, txtAllocatedVacation.Text, txtAllocatedHealthDays.Text,
                        cmbAllocatedBenefits.Text);
                // adding record to list of employees
                Info.employees.Add(employee);
                // adding notification to list of notifications
                Notification notification = new Notification("Employee added, Name: " + txtFirstName.Text + " " + txtLastName.Text, DateTime.Today.ToString());
                Info.notifications.Add(notification);
                // opening employee management form
                EmployeeManagement employeeManagement = new EmployeeManagement();
                employeeManagement.Show();
                this.Close();
                    
            }
        }

        private bool validateFields()
        {
            // validating all fields
            if (
                txtFirstName.Text == "" || txtLastName.Text == "" || txtPhoneNumber.Text == "" || txtEmail.Text == "" 
                || txtTitle.Text == "" || txtDOB.Text == "" || txtEmploymentStartDate.Text == "" || txtAccountNumber.Text == ""|| txtAccountTransit.Text =="" || txtAccountBranch.Text == "" 
                || txtSocialInsuranceNumber.Text == "" || txtPayRate.Text == "" || cmbPayCycle.Text == "" || txtStartDatePayCycle.Text == "" || txtAllocatedHours.Text == "" || txtAllocatedVacation.Text == "" 
                || txtAllocatedHealthDays.Text == "" || cmbAllocatedBenefits.Text == ""
               )
            {
                // showing error if invalid data is input
                MessageBox.Show("Make sure to fill all fields.");
                // returning false
                return false;
            }
            // validating fields where numeric values are expected
            int i = 0;
            double j = 0;
            if (int.TryParse(txtAccountNumber.Text, out i) == false || int.TryParse(txtAccountTransit.Text, out i) == false || int.TryParse(txtAccountBranch.Text, out i) == false
                || double.TryParse(txtPayRate.Text, out j) == false || double.TryParse(txtAllocatedHours.Text, out j) == false || int.TryParse(txtAllocatedVacation.Text, out i) == false
                || int.TryParse(txtAllocatedHealthDays.Text, out i) == false)
            {
                // showing error if invalid data is input
                MessageBox.Show("Invalid data. Numeric values expected in account number, transit, branch, payrate, allocated hours, vacations, health days.");
                // returning false
                return false;
            }
            // returning true if all input data is valid
            return true;
        }


        private void btnDashboard_Click_1(object sender, EventArgs e)
        {
            // opening dashboard form
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

        private void PopulatePayCycleComboBox()
        {
            // adding items to paycycle combobox
            cmbPayCycle.Items.Add("Weekly");
            cmbPayCycle.Items.Add("Bi-Weekly");
            cmbPayCycle.Items.Add("Monthly");
            cmbPayCycle.Items.Add("Annualy");
        }
        private void PopulateAllocatedBenefitsComboBox()
        {
            // adding items allocated benefits combobox
            cmbAllocatedBenefits.Items.Add("Full");
            cmbAllocatedBenefits.Items.Add("Half");
            cmbAllocatedBenefits.Items.Add("Custom");
            cmbAllocatedBenefits.Items.Add("None");
        }
    }
}
