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
    public partial class EmployeeManagement : Form
    {
        public EmployeeManagement()
        {
            InitializeComponent();

            // assigning data source to employees 
            dataGridView1.DataSource = new BindingList<Employee>(Info.employees);
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            // opening employee registration form
            RegisterEmployee registerEmployee = new RegisterEmployee();
            registerEmployee.Show();
            this.Close();
        }


        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // opening dashboard form
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // searching employees
            if(txtSearchEmployee.Text == "")
            {
                // showing error in message box if nothing is written in search box
                MessageBox.Show("Search is empty.");
                return;
            }
            else
            {
                // getting list of matching employees by finding first names containing the search text
                List<Employee> matchingEmployees = Info.employees.Where(emp => emp.FirstName.Contains(txtSearchEmployee.Text)).ToList();
                if (matchingEmployees.Count > 0)
                {
                    // showing results if returned records greater than 0
                    MessageBox.Show("Records found: " + matchingEmployees.Count);
                    dataGridView1.DataSource = new BindingList<Employee>(matchingEmployees);
                }
                else
                {
                    // showing message if no records found
                    MessageBox.Show("No matching records found");
                }
            }

        }
    }
}
