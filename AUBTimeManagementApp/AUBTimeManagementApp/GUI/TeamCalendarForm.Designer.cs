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
            this.eventDetailsPanel = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.detailsEndTime = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.detailsEventName = new System.Windows.Forms.TextBox();
            this.ModifyEventBut = new System.Windows.Forms.Button();
            this.DeleteEventBut = new System.Windows.Forms.Button();
            this.eventDetailsBackBut = new System.Windows.Forms.Button();
            this.priorityBox.SuspendLayout();
            this.eventDetailsPanel.SuspendLayout();
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
            this.calendar.LoadItems += new System.Windows.Forms.Calendar.Calendar.CalendarLoadEventHandler(this.calendar_LoadItems);
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
            // eventDetailsPanel
            // 
            this.eventDetailsPanel.Controls.Add(this.textBox2);
            this.eventDetailsPanel.Controls.Add(this.textBox3);
            this.eventDetailsPanel.Controls.Add(this.hScrollBar1);
            this.eventDetailsPanel.Controls.Add(this.dateTimePickerStart);
            this.eventDetailsPanel.Controls.Add(this.dateTimePickerEnd);
            this.eventDetailsPanel.Controls.Add(this.detailsEndTime);
            this.eventDetailsPanel.Controls.Add(this.textBox7);
            this.eventDetailsPanel.Controls.Add(this.textBox4);
            this.eventDetailsPanel.Controls.Add(this.textBox6);
            this.eventDetailsPanel.Controls.Add(this.detailsEventName);
            this.eventDetailsPanel.Controls.Add(this.ModifyEventBut);
            this.eventDetailsPanel.Controls.Add(this.DeleteEventBut);
            this.eventDetailsPanel.Controls.Add(this.eventDetailsBackBut);
            this.eventDetailsPanel.Location = new System.Drawing.Point(651, 264);
            this.eventDetailsPanel.Name = "eventDetailsPanel";
            this.eventDetailsPanel.Size = new System.Drawing.Size(350, 287);
            this.eventDetailsPanel.TabIndex = 24;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(264, 159);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(62, 23);
            this.textBox2.TabIndex = 33;
            this.textBox2.Text = "high";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(95, 159);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(62, 23);
            this.textBox3.TabIndex = 32;
            this.textBox3.Text = "low";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.LargeChange = 1;
            this.hScrollBar1.Location = new System.Drawing.Point(95, 176);
            this.hScrollBar1.Maximum = 3;
            this.hScrollBar1.Minimum = 1;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(224, 26);
            this.hScrollBar1.TabIndex = 31;
            this.hScrollBar1.Value = 1;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(98, 93);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(221, 26);
            this.dateTimePickerStart.TabIndex = 30;
            this.dateTimePickerStart.Value = new System.DateTime(2020, 11, 24, 16, 51, 25, 0);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(98, 126);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(221, 26);
            this.dateTimePickerEnd.TabIndex = 29;
            // 
            // detailsEndTime
            // 
            this.detailsEndTime.BackColor = System.Drawing.SystemColors.Control;
            this.detailsEndTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detailsEndTime.Location = new System.Drawing.Point(98, 130);
            this.detailsEndTime.Name = "detailsEndTime";
            this.detailsEndTime.Size = new System.Drawing.Size(144, 19);
            this.detailsEndTime.TabIndex = 21;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Control;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Location = new System.Drawing.Point(30, 130);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(100, 19);
            this.textBox7.TabIndex = 22;
            this.textBox7.Text = "End Time:";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(31, 180);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(101, 19);
            this.textBox4.TabIndex = 28;
            this.textBox4.Text = "Priority: ";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Control;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Location = new System.Drawing.Point(30, 93);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(101, 19);
            this.textBox6.TabIndex = 27;
            this.textBox6.Text = "Start Time: ";
            // 
            // detailsEventName
            // 
            this.detailsEventName.BackColor = System.Drawing.SystemColors.Control;
            this.detailsEventName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detailsEventName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.detailsEventName.Location = new System.Drawing.Point(42, 33);
            this.detailsEventName.Multiline = true;
            this.detailsEventName.Name = "detailsEventName";
            this.detailsEventName.Size = new System.Drawing.Size(277, 39);
            this.detailsEventName.TabIndex = 26;
            this.detailsEventName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ModifyEventBut
            // 
            this.ModifyEventBut.Location = new System.Drawing.Point(239, 226);
            this.ModifyEventBut.Name = "ModifyEventBut";
            this.ModifyEventBut.Size = new System.Drawing.Size(84, 39);
            this.ModifyEventBut.TabIndex = 25;
            this.ModifyEventBut.Text = "Modify";
            this.ModifyEventBut.UseVisualStyleBackColor = true;
            this.ModifyEventBut.Click += new System.EventHandler(this.ModifyEventBut_Click);
            // 
            // DeleteEventBut
            // 
            this.DeleteEventBut.Location = new System.Drawing.Point(131, 225);
            this.DeleteEventBut.Name = "DeleteEventBut";
            this.DeleteEventBut.Size = new System.Drawing.Size(86, 40);
            this.DeleteEventBut.TabIndex = 24;
            this.DeleteEventBut.Text = "Delete";
            this.DeleteEventBut.UseVisualStyleBackColor = true;
            this.DeleteEventBut.Click += new System.EventHandler(this.DeleteEventBut_Click);
            // 
            // eventDetailsBackBut
            // 
            this.eventDetailsBackBut.ForeColor = System.Drawing.Color.Red;
            this.eventDetailsBackBut.Location = new System.Drawing.Point(30, 225);
            this.eventDetailsBackBut.Name = "eventDetailsBackBut";
            this.eventDetailsBackBut.Size = new System.Drawing.Size(81, 40);
            this.eventDetailsBackBut.TabIndex = 23;
            this.eventDetailsBackBut.Text = "Back";
            this.eventDetailsBackBut.UseVisualStyleBackColor = true;
            this.eventDetailsBackBut.Click += new System.EventHandler(this.eventDetailsBackBut_Click);
            // 
            // TeamCalendarForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1013, 557);
            this.Controls.Add(this.eventDetailsPanel);
            this.Controls.Add(this.priorityBox);
            this.Controls.Add(this.memberState);
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
            this.eventDetailsPanel.ResumeLayout(false);
            this.eventDetailsPanel.PerformLayout();
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
		private System.Windows.Forms.Panel eventDetailsPanel;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.HScrollBar hScrollBar1;
		private System.Windows.Forms.DateTimePicker dateTimePickerStart;
		private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
		private System.Windows.Forms.TextBox detailsEndTime;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.TextBox detailsEventName;
		private System.Windows.Forms.Button ModifyEventBut;
		private System.Windows.Forms.Button DeleteEventBut;
		private System.Windows.Forms.Button eventDetailsBackBut;
	}
}