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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange6 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange7 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange8 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange9 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange10 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamCalendarForm));
            this.calendar = new System.Windows.Forms.Calendar.Calendar();
            this.eventDetailsPanel = new System.Windows.Forms.Panel();
            this.priorityBox = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.ModifyPriority = new System.Windows.Forms.HScrollBar();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.priorityBoxBackButton = new System.Windows.Forms.Button();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.LinkBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.timePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.timePickerStart = new System.Windows.Forms.DateTimePicker();
            this.modifyEventPriority = new System.Windows.Forms.HScrollBar();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.datePickerStart = new System.Windows.Forms.DateTimePicker();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.datePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.detailsEventName = new System.Windows.Forms.TextBox();
            this.ModifyEventBut = new System.Windows.Forms.Button();
            this.DeleteEventBut = new System.Windows.Forms.Button();
            this.eventDetailsBackBut = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.monthView = new System.Windows.Forms.Calendar.MonthView();
            this.teamNameLabel = new System.Windows.Forms.Label();
            this.addEventButton = new System.Windows.Forms.Button();
            this.teamSchedButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.mergedSchedButton = new System.Windows.Forms.Button();
            this.memberState = new System.Windows.Forms.Label();
            this.eventDetailsPanel.SuspendLayout();
            this.priorityBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // calendar
            // 
            this.calendar.Font = new System.Drawing.Font("Segoe UI", 9F);
            calendarHighlightRange6.DayOfWeek = System.DayOfWeek.Monday;
            calendarHighlightRange6.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange6.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange7.DayOfWeek = System.DayOfWeek.Tuesday;
            calendarHighlightRange7.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange7.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange8.DayOfWeek = System.DayOfWeek.Wednesday;
            calendarHighlightRange8.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange8.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange9.DayOfWeek = System.DayOfWeek.Thursday;
            calendarHighlightRange9.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange9.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange10.DayOfWeek = System.DayOfWeek.Friday;
            calendarHighlightRange10.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange10.StartTime = System.TimeSpan.Parse("08:00:00");
            this.calendar.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange6,
        calendarHighlightRange7,
        calendarHighlightRange8,
        calendarHighlightRange9,
        calendarHighlightRange10};
            this.calendar.Location = new System.Drawing.Point(12, 12);
            this.calendar.Name = "calendar";
            this.calendar.Size = new System.Drawing.Size(611, 539);
            this.calendar.TabIndex = 8;
            this.calendar.Text = "calendar";
            this.calendar.LoadItems += new System.Windows.Forms.Calendar.Calendar.CalendarLoadEventHandler(this.calendar_LoadItems);
            this.calendar.ItemDoubleClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar_ItemDoubleClick);
            // 
            // eventDetailsPanel
            // 
            this.eventDetailsPanel.Controls.Add(this.textBox11);
            this.eventDetailsPanel.Controls.Add(this.LinkBox);
            this.eventDetailsPanel.Controls.Add(this.textBox2);
            this.eventDetailsPanel.Controls.Add(this.timePickerEnd);
            this.eventDetailsPanel.Controls.Add(this.textBox3);
            this.eventDetailsPanel.Controls.Add(this.timePickerStart);
            this.eventDetailsPanel.Controls.Add(this.modifyEventPriority);
            this.eventDetailsPanel.Controls.Add(this.textBox4);
            this.eventDetailsPanel.Controls.Add(this.datePickerStart);
            this.eventDetailsPanel.Controls.Add(this.textBox6);
            this.eventDetailsPanel.Controls.Add(this.datePickerEnd);
            this.eventDetailsPanel.Controls.Add(this.detailsEventName);
            this.eventDetailsPanel.Controls.Add(this.ModifyEventBut);
            this.eventDetailsPanel.Controls.Add(this.DeleteEventBut);
            this.eventDetailsPanel.Controls.Add(this.eventDetailsBackBut);
            this.eventDetailsPanel.Controls.Add(this.textBox7);
            this.eventDetailsPanel.Location = new System.Drawing.Point(629, 264);
            this.eventDetailsPanel.Name = "eventDetailsPanel";
            this.eventDetailsPanel.Size = new System.Drawing.Size(372, 287);
            this.eventDetailsPanel.TabIndex = 24;
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
            this.priorityBox.Location = new System.Drawing.Point(649, 280);
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
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.SystemColors.Control;
            this.textBox11.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox11.Location = new System.Drawing.Point(18, 202);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(65, 19);
            this.textBox11.TabIndex = 35;
            this.textBox11.Text = "Link: ";
            // 
            // LinkBox
            // 
            this.LinkBox.BackColor = System.Drawing.SystemColors.Control;
            this.LinkBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LinkBox.Location = new System.Drawing.Point(86, 199);
            this.LinkBox.Multiline = true;
            this.LinkBox.Name = "LinkBox";
            this.LinkBox.Size = new System.Drawing.Size(279, 20);
            this.LinkBox.TabIndex = 34;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(266, 137);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(62, 23);
            this.textBox2.TabIndex = 33;
            this.textBox2.Text = "high";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timePickerEnd
            // 
            this.timePickerEnd.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.timePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerEnd.Location = new System.Drawing.Point(231, 101);
            this.timePickerEnd.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.timePickerEnd.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.timePickerEnd.Name = "timePickerEnd";
            this.timePickerEnd.ShowUpDown = true;
            this.timePickerEnd.Size = new System.Drawing.Size(134, 26);
            this.timePickerEnd.TabIndex = 22;
            this.timePickerEnd.Value = new System.DateTime(2020, 12, 6, 12, 8, 0, 0);
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(140, 137);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(62, 23);
            this.textBox3.TabIndex = 32;
            this.textBox3.Text = "low";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timePickerStart
            // 
            this.timePickerStart.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.timePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerStart.Location = new System.Drawing.Point(231, 70);
            this.timePickerStart.Name = "timePickerStart";
            this.timePickerStart.ShowUpDown = true;
            this.timePickerStart.Size = new System.Drawing.Size(134, 26);
            this.timePickerStart.TabIndex = 21;
            this.timePickerStart.Value = new System.DateTime(2020, 11, 24, 16, 51, 25, 0);
            // 
            // modifyEventPriority
            // 
            this.modifyEventPriority.LargeChange = 1;
            this.modifyEventPriority.Location = new System.Drawing.Point(115, 156);
            this.modifyEventPriority.Maximum = 3;
            this.modifyEventPriority.Minimum = 1;
            this.modifyEventPriority.Name = "modifyEventPriority";
            this.modifyEventPriority.Size = new System.Drawing.Size(224, 26);
            this.modifyEventPriority.TabIndex = 31;
            this.modifyEventPriority.Value = 1;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(18, 156);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(101, 19);
            this.textBox4.TabIndex = 28;
            this.textBox4.Text = "Priority: ";
            // 
            // datePickerStart
            // 
            this.datePickerStart.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.datePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerStart.Location = new System.Drawing.Point(81, 70);
            this.datePickerStart.Name = "datePickerStart";
            this.datePickerStart.Size = new System.Drawing.Size(144, 26);
            this.datePickerStart.TabIndex = 12;
            this.datePickerStart.Value = new System.DateTime(2020, 11, 24, 16, 51, 25, 0);
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Control;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Location = new System.Drawing.Point(18, 73);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(101, 19);
            this.textBox6.TabIndex = 27;
            this.textBox6.Text = "Start Time: ";
            // 
            // datePickerEnd
            // 
            this.datePickerEnd.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.datePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerEnd.Location = new System.Drawing.Point(81, 102);
            this.datePickerEnd.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.datePickerEnd.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.datePickerEnd.Name = "datePickerEnd";
            this.datePickerEnd.Size = new System.Drawing.Size(144, 26);
            this.datePickerEnd.TabIndex = 11;
            this.datePickerEnd.Value = new System.DateTime(2020, 12, 6, 12, 8, 0, 0);
            // 
            // detailsEventName
            // 
            this.detailsEventName.BackColor = System.Drawing.SystemColors.Control;
            this.detailsEventName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detailsEventName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.detailsEventName.Location = new System.Drawing.Point(47, 21);
            this.detailsEventName.Multiline = true;
            this.detailsEventName.Name = "detailsEventName";
            this.detailsEventName.Size = new System.Drawing.Size(277, 39);
            this.detailsEventName.TabIndex = 26;
            this.detailsEventName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ModifyEventBut
            // 
            this.ModifyEventBut.Location = new System.Drawing.Point(261, 244);
            this.ModifyEventBut.Name = "ModifyEventBut";
            this.ModifyEventBut.Size = new System.Drawing.Size(96, 39);
            this.ModifyEventBut.TabIndex = 25;
            this.ModifyEventBut.Text = "Modify";
            this.ModifyEventBut.UseVisualStyleBackColor = true;
            this.ModifyEventBut.Click += new System.EventHandler(this.ModifyEventBut_Click);
            // 
            // DeleteEventBut
            // 
            this.DeleteEventBut.Location = new System.Drawing.Point(145, 243);
            this.DeleteEventBut.Name = "DeleteEventBut";
            this.DeleteEventBut.Size = new System.Drawing.Size(95, 40);
            this.DeleteEventBut.TabIndex = 24;
            this.DeleteEventBut.Text = "Delete";
            this.DeleteEventBut.UseVisualStyleBackColor = true;
            this.DeleteEventBut.Click += new System.EventHandler(this.DeleteEventBut_Click);
            // 
            // eventDetailsBackBut
            // 
            this.eventDetailsBackBut.ForeColor = System.Drawing.Color.Red;
            this.eventDetailsBackBut.Location = new System.Drawing.Point(23, 244);
            this.eventDetailsBackBut.Name = "eventDetailsBackBut";
            this.eventDetailsBackBut.Size = new System.Drawing.Size(96, 40);
            this.eventDetailsBackBut.TabIndex = 23;
            this.eventDetailsBackBut.Text = "Back";
            this.eventDetailsBackBut.UseVisualStyleBackColor = true;
            this.eventDetailsBackBut.Click += new System.EventHandler(this.eventDetailsBackBut_Click);
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Control;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Location = new System.Drawing.Point(16, 109);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(100, 19);
            this.textBox7.TabIndex = 22;
            this.textBox7.Text = "End Time:";
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
            this.addEventButton.ImageIndex = 7;
            this.addEventButton.ImageList = this.imageList1;
            this.addEventButton.Location = new System.Drawing.Point(678, 280);
            this.addEventButton.Name = "addEventButton";
            this.addEventButton.Size = new System.Drawing.Size(266, 54);
            this.addEventButton.TabIndex = 2;
            this.addEventButton.Text = "   Add Event ";
            this.addEventButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addEventButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addEventButton.UseVisualStyleBackColor = true;
            this.addEventButton.Click += new System.EventHandler(this.addEvent_Click);
            // 
            // teamSchedButton
            // 
            this.teamSchedButton.ImageIndex = 5;
            this.teamSchedButton.ImageList = this.imageList1;
            this.teamSchedButton.Location = new System.Drawing.Point(678, 421);
            this.teamSchedButton.Name = "teamSchedButton";
            this.teamSchedButton.Size = new System.Drawing.Size(266, 54);
            this.teamSchedButton.TabIndex = 11;
            this.teamSchedButton.Text = " Show Team Schedule  ";
            this.teamSchedButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.teamSchedButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.teamSchedButton.UseVisualStyleBackColor = true;
            this.teamSchedButton.Click += new System.EventHandler(this.teamSchedButton_Click);
            // 
            // backButton
            // 
            this.backButton.ImageIndex = 2;
            this.backButton.ImageList = this.imageList1;
            this.backButton.Location = new System.Drawing.Point(678, 490);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(266, 54);
            this.backButton.TabIndex = 12;
            this.backButton.Text = "     Back     ";
            this.backButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.backButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "refresh-button-icon-18.jpg");
            this.imageList1.Images.SetKeyName(1, "filter.png");
            this.imageList1.Images.SetKeyName(2, "home.png");
            this.imageList1.Images.SetKeyName(3, "group.png");
            this.imageList1.Images.SetKeyName(4, "Invitations.jpg");
            this.imageList1.Images.SetKeyName(5, "calendar.png");
            this.imageList1.Images.SetKeyName(6, "exit.png");
            this.imageList1.Images.SetKeyName(7, "add.png");
            // 
            // mergedSchedButton
            // 
            this.mergedSchedButton.ImageIndex = 5;
            this.mergedSchedButton.ImageList = this.imageList1;
            this.mergedSchedButton.Location = new System.Drawing.Point(678, 350);
            this.mergedSchedButton.Name = "mergedSchedButton";
            this.mergedSchedButton.Size = new System.Drawing.Size(266, 54);
            this.mergedSchedButton.TabIndex = 13;
            this.mergedSchedButton.Text = " Show Merged Schedule";
            this.mergedSchedButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mergedSchedButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
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
            this.eventDetailsPanel.ResumeLayout(false);
            this.eventDetailsPanel.PerformLayout();
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
		private System.Windows.Forms.Panel eventDetailsPanel;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.HScrollBar modifyEventPriority;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.TextBox detailsEventName;
		private System.Windows.Forms.Button ModifyEventBut;
		private System.Windows.Forms.Button DeleteEventBut;
		private System.Windows.Forms.Button eventDetailsBackBut;
        private System.Windows.Forms.DateTimePicker timePickerEnd;
        private System.Windows.Forms.DateTimePicker timePickerStart;
        private System.Windows.Forms.DateTimePicker datePickerStart;
        private System.Windows.Forms.DateTimePicker datePickerEnd;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.TextBox LinkBox;
        private System.Windows.Forms.ImageList imageList1;
    }
}