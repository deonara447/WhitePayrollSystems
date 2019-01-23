using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace WhitePayrollSystems
{
    public partial class SplashScreen : Form
    {
        // setting timer
        DispatcherTimer dT = new DispatcherTimer();
        // setting media file
        public System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"\o98.wav");
        public SplashScreen()
        {
            InitializeComponent();
            // playing media sound in background
            //player.Play();
            // starting time
            dT.Tick += new EventHandler(dt_Tick);
            dT.Interval = new TimeSpan(0, 0, 8);
            dT.Start();
        }

        private void dt_Tick(object sender, EventArgs e)
        {
            // opening login form when timer ends
            Login lg = new Login();
            this.Hide();

            lg.Show();
            // stopping timer
            dT.Stop();
        }
    }
}
