﻿namespace BDER
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.label1 = new System.Windows.Forms.Label();
            this.newTeacher = new System.Windows.Forms.TextBox();
            this.newTeacherButton = new System.Windows.Forms.Button();
            this.teacherDropDown = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.deleteTeacherButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "BDER For Admins";
            // 
            // newTeacher
            // 
            this.newTeacher.Location = new System.Drawing.Point(3, 54);
            this.newTeacher.Name = "newTeacher";
            this.newTeacher.Size = new System.Drawing.Size(197, 20);
            this.newTeacher.TabIndex = 2;
            // 
            // newTeacherButton
            // 
            this.newTeacherButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.newTeacherButton.Location = new System.Drawing.Point(206, 54);
            this.newTeacherButton.Name = "newTeacherButton";
            this.newTeacherButton.Size = new System.Drawing.Size(99, 20);
            this.newTeacherButton.TabIndex = 3;
            this.newTeacherButton.Text = "Add Teacher";
            this.newTeacherButton.UseVisualStyleBackColor = true;
            this.newTeacherButton.Click += new System.EventHandler(this.newTeacherButton_Click);
            // 
            // teacherDropDown
            // 
            this.teacherDropDown.FormattingEnabled = true;
            this.teacherDropDown.Location = new System.Drawing.Point(3, 81);
            this.teacherDropDown.Name = "teacherDropDown";
            this.teacherDropDown.Size = new System.Drawing.Size(197, 21);
            this.teacherDropDown.TabIndex = 4;
            this.teacherDropDown.Text = "Please select a teacher....";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(311, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(383, 245);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // deleteTeacherButton
            // 
            this.deleteTeacherButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.deleteTeacherButton.Location = new System.Drawing.Point(206, 80);
            this.deleteTeacherButton.Name = "deleteTeacherButton";
            this.deleteTeacherButton.Size = new System.Drawing.Size(99, 22);
            this.deleteTeacherButton.TabIndex = 5;
            this.deleteTeacherButton.Text = "Delete Teacher";
            this.deleteTeacherButton.UseVisualStyleBackColor = true;
            this.deleteTeacherButton.Click += new System.EventHandler(this.deleteTeacherButton_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(699, 270);
            this.Controls.Add(this.deleteTeacherButton);
            this.Controls.Add(this.teacherDropDown);
            this.Controls.Add(this.newTeacherButton);
            this.Controls.Add(this.newTeacher);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BDER Admin Panel";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox newTeacher;
        private System.Windows.Forms.Button newTeacherButton;
        private System.Windows.Forms.ComboBox teacherDropDown;
        private System.Windows.Forms.Button deleteTeacherButton;
    }
}