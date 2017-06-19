using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheEyeTribeTest
{
    public partial class Form1 : Form
    {
        Point point;
        private Timer timer;
        public Form1()
        {
            InitializeComponent();
            point = new Point();
            InitTimer();
        }
        public void InitTimer()
        {
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 10; // in miliseconds
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            double x, y;
            x = this.Size.Width * point.PercentX;
            y = this.Size.Height * point.PercentY;            
            toolStripStatusLabelX.Text = "X: " + point.GX.ToString() +' '+ point.PercentX.ToString();
            toolStripStatusLabelY.Text = " | Y: " + point.GY.ToString()+' '+point.PercentY.ToString();

            radioButtonPosition.Location = new System.Drawing.Point((int)x, (int)y);
            if (point.PercentX < 0.1)
                buttonPosition.Location = new System.Drawing.Point(10, (int)y-(buttonPosition.Size.Height/2));
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            point.Disconnect();
        }
    }
}
