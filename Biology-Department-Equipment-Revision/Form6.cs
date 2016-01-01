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
    public partial class Form6 : Form
    {
        public string issueName { get; set; }
        public string issueMain { get; set; }
        public Form6()
        {
            InitializeComponent();
        }

        private void issuesTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            issueName = issueTitle.Text;
            issueMain = issuesTextbox.Text;
            this.Close();

        }
    }
}
