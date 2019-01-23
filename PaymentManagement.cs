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
    public partial class PaymentManagement : Form
    {
        public PaymentManagement()
        {
            InitializeComponent();
            // getting payment history
            dataGridView1.DataSource = new BindingList<Payment>(Info.payments);
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            // opening add employee form
            PaymentProcessing paymentProcessing = new PaymentProcessing();
            paymentProcessing.Show();
            this.Close();
        }

        private void btnDashboard_Click_1(object sender, EventArgs e)
        {
            // opening dashboard form
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }
    }
}
