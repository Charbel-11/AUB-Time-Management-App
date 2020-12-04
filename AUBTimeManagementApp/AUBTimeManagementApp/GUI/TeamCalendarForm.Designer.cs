namespace AUBTimeManagementApp.GUI {
    partial class TeamCalendarForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange1 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange2 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange3 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange4 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange5 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            this.calendar = new System.Windows.Forms.Calendar.Calendar();
            this.priorityBox = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.ModifyPriority = new System.Windows.Forms.HScrollBar();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.priorityBoxBackButton = new System.Windows.Forms.Button();
            this.monthView = new System.Windows.Forms.Calendar.MonthView();
            this.teamNameLabel = new System.Windows.Forms.Label();
            this.addEventButton = new System.Windows.Forms.Button();
            this.teamSchedButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.mergedSchedButton = new System.Windows.Forms.Button();
            this.memberState = new System.Windows.Forms.Label();
            this.priorityBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // calendar
            // 
            this.calendar.Font = new System.Drawing.Font("Segoe UI", 9F);
            calendarHighlightRange1.DayOfWeek = System.DayOfWeek.Monday;
            calendarHighlightRange1.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange1.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange2.DayOfWeek = System.DayOfWeek.Tuesday;
            calendarHighlightRange2.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange2.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange3.DayOfWeek = System.DayOfWeek.Wednesday;
            calendarHighlightRange3.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange3.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange4.DayOfWeek = System.DayOfWeek.Thursday;
            calendarHighlightRange4.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange4.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange5.DayOfWeek = System.DayOfWeek.Friday;
            calendarHighlightRange5.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange5.StartTime = System.TimeSpan.Parse("08:00:00");
            this.calendar.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange1,
        calendarHighlightRange2,
        calendarHighlightRange3,
        calendarHighlightRange4,
        calendarHighlightRange5};
            this.calendar.Location = new System.Drawing.Point(12, 12);
            this.calendar.Name = "calendar";
            this.calendar.Size = new System.Drawing.Size(611, 539);
            this.calendar.TabIndex = 8;
            this.calendar.Text = "calendar";
            this.calendar.ItemDoubleClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar_ItemDoubleClick);
            // 
            // priorityBox
            // 
            this.priorityBox.Controls.Add(this.textBox1);
            this.priorityBox.Controls.Add(this.textBox5);
            this.priorityBox.Controls.Add(this.textBox8);
            this.priorityBox.Controls.Add(this.ModifyPriority);
            this.priorityBox.Controls.Add(this.textBox10);
            this.priorityBox.Controls.Add(this.submitButton);
            this.priorityBox.Controls.Add(this.priorityBoxBackButton);
            this.priorityBox.Location = new System.Drawing.Point(651, 285);
            this.priorityBox.Name = "priorityBox";
            this.priorityBox.Size = new System.Drawing.Size(326, 257);
            this.priorityBox.TabIndex = 21;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(40, 33);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(251, 71);
            this.textBox1.TabIndex = 21;
            this.textBox1.Text = "Choose min Priority to Consider";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(241, 119);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(62, 23);
            this.textBox5.TabIndex = 20;
            this.textBox5.Text = "high";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox8
            // 
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(94, 118);
            this.textBox8.Margin = new System.Windows.Forms.Padding(2);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(62, 23);
            this.textBox8.TabIndex = 19;
            this.textBox8.Text = "low";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ModifyPriority
            // 
            this.ModifyPriority.LargeChange = 1;
            this.ModifyPriority.Location = new System.Drawing.Point(79, 147);
            this.ModifyPriority.Maximum = 3;
            this.ModifyPriority.Minimum = 1;
            this.ModifyPriority.Name = "ModifyPriority";
            this.ModifyPriority.Size = new System.Drawing.Size(224, 26);
            this.ModifyPriority.TabIndex = 18;
            this.ModifyPriority.Value = 1;
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.SystemColors.Control;
            this.textBox10.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox10.Location = new System.Drawing.Point(15, 147);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(101, 19);
            this.textBox10.TabIndex = 8;
            this.textBox10.Text = "Priority: ";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(185, 204);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(106, 39);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // priorityBoxBackButton
            // 
            this.priorityBoxBackButton.ForeColor = System.Drawing.Color.Red;
            this.priorityBoxBackButton.Location = new System.Drawing.Point(35, 203);
            this.priorityBoxBackButton.Name = "priorityBoxBackButton";
            this.priorityBoxBackButton.Size = new System.Drawing.Size(106, 40);
            this.priorityBoxBackButton.TabIndex = 0;
            this.priorityBoxBackButton.Text = "Back";
            this.priorityBoxBackButton.UseVisualStyleBackColor = true;
            this.priorityBoxBackButton.Click += new System.EventHandler(this.priorityBoxBackButton_Click);
            // 
            // monthView
            // 
            this.monthView.ArrowsColor = System.Drawing.SystemColors.Window;
            this.monthView.ArrowsSelectedColor = System.Drawing.Color.Gold;
            this.monthView.DayBackgroundColor = System.Drawing.Color.Empty;
            this.monthView.DayGrayedText = System.Drawing.SystemColors.GrayText;
            this.monthView.DaySelectedBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.monthView.DaySelectedColor = System.Drawing.SystemColors.WindowText;
            this.monthView.DaySelectedTextColor = System.Drawing.SystemColors.HighlightText;
            this.monthView.ItemPadding = new System.Windows.Forms.Padding(2);
            this.monthView.Location = new System.Drawing.Point(693, 60);
            this.monthView.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthView.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
            this.monthView.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.monthView.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
            this.monthView.Name = "monthView";
            this.monthView.Size = new System.Drawing.Size(240, 198);
            this.monthView.TabIndex = 9;
            this.monthView.Text = "monthView";
            this.monthView.TodayBorderColor = System.Drawing.Color.Maroon;
            this.monthView.SelectionChanged += new System.EventHandler(this.monthView_SelectionChanged);
            // 
            // teamNameLabel
            // 
            this.teamNameLabel.AutoSize = true;
            this.teamNameLabel.Location = new System.Drawing.Point(662, 25);
            this.teamNameLabel.Name = "teamNameLabel";
            this.teamNameLabel.Size = new System.Drawing.Size(95, 20);
            this.teamNameLabel.TabIndex = 10;
            this.teamNameLabel.Text = "Team Name";
            // 
            // addEventButton
            // 
            this.addEventButton.Location = new System.Drawing.Point(678, 285);
            this.addEventButton.Name = "addEventButton";
            this.addEventButton.Size = new System.Drawing.Size(266, 47);
            this.addEventButton.TabIndex = 2;
            this.addEventButton.Text = "Add Event";
            this.addEventButton.UseVisualStyleBackColor = true;
            this.addEventButton.Click += new System.EventHandler(this.addEvent_Click);
            // 
            // teamSchedButton
            // 
            this.teamSchedButton.Location = new System.Drawing.Point(678, 354);
            this.teamSchedButton.Name = "teamSchedButton";
            this.teamSchedButton.Size = new System.Drawing.Size(266, 49);
            this.teamSchedButton.TabIndex = 11;
            this.teamSchedButton.Text = "Show Team Schedule";
            this.teamSchedButton.UseVisualStyleBackColor = true;
            this.teamSchedButton.Click += new System.EventHandler(this.teamSchedButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(678, 498);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(266, 47);
            this.backButton.TabIndex = 12;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // mergedSchedButton
            // 
            this.mergedSchedButton.Location = new System.Drawing.Point(678, 425);
            this.mergedSchedButton.Name = "mergedSchedButton";
            this.mergedSchedButton.Size = new System.Drawing.Size(266, 49);
            this.mergedSchedButton.TabIndex = 13;
            this.mergedSchedButton.Text = "Show Merged Schedule";
            this.mergedSchedButton.UseVisualStyleBackColor = true;
            this.mergedSchedButton.Click += new System.EventHandler(this.mergedSchedButton_Click);
            // 
            // memberState
            // 
            this.memberState.AutoSize = true;
            this.memberState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.memberState.Location = new System.Drawing.Point(898, 25);
            this.memberState.Name = "memberState";
            this.memberState.Size = new System.Drawing.Size(68, 25);
            this.memberState.TabIndex = 23;
            this.memberState.Text = "Admin";
            // 
            // TeamCalendarForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1013, 557);
            this.Controls.Add(this.memberState);
            this.Controls.Add(this.priorityBox);
            this.Controls.Add(this.mergedSchedButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.teamSchedButton);
            this.Controls.Add(this.addEventButton);
            this.Controls.Add(this.teamNameLabel);
            this.Controls.Add(this.monthView);
            this.Controls.Add(this.calendar);
            this.Name = "TeamCalendarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeamCalendarForm";
            this.priorityBox.ResumeLayout(false);
            this.priorityBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Calendar.Calendar calendar;
        private System.Windows.Forms.Calendar.MonthView monthView;
        private System.Windows.Forms.Label teamNameLabel;
        private System.Windows.Forms.Button addEventButton;
        private System.Windows.Forms.Button teamSchedButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button mergedSchedButton;
        private System.Windows.Forms.Panel priorityBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.HScrollBar ModifyPriority;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button priorityBoxBackButton;
        private System.Windows.Forms.Label memberState;
    }
}