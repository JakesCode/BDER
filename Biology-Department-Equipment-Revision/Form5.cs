using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Reflection;
using Octokit;
using Octokit.Internal;

namespace BDER
{
    public partial class issueCheckbox : Form
    {
        public issueCheckbox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(issues.Checked))
            {
                var feedback = textBox1.Text;
                Outlook.Application oApp = new Outlook.Application();
                Outlook._MailItem oMailItem = (Outlook._MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
                oMailItem.To = "jakestr1999@gmail.com";
                string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                oMailItem.Subject = "Some feedback [" + version + "]";
                oMailItem.HTMLBody = "Some feedback: " + "<br>" + feedback.Replace("\n", "<br>") + "<p><i>Sent with BDER For Windows, running version " + version + ".</i></p>";
                // body, bcc etc...
                oMailItem.Display(true);
            } else
            {
                gitHubStuff();
            }
        }
        public async void gitHubStuff()
        {
            var client = new GitHubClient(new ProductHeaderValue("BDER_For_Windows"));
            var tokenAuth = new Credentials("c38d687ad9ddf4fc8ebd0f35186dfe0aa4713e86");
            client.Credentials = tokenAuth;

            var user = await client.User.Get("JakesCode");
            MessageBox.Show(user.Name);
            Form6 issuesBox = new Form6();
            issuesBox.ShowDialog();
            var createIssue = new NewIssue(issuesBox.issueName);
            createIssue.Body = issuesBox.issueMain;
            createIssue.Assignee = "JakesCode";
            
            var newIssue = await client.Issue.Create("JakesCode", "Biology-Department-Equipment-Revision-Version-2", createIssue);
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
