namespace AUBTimeManagementApp.GUI
{
    partial class Form1
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
            this.AddTeamButton = new System.Windows.Forms.Button();
            this.addEvent = new System.Windows.Forms.Button();
            this.teams = new System.Windows.Forms.TextBox();
            this.events = new System.Windows.Forms.TextBox();
            this.freeTime = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddTeamButton
            // 
            this.AddTeamButton.Location = new System.Drawing.Point(706, 123);
            this.AddTeamButton.Name = "AddTeamButton";
            this.AddTeamButton.Size = new System.Drawing.Size(266, 51);
            this.AddTeamButton.TabIndex = 0;
            this.AddTeamButton.Text = "Add Team";
            this.AddTeamButton.UseVisualStyleBackColor = true;
            this.AddTeamButton.Click += new System.EventHandler(this.AddTeamButton_Click);
            // 
            // addEvent
            // 
            this.addEvent.Location = new System.Drawing.Point(706, 226);
            this.addEvent.Name = "addEvent";
            this.addEvent.Size = new System.Drawing.Size(266, 51);
            this.addEvent.TabIndex = 1;
            this.addEvent.Text = "Add Event";
            this.addEvent.UseVisualStyleBackColor = true;
            this.addEvent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.addEvent_MouseClick);
            // 
            // teams
            // 
            this.teams.Location = new System.Drawing.Point(38, 39);
            this.teams.Multiline = true;
            this.teams.Name = "teams";
            this.teams.ReadOnly = true;
            this.teams.Size = new System.Drawing.Size(253, 198);
            this.teams.TabIndex = 2;
            this.teams.Text = "Teams:\r\n\r\n";
            // 
            // events
            // 
            this.events.Location = new System.Drawing.Point(159, 271);
            this.events.Multiline = true;
            this.events.Name = "events";
            this.events.ReadOnly = true;
            this.events.Size = new System.Drawing.Size(323, 201);
            this.events.TabIndex = 3;
            this.events.Text = "My Events:";
            // 
            // freeTime
            // 
            this.freeTime.Location = new System.Drawing.Point(355, 39);
            this.freeTime.Multiline = true;
            this.freeTime.Name = "freeTime";
            this.freeTime.ReadOnly = true;
            this.freeTime.Size = new System.Drawing.Size(263, 201);
            this.freeTime.TabIndex = 4;
            this.freeTime.Text = "Free time:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(706, 329);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(266, 51);
            this.button4.TabIndex = 6;
            this.button4.Text = "Find Free Time";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1016, 550);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.freeTime);
            this.Controls.Add(this.events);
            this.Controls.Add(this.teams);
            this.Controls.Add(this.addEvent);
            this.Controls.Add(this.AddTeamButton);
            this.Name = "Form1";
            this.Text = "Time Management App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddTeamButton;
        private System.Windows.Forms.Button addEvent;
        private System.Windows.Forms.TextBox teams;
        private System.Windows.Forms.TextBox events;
        private System.Windows.Forms.TextBox freeTime;
        private System.Windows.Forms.Button button4;
    }
}