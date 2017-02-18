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

namespace BDER
{
    public partial class BDERAdmin : Form
    {
        public static string[] newTeachers { get; set; }
        public BDERAdmin()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            fillList();
        }

        private void fillList()
        {
            // Clear Teacher Dropdown Menu //
            teacherDropDown.Items.Clear();

            // Populate Teacher Dropdown Menu //
            IEnumerable<String> lines = File.ReadLines("data\\teachers.bio");
            foreach (string line in lines)
            {
                if (line != "")
                {
                    teacherDropDown.Items.Add(line);
                }            
            }
        }

        private void newTeacherButton_Click(object sender, EventArgs e)
        {
            var newTeacherInput = Environment.NewLine + newTeacher.Text;
            if (newTeacherInput.Substring(newTeacherInput.Length - 1) != "]")
            {
                MessageBox.Show("Remember to put the initials of the teacher in [square brackets], then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                File.AppendAllText("data\\teachers.bio", newTeacherInput);
                MessageBox.Show("The new teacher (" + newTeacherInput.Replace(Environment.NewLine, "") + ") has been added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillList();
            }
        }

        private void deleteTeacherButton_Click(object sender, EventArgs e)
        {
            if (teacherDropDown.SelectedItem.ToString() != "Please select a teacher")
            {
                // Delete a teacher entry //
                string[] readText = File.ReadAllLines("data\\teachers.bio");
                foreach (string line in readText)
                {
                    if (teacherDropDown.SelectedItem.ToString() == line)
                    {
                        newTeachers = readText.Where(val => val != line).ToArray();
                    }
                }

                // Wipe the file //
                System.IO.File.WriteAllText(@"data\\teachers.bio", string.Empty);

                // Rewrite the file //
                foreach (string line in newTeachers)
                {
                    if (line == Environment.NewLine)
                    {
                        File.AppendAllText("data\\teachers.bio", line);
                    } else
                    {
                        File.AppendAllText("data\\teachers.bio", Environment.NewLine + line);
                    }
                    
                }

                fillList();
            }
        }
    }
}
