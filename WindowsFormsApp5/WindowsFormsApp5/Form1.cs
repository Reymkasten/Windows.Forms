using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form1_Load(null, null);
        }
        bool cont = true;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 100;
            timer1.Tick += Timer1_Tick;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Progress: ";
            toolStripProgressBar1.Maximum = 100;
            toolStripProgressBar1.Minimum = 0;
            statusStrip1.Visible = !statusStrip1.Visible;
            for (int i = 0; i < toolStripProgressBar1.Maximum; i++)
            {
                if (statusStrip1.Visible && cont == true)
                {
                    timer1.Start();
                }
                else
                {
                    timer1.Stop();
                }
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            toolStripProgressBar1.Value++;
            if (toolStripProgressBar1.Value == toolStripProgressBar1.Maximum)
            {
                timer1.Stop();
                MessageBox.Show("Process Completed");
                statusStrip1.Visible = !statusStrip1.Visible;
                toolStripProgressBar1.Value = 0;
            }
        }

        private void continueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Start();
            cont = true;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            cont = false;
        }

        private void continueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            cont = true;
        }

        private void stopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            cont = false;
        }
    }
 }

