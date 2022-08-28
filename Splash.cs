using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }
        int start = 0;
        private async void timer1_Tick(object sender, EventArgs e)
        {
            start += 1;
            progress.Value = start;
            if(progress.Value == 100)
            {
                progress.Value = 0;
                timer1.Stop();
                LOGIN log = new LOGIN();
                log.Show();
                await Task.Delay(500);
                this.Hide();
            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
