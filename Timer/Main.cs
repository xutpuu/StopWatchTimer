using System;
using System.Windows.Forms;

namespace Timer
{
    public partial class Main : Form
    {

        private DateTime start = DateTime.MinValue;
        private TimeSpan oldTime = TimeSpan.Zero;
        const double _n = 3;

        public Main()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 10;
            timer.Tick += new EventHandler(timer_Tick);
        }

        private void btnStart_Click(object sender, System.EventArgs e)
        {
            timer.Start();
            start = DateTime.Now.AddSeconds(_n);
            tbTimer.ForeColor = System.Drawing.Color.Black;
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            oldTime = (start - DateTime.Now);

            if (oldTime.Milliseconds <= -1)
            {
                timer.Stop();
                oldTime = TimeSpan.Zero;
                tbTimer.ForeColor = System.Drawing.Color.Red;
                tbTimer.Text = "BOOOOOOOM!";
            }
            else
                tbTimer.Text = oldTime.Seconds.ToString() + ":" + oldTime.Milliseconds.ToString();
        }

        private void btnStop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                timer.Stop();
            }
        }
    }
}

