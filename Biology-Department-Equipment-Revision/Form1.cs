using System;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static BDER.Form2;
using System.Security.Principal;
using Octokit;

namespace BDER
{
    public partial class appWindow : Form
    {
        // Public Variables //
        public static bool loadedFile { get; set; }
        public static Event publicCreatedEvent { get; set; }

        public appWindow()
        {
            InitializeComponent();
            loadedFile = false;
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.Text = "BDER " + String.Format("Version {0}", version);

            // Check for updates //
            /*var credentials = new Octokit.Credentials("4f4546f57c7426bbd4fe67542f6215d625f78ab7");
            var connection = new Octokit.Connection(new Octokit.ProductHeaderValue("https://github.com/JakesCode/Biology-Department-Equipment-Revision-Version-2"))
            {
                Credentials = credentials
            };
            var octokitClient = new Octokit.GitHubClient(connection);
            var releases = octokitClient.Release.GetAll("octokit", "octokit.net");
            Console.WriteLine(releases);*/

            // Populate Teacher Dropdown Menu //
            fillMenu();
        }

        private void fillMenu()
        {
            // Populate Teacher Dropdown Menu //
            IEnumerable<String> lines = File.ReadLines("data\\teachers.bio");
            foreach (string line in lines)
            {
                if (line != "")
                {
                    teacher.Items.Add(line);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void teacher_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void submit_Click(object sender, EventArgs e)
        {
            Object selectedTeacher = teacher.SelectedItem;
            int selectedTeacherIndex = teacher.SelectedIndex;

            List<string> colourList = new List<string>();
            for(int i = 0; i < 9; i++)
            {
                colourList.Add(i.ToString());
            }

            string year1 = calendar.Value.ToString("yyyy");
            string month1 = calendar.Value.ToString("MM");
            string day1 = calendar.Value.ToString("dd");

            int year = int.Parse(year1);
            int month = int.Parse(month1);
            int day = int.Parse(day1);

            Object selectedYearGroup = yearGroup.SelectedItem;
            Object selectedGroup = groups.SelectedItem;

            Object selectedPeriod = period.SelectedItem;

            if (!(selectedTeacher == null || selectedYearGroup == null || selectedGroup == null || selectedPeriod == null || riskAssessment.Checked == false || equipment.Text == ""))
            {
                string hour = "00";
                string minute = "00";
                string finishMinute = "00";
                string finishHour = "00";

                switch (selectedPeriod.ToString())
                {
                    case "Period 1":
                        hour = "09";
                        minute = "05";
                        finishMinute = "50";
                        finishHour = "09";
                        break;

                    case "Period 2":
                        hour = "09";
                        minute = "55";
                        finishMinute = "45";
                        finishHour = "10";
                        break;

                    case "Period 3":
                        hour = "11";
                        minute = "05";
                        finishMinute = "00";
                        finishHour = "12";
                        break;

                    case "Period 4":
                        hour = "12";
                        minute = "05";
                        finishMinute = "50";
                        finishHour = "12";
                        break;

                    case "Period 5":
                        hour = "14";
                        minute = "10";
                        finishMinute = "00";
                        finishHour = "15";
                        break;

                    case "Period 6":
                        hour = "15";
                        minute = "05";
                        finishMinute = "55";
                        finishHour = "15";
                        break;
                }

                Object selectedEquipment = equipment.Text;
                Object selectedHazcards = hazcards.Text;
                Boolean selectedRiskAssessment = riskAssessment.Checked;

                if (dissectionBox.Checked == true)
                {
                    DialogResult dissectionDialogueResponse = MessageBox.Show("You have checked the box confirming this practical is a dissection.\nChecking this box will remind the technicians about this particular practical one week, and one day, in advance.", "Request will be altered", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dissectionDialogueResponse == DialogResult.OK)
                    {
                        dissectionBox.Checked = true;
                    }
                    else
                    {
                        dissectionBox.Checked = false;
                    }
                }

                UserCredential credential;

                string[] Scopes = { CalendarService.Scope.Calendar };
                using (var stream =
                    new FileStream("client_secret.json", System.IO.FileMode.Open, FileAccess.Read))
                {
                    string credPath = System.Environment.GetFolderPath(
                        System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/calendar-dotnet-quickstart");

                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }

                // Create Google Calendar API service.
                var service = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "BDER 2015",
                });

                // Define parameters of request.
                EventsResource.ListRequest request = service.Events.List("lmaa730d1os7pj3o0dqdfe920o@group.calendar.google.com");
                request.TimeMin = DateTime.Now;
                request.ShowDeleted = false;
                request.SingleEvents = true;
                request.MaxResults = 10;
                request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

                string StartTime = (year.ToString() + "/" + month.ToString() + "/" + day.ToString() + " " + hour.ToString() + ":" + minute.ToString() + ":00");


                if (dissectionBox.Checked == false)
                {
                    Event newEvent = new Event()
                    {
                        Summary = "Practical Request from " + selectedTeacher,
                        Location = "GSAL",
                        Description = (@selectedTeacher + " - " + selectedGroup + " - " + selectedPeriod + ".\n\nEquipment Requested:\n" + selectedEquipment + "\n\nTeacher has confirmed a risk assessment has been carried out.\n\nReferenced Hazcards:\n" + selectedHazcards),
                        Start = new EventDateTime()
                        {
                            DateTime = new DateTime(year, month, day, Int32.Parse(hour), Int32.Parse(minute), 0),
                            TimeZone = "Europe/London",
                        },
                        End = new EventDateTime()
                        {
                            DateTime = new DateTime(year, month, day, Int32.Parse(finishHour), Int32.Parse(finishMinute), 0),
                            TimeZone = "Europe/London",
                        },
                        Attendees = new EventAttendee[]
                        {
                            new EventAttendee() { Email = "technicans@gsal.org.uk" },
                        },
                        Reminders = new Event.RemindersData()
                        {
                            UseDefault = false,
                            Overrides = new EventReminder[] {
                            new EventReminder() { Method = "popup", Minutes = 15 },
                            }
                        },
                        ColorId = colourList[selectedTeacherIndex],
                    };
                    String calendarId = "lmaa730d1os7pj3o0dqdfe920o@group.calendar.google.com";
                    EventsResource.InsertRequest newRequest = service.Events.Insert(newEvent, calendarId);
                    Event createdEvent = newRequest.Execute();
                    publicCreatedEvent = createdEvent;
                } else
                {
                    Event newEvent = new Event()
                    {
                        Summary = "Practical Request from " + selectedTeacher,
                        Location = "GSAL",
                        Description = (@selectedTeacher + " - " + selectedGroup + " - " + selectedPeriod + ".\n\nEquipment Requested:\n" + selectedEquipment + "\n\nTeacher has confirmed a risk assessment has been carried out.\n\nReferenced Hazcards:\n" + selectedHazcards),
                        Start = new EventDateTime()
                        {
                            DateTime = new DateTime(year, month, day, Int32.Parse(hour), Int32.Parse(minute), 0),
                            TimeZone = "Europe/London",
                        },
                        End = new EventDateTime()
                        {
                            DateTime = new DateTime(year, month, day, Int32.Parse(finishHour), Int32.Parse(finishMinute), 0),
                            TimeZone = "Europe/London",
                        },
                        /*Attendees = new EventAttendee[]
                        {
                            new EventAttendee() { Email = "technicans@gsal.org.uk" },
                        },*/
                        Reminders = new Event.RemindersData()
                        {
                            UseDefault = false,
                            Overrides = new EventReminder[] {
                            new EventReminder() { Method = "popup", Minutes = 15 },
                            new EventReminder() { Method = "popup", Minutes = 1440 },
                            new EventReminder() { Method = "email", Minutes = 1440 },
                            }
                        },
                        ColorId = colourList[selectedTeacherIndex],
                    };
                    String calendarId = "lmaa730d1os7pj3o0dqdfe920o@group.calendar.google.com";
                    EventsResource.InsertRequest newRequest = service.Events.Insert(newEvent, calendarId);
                    Event createdEvent = newRequest.Execute();
                    publicCreatedEvent = createdEvent;
                }

                

                if (loadedFile == false)
                {
                    Form3 nicknameDialogue = new Form3();
                    nicknameDialogue.ShowDialog();
                    var lines = (selectedTeacher + Environment.NewLine + selectedYearGroup + Environment.NewLine + selectedGroup + Environment.NewLine + selectedPeriod + Environment.NewLine + "BEGIN EQUIPMENT" + Environment.NewLine + selectedEquipment.ToString().Replace(Environment.NewLine, "NEWLINE") + Environment.NewLine + "END EQUIPMENT" + Environment.NewLine + selectedHazcards + Environment.NewLine + dissectionBox.Checked);
                    StreamWriter file = new StreamWriter(Directory.GetCurrentDirectory().ToString() + "\\history\\" + nicknameDialogue.ReturnText + ".bio");
                    file.WriteLine(lines);
                    file.Close();
                }


                string url = publicCreatedEvent.HtmlLink;
                Form2 finishedDialogue = new Form2(url);
                finishedDialogue.ShowDialog();
                this.Close();
            } else
            {
                MessageBox.Show("One or more sections of the form have been filled out incorrectly.\nPlease make sure that all elements, such as drop-down menus, have been selected and/or filled out correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void calendar_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void versionLabel_Click(object sender, EventArgs e)
        {           
            Form4 adminPanel = new Form4();
            adminPanel.ShowDialog();
            fillMenu();
        }

        private void upload_Click(object sender, EventArgs e)
        {
        }

        private void riskAssessment_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void appWindow_Load(object sender, EventArgs e)
        {

        }

        private void dissectionBox_CheckedChanged(object sender, EventArgs e)
        {   
        }

        private void openSaveFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/JakesCode/Biology-Department-Equipment-Revision-Version-2/wiki/A-Complete-Guide");
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            string currentPath = Directory.GetCurrentDirectory();
            openFileDialog1.InitialDirectory = currentPath += "\\history";
            openFileDialog1.Filter = "Biology Department Files (*.bio)|*.bio";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            List<string> importedData = new List<string>();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                string[] text = File.ReadAllLines(file);

                foreach (string line in text)
                {
                    importedData.Add(line);
                }
            }

            // Import the data into the various form elements //
            teacher.SelectedItem = importedData[0];
            yearGroup.SelectedItem = importedData[1];
            groups.SelectedItem = importedData[2];
            period.SelectedItem = importedData[3];
            int current = 4;
            if (importedData[current] == "BEGIN EQUIPMENT")
            {
                current += 1;
                while (importedData[current] != "END EQUIPMENT")
                {
                    importedData[current] = importedData[current].Replace("NEWLINE", Environment.NewLine);
                    equipment.Text += importedData[current];
                    current += 1;
                }
            }

            current += 1;
            hazcards.Text = importedData[current];
            current += 1;
            dissectionBox.Checked = Convert.ToBoolean(importedData[current]);

            MessageBox.Show("Loaded the file.\nFor security reasons, saving/loading the 'risk assessment' checkbox has been disabled. You must check this box yourself.\nThe date is also not read in, allowing you to choose a new date yourself.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadedFile = true;
        }

        private void feedback_Click(object sender, EventArgs e)
        {
            issueCheckbox feedbackForm = new issueCheckbox();
            feedbackForm.ShowDialog();
        }
    }
}
