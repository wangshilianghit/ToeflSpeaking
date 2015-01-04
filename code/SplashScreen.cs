using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToeflPractice
{
    public partial class SplashScreen : Form
    {
        Timer timer;
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = 3000;  //set time interval 3 seconds.
            timer.Start();
            timer.Tick += timer_Tick;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
    }
}
