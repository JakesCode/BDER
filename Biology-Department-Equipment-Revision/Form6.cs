using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Octokit;

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

        private async void button1_Click(object sender, EventArgs e)
        {
            var client = new GitHubClient(new ProductHeaderValue("BDER"));
            var tokenAuth = new Credentials(File.ReadAllText(@"data\pat.bio").ToString());
            client.Credentials = tokenAuth;

            var createIssue = new NewIssue(issueTitle.Text);
            createIssue.Body = issuesTextbox.Text;
            createIssue.Assignee = "JakesCode";
            List<string> issuesList = new List<string>();
            if (bug.Checked)
            {
                issuesList.Add("bug");
            }

            if (enhancement.Checked)
            {
                issuesList.Add("enhancement");
            }

            if (question.Checked)
            {
                issuesList.Add("question");
            }
            
            foreach (string line in issuesList)
            {
                createIssue.Labels.Add(line);
            }

            if (issueTitle.Text == "" || issuesTextbox.Text == "")
            {
                MessageBox.Show("You have not specified either a title or body. Please rectify this issue and try again.");
            }

            if (issuesList.Count == 0)
            {
                MessageBox.Show("You have not selected either bug, enhancement or question.\nAt least one tag is required.");
            } else
            {
                var issue = await client.Issue.Create("JakesCode", "BDER", createIssue);
                this.Close();
            } 
        }
    }
}
