namespace AUBTimeManagementApp.GUI
{
    partial class mainForm
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
			System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange21 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
			System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange22 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
			System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange23 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
			System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange24 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
			System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange25 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
			this.TeamButton = new System.Windows.Forms.Button();
			this.addEvent = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.backButton = new System.Windows.Forms.Button();
			this.filterUserScheduleBut = new System.Windows.Forms.Button();
			this.mainPanel = new System.Windows.Forms.Panel();
			this.filteringPanel = new System.Windows.Forms.Panel();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.filterDoneButton = new System.Windows.Forms.Button();
			this.filterBackBut = new System.Windows.Forms.Button();
			this.High = new System.Windows.Forms.CheckBox();
			this.Medium = new System.Windows.Forms.CheckBox();
			this.Low = new System.Windows.Forms.CheckBox();
			this.eventDetailsPanel = new System.Windows.Forms.Panel();
			this.detailsPriority = new System.Windows.Forms.TextBox();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.detailsStartTime = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.detailsEventName = new System.Windows.Forms.TextBox();
			this.ModifyEventBut = new System.Windows.Forms.Button();
			this.DeleteEventBut = new System.Windows.Forms.Button();
			this.eventDetailsBackBut = new System.Windows.Forms.Button();
			this.monthView = new System.Windows.Forms.Calendar.MonthView();
			this.calendar = new System.Windows.Forms.Calendar.Calendar();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.detailsEndTime = new System.Windows.Forms.TextBox();
			this.mainPanel.SuspendLayout();
			this.filteringPanel.SuspendLayout();
			this.eventDetailsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// TeamButton
			// 
			this.TeamButton.Location = new System.Drawing.Point(16, 75);
			this.TeamButton.Name = "TeamButton";
			this.TeamButton.Size = new System.Drawing.Size(266, 51);
			this.TeamButton.TabIndex = 0;
			this.TeamButton.Text = "Teams";
			this.TeamButton.UseVisualStyleBackColor = true;
			this.TeamButton.Click += new System.EventHandler(this.TeamButton_Click);
			// 
			// addEvent
			// 
			this.addEvent.Location = new System.Drawing.Point(16, 3);
			this.addEvent.Name = "addEvent";
			this.addEvent.Size = new System.Drawing.Size(266, 51);
			this.addEvent.TabIndex = 1;
			this.addEvent.Text = "Add Event";
			this.addEvent.UseVisualStyleBackColor = true;
			this.addEvent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.addEvent_MouseClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(787, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "label1";
			// 
			// backButton
			// 
			this.backButton.ForeColor = System.Drawing.Color.Red;
			this.backButton.Location = new System.Drawing.Point(16, 215);
			this.backButton.Name = "backButton";
			this.backButton.Size = new System.Drawing.Size(266, 51);
			this.backButton.TabIndex = 10;
			this.backButton.Text = "Back";
			this.backButton.UseVisualStyleBackColor = true;
			this.backButton.Click += new System.EventHandler(this.backButton_Click);
			// 
			// filterUserScheduleBut
			// 
			this.filterUserScheduleBut.Location = new System.Drawing.Point(16, 146);
			this.filterUserScheduleBut.Name = "filterUserScheduleBut";
			this.filterUserScheduleBut.Size = new System.Drawing.Size(265, 52);
			this.filterUserScheduleBut.TabIndex = 18;
			this.filterUserScheduleBut.Text = "Filter Schedule";
			this.filterUserScheduleBut.UseVisualStyleBackColor = true;
			this.filterUserScheduleBut.Click += new System.EventHandler(this.filterUserScheduleBut_Click);
			// 
			// mainPanel
			// 
			this.mainPanel.Controls.Add(this.backButton);
			this.mainPanel.Controls.Add(this.filterUserScheduleBut);
			this.mainPanel.Controls.Add(this.TeamButton);
			this.mainPanel.Controls.Add(this.addEvent);
			this.mainPanel.Location = new System.Drawing.Point(670, 278);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(285, 269);
			this.mainPanel.TabIndex = 19;
			// 
			// filteringPanel
			// 
			this.filteringPanel.Controls.Add(this.textBox5);
			this.filteringPanel.Controls.Add(this.textBox4);
			this.filteringPanel.Controls.Add(this.textBox3);
			this.filteringPanel.Controls.Add(this.textBox2);
			this.filteringPanel.Controls.Add(this.textBox1);
			this.filteringPanel.Controls.Add(this.filterDoneButton);
			this.filteringPanel.Controls.Add(this.filterBackBut);
			this.filteringPanel.Controls.Add(this.High);
			this.filteringPanel.Controls.Add(this.Medium);
			this.filteringPanel.Controls.Add(this.Low);
			this.filteringPanel.Location = new System.Drawing.Point(670, 296);
			this.filteringPanel.Name = "filteringPanel";
			this.filteringPanel.Size = new System.Drawing.Size(317, 227);
			this.filteringPanel.TabIndex = 19;
			// 
			// textBox5
			// 
			this.textBox5.BackColor = System.Drawing.SystemColors.Control;
			this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.textBox5.Location = new System.Drawing.Point(33, 57);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(176, 16);
			this.textBox5.TabIndex = 9;
			this.textBox5.Text = "Priority:";
			// 
			// textBox4
			// 
			this.textBox4.BackColor = System.Drawing.SystemColors.Control;
			this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.textBox4.Location = new System.Drawing.Point(81, 3);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(199, 19);
			this.textBox4.TabIndex = 8;
			this.textBox4.Text = "Filter Schedule";
			// 
			// textBox3
			// 
			this.textBox3.BackColor = System.Drawing.SystemColors.Control;
			this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.textBox3.Location = new System.Drawing.Point(212, 104);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(52, 16);
			this.textBox3.TabIndex = 7;
			this.textBox3.Text = "High";
			// 
			// textBox2
			// 
			this.textBox2.BackColor = System.Drawing.SystemColors.Control;
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.textBox2.Location = new System.Drawing.Point(120, 103);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(61, 16);
			this.textBox2.TabIndex = 6;
			this.textBox2.Text = "Medium";
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.Control;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.textBox1.Location = new System.Drawing.Point(43, 103);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(47, 16);
			this.textBox1.TabIndex = 5;
			this.textBox1.Text = "Low";
			// 
			// filterDoneButton
			// 
			this.filterDoneButton.ForeColor = System.Drawing.Color.Green;
			this.filterDoneButton.Location = new System.Drawing.Point(173, 189);
			this.filterDoneButton.Name = "filterDoneButton";
			this.filterDoneButton.Size = new System.Drawing.Size(107, 34);
			this.filterDoneButton.TabIndex = 4;
			this.filterDoneButton.Text = "Done";
			this.filterDoneButton.UseVisualStyleBackColor = true;
			this.filterDoneButton.Click += new System.EventHandler(this.filterDoneButton_Click);
			// 
			// filterBackBut
			// 
			this.filterBackBut.ForeColor = System.Drawing.Color.Red;
			this.filterBackBut.Location = new System.Drawing.Point(33, 189);
			this.filterBackBut.Name = "filterBackBut";
			this.filterBackBut.Size = new System.Drawing.Size(110, 34);
			this.filterBackBut.TabIndex = 3;
			this.filterBackBut.Text = "Back";
			this.filterBackBut.UseVisualStyleBackColor = true;
			this.filterBackBut.Click += new System.EventHandler(this.filterBackBut_Click);
			// 
			// High
			// 
			this.High.AutoSize = true;
			this.High.Location = new System.Drawing.Point(222, 128);
			this.High.Name = "High";
			this.High.Size = new System.Drawing.Size(15, 14);
			this.High.TabIndex = 2;
			this.High.UseVisualStyleBackColor = true;
			// 
			// Medium
			// 
			this.Medium.AutoSize = true;
			this.Medium.Location = new System.Drawing.Point(142, 129);
			this.Medium.Name = "Medium";
			this.Medium.Size = new System.Drawing.Size(15, 14);
			this.Medium.TabIndex = 1;
			this.Medium.UseVisualStyleBackColor = true;
			// 
			// Low
			// 
			this.Low.AutoSize = true;
			this.Low.Location = new System.Drawing.Point(53, 128);
			this.Low.Name = "Low";
			this.Low.Size = new System.Drawing.Size(15, 14);
			this.Low.TabIndex = 0;
			this.Low.UseVisualStyleBackColor = true;
			// 
			// eventDetailsPanel
			// 
			this.eventDetailsPanel.Controls.Add(this.detailsEndTime);
			this.eventDetailsPanel.Controls.Add(this.textBox7);
			this.eventDetailsPanel.Controls.Add(this.detailsPriority);
			this.eventDetailsPanel.Controls.Add(this.textBox10);
			this.eventDetailsPanel.Controls.Add(this.detailsStartTime);
			this.eventDetailsPanel.Controls.Add(this.textBox6);
			this.eventDetailsPanel.Controls.Add(this.detailsEventName);
			this.eventDetailsPanel.Controls.Add(this.ModifyEventBut);
			this.eventDetailsPanel.Controls.Add(this.DeleteEventBut);
			this.eventDetailsPanel.Controls.Add(this.eventDetailsBackBut);
			this.eventDetailsPanel.Location = new System.Drawing.Point(669, 269);
			this.eventDetailsPanel.Name = "eventDetailsPanel";
			this.eventDetailsPanel.Size = new System.Drawing.Size(317, 275);
			this.eventDetailsPanel.TabIndex = 20;
			// 
			// detailsPriority
			// 
			this.detailsPriority.BackColor = System.Drawing.SystemColors.Control;
			this.detailsPriority.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.detailsPriority.Location = new System.Drawing.Point(82, 136);
			this.detailsPriority.Name = "detailsPriority";
			this.detailsPriority.Size = new System.Drawing.Size(143, 13);
			this.detailsPriority.TabIndex = 9;
			// 
			// textBox10
			// 
			this.textBox10.BackColor = System.Drawing.SystemColors.Control;
			this.textBox10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox10.Location = new System.Drawing.Point(14, 136);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(101, 13);
			this.textBox10.TabIndex = 8;
			this.textBox10.Text = "Priority: ";
			// 
			// detailsStartTime
			// 
			this.detailsStartTime.BackColor = System.Drawing.SystemColors.Control;
			this.detailsStartTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.detailsStartTime.Location = new System.Drawing.Point(82, 84);
			this.detailsStartTime.Name = "detailsStartTime";
			this.detailsStartTime.Size = new System.Drawing.Size(144, 13);
			this.detailsStartTime.TabIndex = 5;
			// 
			// textBox6
			// 
			this.textBox6.BackColor = System.Drawing.SystemColors.Control;
			this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox6.Location = new System.Drawing.Point(14, 84);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(101, 13);
			this.textBox6.TabIndex = 4;
			this.textBox6.Text = "Start Time: ";
			// 
			// detailsEventName
			// 
			this.detailsEventName.BackColor = System.Drawing.SystemColors.Control;
			this.detailsEventName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.detailsEventName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.detailsEventName.Location = new System.Drawing.Point(94, 35);
			this.detailsEventName.Name = "detailsEventName";
			this.detailsEventName.Size = new System.Drawing.Size(97, 19);
			this.detailsEventName.TabIndex = 3;
			// 
			// ModifyEventBut
			// 
			this.ModifyEventBut.Location = new System.Drawing.Point(213, 210);
			this.ModifyEventBut.Name = "ModifyEventBut";
			this.ModifyEventBut.Size = new System.Drawing.Size(84, 39);
			this.ModifyEventBut.TabIndex = 2;
			this.ModifyEventBut.Text = "Modify";
			this.ModifyEventBut.UseVisualStyleBackColor = true;
			this.ModifyEventBut.Click += new System.EventHandler(this.ModifyEventBut_Click);
			// 
			// DeleteEventBut
			// 
			this.DeleteEventBut.Location = new System.Drawing.Point(105, 209);
			this.DeleteEventBut.Name = "DeleteEventBut";
			this.DeleteEventBut.Size = new System.Drawing.Size(86, 40);
			this.DeleteEventBut.TabIndex = 1;
			this.DeleteEventBut.Text = "Delete";
			this.DeleteEventBut.UseVisualStyleBackColor = true;
			this.DeleteEventBut.Click += new System.EventHandler(this.DeleteEventBut_Click);
			// 
			// eventDetailsBackBut
			// 
			this.eventDetailsBackBut.ForeColor = System.Drawing.Color.Red;
			this.eventDetailsBackBut.Location = new System.Drawing.Point(4, 209);
			this.eventDetailsBackBut.Name = "eventDetailsBackBut";
			this.eventDetailsBackBut.Size = new System.Drawing.Size(81, 40);
			this.eventDetailsBackBut.TabIndex = 0;
			this.eventDetailsBackBut.Text = "Back";
			this.eventDetailsBackBut.UseVisualStyleBackColor = true;
			this.eventDetailsBackBut.Click += new System.EventHandler(this.eventDetailsBackBut_Click);
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
			this.monthView.Location = new System.Drawing.Point(670, 49);
			this.monthView.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
			this.monthView.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
			this.monthView.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.monthView.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
			this.monthView.Name = "monthView";
			this.monthView.Size = new System.Drawing.Size(285, 209);
			this.monthView.TabIndex = 8;
			this.monthView.Text = "monthView";
			this.monthView.TodayBorderColor = System.Drawing.Color.Maroon;
			this.monthView.SelectionChanged += new System.EventHandler(this.monthView_SelectionChanged);
			// 
			// calendar
			// 
			this.calendar.Font = new System.Drawing.Font("Segoe UI", 9F);
			calendarHighlightRange21.DayOfWeek = System.DayOfWeek.Monday;
			calendarHighlightRange21.EndTime = System.TimeSpan.Parse("17:00:00");
			calendarHighlightRange21.StartTime = System.TimeSpan.Parse("08:00:00");
			calendarHighlightRange22.DayOfWeek = System.DayOfWeek.Tuesday;
			calendarHighlightRange22.EndTime = System.TimeSpan.Parse("17:00:00");
			calendarHighlightRange22.StartTime = System.TimeSpan.Parse("08:00:00");
			calendarHighlightRange23.DayOfWeek = System.DayOfWeek.Wednesday;
			calendarHighlightRange23.EndTime = System.TimeSpan.Parse("17:00:00");
			calendarHighlightRange23.StartTime = System.TimeSpan.Parse("08:00:00");
			calendarHighlightRange24.DayOfWeek = System.DayOfWeek.Thursday;
			calendarHighlightRange24.EndTime = System.TimeSpan.Parse("17:00:00");
			calendarHighlightRange24.StartTime = System.TimeSpan.Parse("08:00:00");
			calendarHighlightRange25.DayOfWeek = System.DayOfWeek.Friday;
			calendarHighlightRange25.EndTime = System.TimeSpan.Parse("17:00:00");
			calendarHighlightRange25.StartTime = System.TimeSpan.Parse("08:00:00");
			this.calendar.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange21,
        calendarHighlightRange22,
        calendarHighlightRange23,
        calendarHighlightRange24,
        calendarHighlightRange25};
			this.calendar.Location = new System.Drawing.Point(7, 6);
			this.calendar.Name = "calendar";
			this.calendar.Size = new System.Drawing.Size(611, 539);
			this.calendar.TabIndex = 7;
			this.calendar.Text = "calendar";
			this.calendar.LoadItems += new System.Windows.Forms.Calendar.Calendar.CalendarLoadEventHandler(this.calendar_LoadItems);
			this.calendar.ItemDoubleClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar_ItemDoubleClick);
			// 
			// textBox7
			// 
			this.textBox7.BackColor = System.Drawing.SystemColors.Control;
			this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox7.Location = new System.Drawing.Point(14, 110);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(100, 13);
			this.textBox7.TabIndex = 0;
			this.textBox7.Text = "End Time";
			// 
			// detailsEndTime
			// 
			this.detailsEndTime.BackColor = System.Drawing.SystemColors.Control;
			this.detailsEndTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.detailsEndTime.Location = new System.Drawing.Point(82, 110);
			this.detailsEndTime.Name = "detailsEndTime";
			this.detailsEndTime.Size = new System.Drawing.Size(144, 13);
			this.detailsEndTime.TabIndex = 0;
			this.detailsEndTime.TextChanged += new System.EventHandler(this.detailsEndTime_TextChanged);
			// 
			// mainForm
			// 
			this.ClientSize = new System.Drawing.Size(1013, 557);
			this.Controls.Add(this.eventDetailsPanel);
			this.Controls.Add(this.filteringPanel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.monthView);
			this.Controls.Add(this.calendar);
			this.Controls.Add(this.mainPanel);
			this.Name = "mainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Time Management App";
			this.mainPanel.ResumeLayout(false);
			this.filteringPanel.ResumeLayout(false);
			this.filteringPanel.PerformLayout();
			this.eventDetailsPanel.ResumeLayout(false);
			this.eventDetailsPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.Button TeamButton;
        private System.Windows.Forms.Button addEvent;
        private System.Windows.Forms.Calendar.Calendar calendar;
        private System.Windows.Forms.Calendar.MonthView monthView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button backButton;
		private System.Windows.Forms.Button filterUserScheduleBut;
		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.Panel filteringPanel;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button filterDoneButton;
		private System.Windows.Forms.Button filterBackBut;
		private System.Windows.Forms.CheckBox High;
		private System.Windows.Forms.CheckBox Medium;
		private System.Windows.Forms.CheckBox Low;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Panel eventDetailsPanel;
		private System.Windows.Forms.Button ModifyEventBut;
		private System.Windows.Forms.Button DeleteEventBut;
		private System.Windows.Forms.Button eventDetailsBackBut;
		private System.Windows.Forms.TextBox detailsEventName;
		private System.Windows.Forms.TextBox detailsPriority;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.TextBox detailsStartTime;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.TextBox detailsEndTime;
		private System.Windows.Forms.TextBox textBox7;
	}
}