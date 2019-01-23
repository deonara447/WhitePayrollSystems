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
    public partial class RegisterAdmin : Form
    {
        public RegisterAdmin()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (validateFields())
            {
                if (validatePassword())
                {
                    string accountNumber = txtAccountNumber.Text + txtAccountTransit.Text + txtAccountBranch.Text;
                    Admin admin = new Admin(txtCompanyName.Text, txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtUsername.Text, txtPhoneNumber.Text, accountNumber, txtPassword.Text);
                    Info.admins.Add(admin);
                    Info.lastPaymentDate = DateTime.Today;

                    // checking payment sample with example
                    //Info.lastPaymentDate = new DateTime(2019, 1, 10);
                    Dashboard db = new Dashboard();
                    db.Show();
                    this.Close();
                }
            }
        }

        private bool validateFields()
        {
            // validating all fields
            if (txtCompanyName.Text == "" || txtFirstName.Text == "" || txtLastName.Text == "" || txtEmail.Text == "" || txtPhoneNumber.Text == ""
                || txtAccountNumber.Text == "" || txtAccountTransit.Text == "" || txtAccountBranch.Text == "" || txtUsername.Text == ""
                || txtPassword.Text == "" || txtConfirmPassword.Text == "")
            {
                // showing error if invalid data is input
                MessageBox.Show("Make sure to fill all fields.");
                // returning false
                return false;
            }
            // validating fields where numeric values are expected
            int i = 0;
            if (int.TryParse(txtAccountNumber.Text, out i) == false || int.TryParse(txtAccountTransit.Text, out i) == false || int.TryParse(txtAccountBranch.Text, out i) == false)
            {
                // showing error if invalid data is input
                MessageBox.Show("Invalid data. Numeric values expected in account number, transit and branch.");
                // returning false
                return false;
            }
            // returning true if all input data is valid
            return true;
        }

        private bool validatePassword()
        {
            // matching both passwords
            if (txtPassword.Text == txtConfirmPassword.Text)
                return true;
            // showing error and returning false if passwords don't match.
            MessageBox.Show("Make sure passwords are same.");
            return false;

        }
    }
}
