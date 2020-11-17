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
			System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange1 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
			System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange2 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
			System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange3 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
			System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange4 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
			System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange5 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
			this.TeamButton = new System.Windows.Forms.Button();
			this.addEvent = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.monthView = new System.Windows.Forms.Calendar.MonthView();
			this.calendar = new System.Windows.Forms.Calendar.Calendar();
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
			this.mainPanel.SuspendLayout();
			this.filteringPanel.SuspendLayout();
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
			this.calendar.Location = new System.Drawing.Point(7, 6);
			this.calendar.Name = "calendar";
			this.calendar.Size = new System.Drawing.Size(611, 539);
			this.calendar.TabIndex = 7;
			this.calendar.Text = "calendar";
			this.calendar.LoadItems += new System.Windows.Forms.Calendar.Calendar.CalendarLoadEventHandler(this.calendar_LoadItems);
			this.calendar.ItemDoubleClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar_ItemDoubleClick);
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
			this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
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
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
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
			// mainForm
			// 
			this.ClientSize = new System.Drawing.Size(1013, 557);
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
	}
}