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
    public partial class BDERNamePrompt : Form
    {
        public string ReturnText { get; set;}

        public BDERNamePrompt()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReturnText = textBox1.Text;
            this.Close();
        }
    }
}
