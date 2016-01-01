using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDER
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/settings/tokens/new");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(@"data\pat.bio", textBox1.Text.ToString());
            this.Close();
        }
    }
}
