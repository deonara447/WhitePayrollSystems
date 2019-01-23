using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// Created By: Nolan White-Roy
/// Date Completed: 2019-01-22
/// Summary: A payroll system Systems designed to organize all tasks of employee payment and the filing of employee taxes. 
/// *PLEASE NOTE* Many labels and textboxes are placeholders and are not used in the program. Because of this, they are not properly named. 

namespace WhitePayrollSystems
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        // signing in user
        private void btnSignIn_Click(object sender, EventArgs e)
        { 
            // checking if accounts already exists
            if (Info.admins.Count < 1)
            {
                // show this message if no admins are registered
                MessageBox.Show("Please register an account first.");
            }
            else
            // verifying email and password
            {
                try
                {
                    // checking if email and password matches the existing records
                    if ((Info.admins.FirstOrDefault(admin => admin.Email == txtEmail.Text).Email) != null && (Info.admins.FirstOrDefault(admin => admin.Password == txtPassword.Text).Password) != null)
                    {
                        this.Hide();
                        Dashboard dashboard = new Dashboard();
                        dashboard.Show();
                    }
                }
                catch
                // show error in message box if incorrent credentials are provided
                {
                    MessageBox.Show("Invalid email or password. Please try again.");
                }
            }
        }

        private void btnRegisterAdmin_Click(object sender, EventArgs e)
        {
            // registering a new admin
            this.Hide();
            // opening RegisterAdmin form
            RegisterAdmin registerAdmin = new RegisterAdmin();
            registerAdmin.Show();
        }
    }
}
