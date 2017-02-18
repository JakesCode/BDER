namespace BDER
{
    partial class BDERIssueDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BDERIssueDialog));
            this.issueTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.bug = new System.Windows.Forms.CheckBox();
            this.enhancement = new System.Windows.Forms.CheckBox();
            this.question = new System.Windows.Forms.CheckBox();
            this.issuesTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // issueTitle
            // 
            this.issueTitle.Location = new System.Drawing.Point(12, 37);
            this.issueTitle.Name = "issueTitle";
            this.issueTitle.Size = new System.Drawing.Size(377, 20);
            this.issueTitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter a title for this issue....";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Please describe your issue....";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(15, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(378, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bug
            // 
            this.bug.AutoSize = true;
            this.bug.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bug.ForeColor = System.Drawing.Color.Red;
            this.bug.Location = new System.Drawing.Point(15, 288);
            this.bug.Name = "bug";
            this.bug.Size = new System.Drawing.Size(58, 24);
            this.bug.TabIndex = 5;
            this.bug.Text = "Bug";
            this.bug.UseVisualStyleBackColor = true;
            // 
            // enhancement
            // 
            this.enhancement.AutoSize = true;
            this.enhancement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enhancement.ForeColor = System.Drawing.Color.Teal;
            this.enhancement.Location = new System.Drawing.Point(116, 288);
            this.enhancement.Name = "enhancement";
            this.enhancement.Size = new System.Drawing.Size(130, 24);
            this.enhancement.TabIndex = 6;
            this.enhancement.Text = "Enhancement";
            this.enhancement.UseVisualStyleBackColor = true;
            // 
            // question
            // 
            this.question.AutoSize = true;
            this.question.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.question.ForeColor = System.Drawing.Color.DarkViolet;
            this.question.Location = new System.Drawing.Point(298, 287);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(95, 24);
            this.question.TabIndex = 8;
            this.question.Text = "Question";
            this.question.UseVisualStyleBackColor = true;
            // 
            // issuesTextbox
            // 
            this.issuesTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.issuesTextbox.Location = new System.Drawing.Point(12, 91);
            this.issuesTextbox.Multiline = true;
            this.issuesTextbox.Name = "issuesTextbox";
            this.issuesTextbox.Size = new System.Drawing.Size(378, 190);
            this.issuesTextbox.TabIndex = 0;
            this.issuesTextbox.TextChanged += new System.EventHandler(this.issuesTextbox_TextChanged);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(402, 355);
            this.Controls.Add(this.question);
            this.Controls.Add(this.enhancement);
            this.Controls.Add(this.bug);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.issueTitle);
            this.Controls.Add(this.issuesTextbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Issue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox issueTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox bug;
        private System.Windows.Forms.CheckBox enhancement;
        private System.Windows.Forms.CheckBox question;
        public System.Windows.Forms.TextBox issuesTextbox;
    }
}