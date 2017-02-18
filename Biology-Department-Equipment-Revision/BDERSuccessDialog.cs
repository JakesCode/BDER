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
    public partial class BDERSuccessDialog : Form
    {
        public BDERSuccessDialog(string url)
        {
            StaticVariables.HTMLurl = url;
            InitializeComponent();
        }

        public static class StaticVariables
        {
            public static string HTMLurl { get; set; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(StaticVariables.HTMLurl);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
