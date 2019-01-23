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
    public partial class ReportsManagement : Form
    {
        public ReportsManagement()
        {
            InitializeComponent();

            // binding data source to list of employees
            dataGridView1.DataSource = new BindingList<Employee>(Info.employees); 
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // opening dashboard
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // opening report screen of an employee
            Info.reportEmployeeName = dataGridView1.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
            EmployeeReport employeeReport = new EmployeeReport();
            employeeReport.Show();
            this.Close();
        }
    }
}
