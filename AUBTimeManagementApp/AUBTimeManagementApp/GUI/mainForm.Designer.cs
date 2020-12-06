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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange1 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange2 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange3 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange4 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange5 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            this.TeamButton = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.addEvent = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.filterUserScheduleBut = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.InvitationsButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Button();
            this.eventDetailsPanel = new System.Windows.Forms.Panel();
            this.timePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.timePickerStart = new System.Windows.Forms.DateTimePicker();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.ModifyPriority = new System.Windows.Forms.HScrollBar();
            this.datePickerStart = new System.Windows.Forms.DateTimePicker();
            this.datePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.detailsEndTime = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.detailsEventName = new System.Windows.Forms.TextBox();
            this.ModifyEventBut = new System.Windows.Forms.Button();
            this.DeleteEventBut = new System.Windows.Forms.Button();
            this.eventDetailsBackBut = new System.Windows.Forms.Button();
            this.filteringPanel = new System.Windows.Forms.Panel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.filterDoneButton = new System.Windows.Forms.Button();
            this.filterBackBut = new System.Windows.Forms.Button();
            this.High = new System.Windows.Forms.CheckBox();
            this.Medium = new System.Windows.Forms.CheckBox();
            this.Low = new System.Windows.Forms.CheckBox();
            this.monthView = new System.Windows.Forms.Calendar.MonthView();
            this.calendar = new System.Windows.Forms.Calendar.Calendar();
            this.eventTypeText = new System.Windows.Forms.TextBox();
            this.mainPanel.SuspendLayout();
            this.eventDetailsPanel.SuspendLayout();
            this.filteringPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TeamButton
            // 
            this.TeamButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TeamButton.ImageIndex = 4;
            this.TeamButton.ImageList = this.imageList1;
            this.TeamButton.Location = new System.Drawing.Point(32, 115);
            this.TeamButton.Name = "TeamButton";
            this.TeamButton.Size = new System.Drawing.Size(266, 40);
            this.TeamButton.TabIndex = 0;
            this.TeamButton.Text = "    Teams ";
            this.TeamButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TeamButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TeamButton.UseVisualStyleBackColor = true;
            this.TeamButton.Click += new System.EventHandler(this.TeamButton_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "user.png");
            this.imageList1.Images.SetKeyName(1, "refresh-button-icon-18.jpg");
            this.imageList1.Images.SetKeyName(2, "filter.png");
            this.imageList1.Images.SetKeyName(3, "home.png");
            this.imageList1.Images.SetKeyName(4, "group.png");
            this.imageList1.Images.SetKeyName(5, "Invitations.jpg");
            this.imageList1.Images.SetKeyName(6, "notification.png");
            // 
            // addEvent
            // 
            this.addEvent.Location = new System.Drawing.Point(32, 70);
            this.addEvent.Name = "addEvent";
            this.addEvent.Size = new System.Drawing.Size(266, 40);
            this.addEvent.TabIndex = 1;
            this.addEvent.Text = "Add Event";
            this.addEvent.UseVisualStyleBackColor = true;
            this.addEvent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.addEvent_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(787, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // backButton
            // 
            this.backButton.ForeColor = System.Drawing.Color.Black;
            this.backButton.ImageIndex = 3;
            this.backButton.ImageList = this.imageList1;
            this.backButton.Location = new System.Drawing.Point(32, 252);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(266, 40);
            this.backButton.TabIndex = 10;
            this.backButton.Text = "     Log Out";
            this.backButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.backButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // filterUserScheduleBut
            // 
            this.filterUserScheduleBut.ImageIndex = 2;
            this.filterUserScheduleBut.ImageList = this.imageList1;
            this.filterUserScheduleBut.Location = new System.Drawing.Point(32, 17);
            this.filterUserScheduleBut.Name = "filterUserScheduleBut";
            this.filterUserScheduleBut.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.filterUserScheduleBut.Size = new System.Drawing.Size(124, 46);
            this.filterUserScheduleBut.TabIndex = 18;
            this.filterUserScheduleBut.Text = "  Filter";
            this.filterUserScheduleBut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.filterUserScheduleBut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.filterUserScheduleBut.UseVisualStyleBackColor = true;
            this.filterUserScheduleBut.Click += new System.EventHandler(this.filterUserScheduleBut_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.InvitationsButton);
            this.mainPanel.Controls.Add(this.button1);
            this.mainPanel.Controls.Add(this.backButton);
            this.mainPanel.Controls.Add(this.filterUserScheduleBut);
            this.mainPanel.Controls.Add(this.TeamButton);
            this.mainPanel.Controls.Add(this.Refresh);
            this.mainPanel.Controls.Add(this.addEvent);
            this.mainPanel.Location = new System.Drawing.Point(657, 244);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(328, 301);
            this.mainPanel.TabIndex = 19;
            // 
            // InvitationsButton
            // 
            this.InvitationsButton.ImageIndex = 5;
            this.InvitationsButton.ImageList = this.imageList1;
            this.InvitationsButton.Location = new System.Drawing.Point(32, 161);
            this.InvitationsButton.Name = "InvitationsButton";
            this.InvitationsButton.Size = new System.Drawing.Size(266, 40);
            this.InvitationsButton.TabIndex = 22;
            this.InvitationsButton.Text = "    Invitations ";
            this.InvitationsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.InvitationsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.InvitationsButton.UseVisualStyleBackColor = true;
            this.InvitationsButton.Click += new System.EventHandler(this.InvitationsButton_Click);
            // 
            // button1
            // 
            this.button1.ImageIndex = 0;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(32, 207);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(266, 40);
            this.button1.TabIndex = 21;
            this.button1.Text = "     Profile   ";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Refresh
            // 
            this.Refresh.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Refresh.ForeColor = System.Drawing.Color.Black;
            this.Refresh.ImageIndex = 1;
            this.Refresh.ImageList = this.imageList1;
            this.Refresh.Location = new System.Drawing.Point(174, 17);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(124, 46);
            this.Refresh.TabIndex = 20;
            this.Refresh.Text = "  Refresh";
            this.Refresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Refresh.UseVisualStyleBackColor = false;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // eventDetailsPanel
            // 
            this.eventDetailsPanel.Controls.Add(this.eventTypeText);
            this.eventDetailsPanel.Controls.Add(this.timePickerEnd);
            this.eventDetailsPanel.Controls.Add(this.timePickerStart);
            this.eventDetailsPanel.Controls.Add(this.textBox5);
            this.eventDetailsPanel.Controls.Add(this.textBox8);
            this.eventDetailsPanel.Controls.Add(this.ModifyPriority);
            this.eventDetailsPanel.Controls.Add(this.datePickerStart);
            this.eventDetailsPanel.Controls.Add(this.datePickerEnd);
            this.eventDetailsPanel.Controls.Add(this.detailsEndTime);
            this.eventDetailsPanel.Controls.Add(this.textBox7);
            this.eventDetailsPanel.Controls.Add(this.textBox10);
            this.eventDetailsPanel.Controls.Add(this.textBox6);
            this.eventDetailsPanel.Controls.Add(this.detailsEventName);
            this.eventDetailsPanel.Controls.Add(this.ModifyEventBut);
            this.eventDetailsPanel.Controls.Add(this.DeleteEventBut);
            this.eventDetailsPanel.Controls.Add(this.eventDetailsBackBut);
            this.eventDetailsPanel.Location = new System.Drawing.Point(635, 257);
            this.eventDetailsPanel.Name = "eventDetailsPanel";
            this.eventDetailsPanel.Size = new System.Drawing.Size(377, 285);
            this.eventDetailsPanel.TabIndex = 20;
            // 
            // timePickerEnd
            // 
            this.timePickerEnd.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.timePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerEnd.Location = new System.Drawing.Point(232, 92);
            this.timePickerEnd.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.timePickerEnd.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.timePickerEnd.Name = "timePickerEnd";
            this.timePickerEnd.ShowUpDown = true;
            this.timePickerEnd.Size = new System.Drawing.Size(134, 26);
            this.timePickerEnd.TabIndex = 22;
            this.timePickerEnd.Value = new System.DateTime(2020, 12, 6, 12, 8, 0, 0);
            // 
            // timePickerStart
            // 
            this.timePickerStart.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.timePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerStart.Location = new System.Drawing.Point(232, 61);
            this.timePickerStart.Name = "timePickerStart";
            this.timePickerStart.ShowUpDown = true;
            this.timePickerStart.Size = new System.Drawing.Size(134, 26);
            this.timePickerStart.TabIndex = 21;
            this.timePickerStart.Value = new System.DateTime(2020, 11, 24, 16, 51, 25, 0);
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(248, 126);
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
            this.textBox8.Location = new System.Drawing.Point(79, 126);
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
            this.ModifyPriority.Location = new System.Drawing.Point(119, 145);
            this.ModifyPriority.Maximum = 3;
            this.ModifyPriority.Minimum = 1;
            this.ModifyPriority.Name = "ModifyPriority";
            this.ModifyPriority.Size = new System.Drawing.Size(224, 26);
            this.ModifyPriority.TabIndex = 18;
            this.ModifyPriority.Value = 1;
            // 
            // datePickerStart
            // 
            this.datePickerStart.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.datePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerStart.Location = new System.Drawing.Point(82, 61);
            this.datePickerStart.Name = "datePickerStart";
            this.datePickerStart.Size = new System.Drawing.Size(144, 26);
            this.datePickerStart.TabIndex = 12;
            this.datePickerStart.Value = new System.DateTime(2020, 11, 24, 16, 51, 25, 0);
            // 
            // datePickerEnd
            // 
            this.datePickerEnd.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.datePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerEnd.Location = new System.Drawing.Point(82, 93);
            this.datePickerEnd.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.datePickerEnd.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.datePickerEnd.Name = "datePickerEnd";
            this.datePickerEnd.Size = new System.Drawing.Size(144, 26);
            this.datePickerEnd.TabIndex = 11;
            this.datePickerEnd.Value = new System.DateTime(2020, 12, 6, 12, 8, 0, 0);
            // 
            // detailsEndTime
            // 
            this.detailsEndTime.BackColor = System.Drawing.SystemColors.Control;
            this.detailsEndTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detailsEndTime.Location = new System.Drawing.Point(82, 97);
            this.detailsEndTime.Name = "detailsEndTime";
            this.detailsEndTime.Size = new System.Drawing.Size(144, 19);
            this.detailsEndTime.TabIndex = 0;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Control;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Location = new System.Drawing.Point(14, 97);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(100, 19);
            this.textBox7.TabIndex = 0;
            this.textBox7.Text = "End Time:";
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
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Control;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Location = new System.Drawing.Point(14, 60);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(101, 19);
            this.textBox6.TabIndex = 4;
            this.textBox6.Text = "Start Time: ";
            // 
            // detailsEventName
            // 
            this.detailsEventName.BackColor = System.Drawing.SystemColors.Control;
            this.detailsEventName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detailsEventName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.detailsEventName.Location = new System.Drawing.Point(11, 10);
            this.detailsEventName.Multiline = true;
            this.detailsEventName.Name = "detailsEventName";
            this.detailsEventName.Size = new System.Drawing.Size(215, 30);
            this.detailsEventName.TabIndex = 3;
            this.detailsEventName.Text = "sdadsad";
            this.detailsEventName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ModifyEventBut
            // 
            this.ModifyEventBut.Location = new System.Drawing.Point(262, 195);
            this.ModifyEventBut.Name = "ModifyEventBut";
            this.ModifyEventBut.Size = new System.Drawing.Size(95, 39);
            this.ModifyEventBut.TabIndex = 2;
            this.ModifyEventBut.Text = "Modify";
            this.ModifyEventBut.UseVisualStyleBackColor = true;
            this.ModifyEventBut.Click += new System.EventHandler(this.ModifyEventBut_Click);
            // 
            // DeleteEventBut
            // 
            this.DeleteEventBut.Location = new System.Drawing.Point(139, 195);
            this.DeleteEventBut.Name = "DeleteEventBut";
            this.DeleteEventBut.Size = new System.Drawing.Size(96, 40);
            this.DeleteEventBut.TabIndex = 1;
            this.DeleteEventBut.Text = "Delete";
            this.DeleteEventBut.UseVisualStyleBackColor = true;
            this.DeleteEventBut.Click += new System.EventHandler(this.DeleteEventBut_Click);
            // 
            // eventDetailsBackBut
            // 
            this.eventDetailsBackBut.ForeColor = System.Drawing.Color.Red;
            this.eventDetailsBackBut.Location = new System.Drawing.Point(11, 195);
            this.eventDetailsBackBut.Name = "eventDetailsBackBut";
            this.eventDetailsBackBut.Size = new System.Drawing.Size(100, 40);
            this.eventDetailsBackBut.TabIndex = 0;
            this.eventDetailsBackBut.Text = "Back";
            this.eventDetailsBackBut.UseVisualStyleBackColor = true;
            this.eventDetailsBackBut.Click += new System.EventHandler(this.eventDetailsBackBut_Click);
            // 
            // filteringPanel
            // 
            this.filteringPanel.Controls.Add(this.textBox4);
            this.filteringPanel.Controls.Add(this.textBox3);
            this.filteringPanel.Controls.Add(this.textBox2);
            this.filteringPanel.Controls.Add(this.textBox1);
            this.filteringPanel.Controls.Add(this.filterDoneButton);
            this.filteringPanel.Controls.Add(this.filterBackBut);
            this.filteringPanel.Controls.Add(this.High);
            this.filteringPanel.Controls.Add(this.Medium);
            this.filteringPanel.Controls.Add(this.Low);
            this.filteringPanel.Location = new System.Drawing.Point(650, 292);
            this.filteringPanel.Name = "filteringPanel";
            this.filteringPanel.Size = new System.Drawing.Size(365, 246);
            this.filteringPanel.TabIndex = 19;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox4.Location = new System.Drawing.Point(99, 11);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(199, 28);
            this.textBox4.TabIndex = 8;
            this.textBox4.Text = "Choose Priority";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox3.Location = new System.Drawing.Point(246, 78);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(52, 23);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "High";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox2.Location = new System.Drawing.Point(154, 77);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(61, 23);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "Medium";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox1.Location = new System.Drawing.Point(77, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(47, 23);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Low";
            // 
            // filterDoneButton
            // 
            this.filterDoneButton.ForeColor = System.Drawing.Color.Green;
            this.filterDoneButton.Location = new System.Drawing.Point(207, 163);
            this.filterDoneButton.Name = "filterDoneButton";
            this.filterDoneButton.Size = new System.Drawing.Size(107, 34);
            this.filterDoneButton.TabIndex = 4;
            this.filterDoneButton.Text = "Filter";
            this.filterDoneButton.UseVisualStyleBackColor = true;
            this.filterDoneButton.Click += new System.EventHandler(this.filterDoneButton_Click);
            // 
            // filterBackBut
            // 
            this.filterBackBut.ForeColor = System.Drawing.Color.Red;
            this.filterBackBut.Location = new System.Drawing.Point(67, 163);
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
            this.High.Location = new System.Drawing.Point(256, 102);
            this.High.Name = "High";
            this.High.Size = new System.Drawing.Size(22, 21);
            this.High.TabIndex = 2;
            this.High.UseVisualStyleBackColor = true;
            // 
            // Medium
            // 
            this.Medium.AutoSize = true;
            this.Medium.Location = new System.Drawing.Point(176, 103);
            this.Medium.Name = "Medium";
            this.Medium.Size = new System.Drawing.Size(22, 21);
            this.Medium.TabIndex = 1;
            this.Medium.UseVisualStyleBackColor = true;
            // 
            // Low
            // 
            this.Low.AutoSize = true;
            this.Low.Location = new System.Drawing.Point(87, 102);
            this.Low.Name = "Low";
            this.Low.Size = new System.Drawing.Size(22, 21);
            this.Low.TabIndex = 0;
            this.Low.UseVisualStyleBackColor = true;
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
            this.monthView.Location = new System.Drawing.Point(690, 27);
            this.monthView.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthView.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
            this.monthView.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.monthView.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
            this.monthView.Name = "monthView";
            this.monthView.Size = new System.Drawing.Size(258, 196);
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
            // eventTypeText
            // 
            this.eventTypeText.BackColor = System.Drawing.SystemColors.Control;
            this.eventTypeText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventTypeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.eventTypeText.Location = new System.Drawing.Point(232, 13);
            this.eventTypeText.Multiline = true;
            this.eventTypeText.Name = "eventTypeText";
            this.eventTypeText.Size = new System.Drawing.Size(142, 30);
            this.eventTypeText.TabIndex = 23;
            this.eventTypeText.Text = "Personal Event";
            this.eventTypeText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mainForm
            // 
            this.ClientSize = new System.Drawing.Size(1013, 557);
            this.Controls.Add(this.eventDetailsPanel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthView);
            this.Controls.Add(this.calendar);
            this.Controls.Add(this.filteringPanel);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time Management App";
            this.mainPanel.ResumeLayout(false);
            this.eventDetailsPanel.ResumeLayout(false);
            this.eventDetailsPanel.PerformLayout();
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
		private System.Windows.Forms.Panel eventDetailsPanel;
		private System.Windows.Forms.Button ModifyEventBut;
		private System.Windows.Forms.Button DeleteEventBut;
		private System.Windows.Forms.Button eventDetailsBackBut;
		private System.Windows.Forms.TextBox detailsEventName;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.TextBox detailsEndTime;
		private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button Refresh;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DateTimePicker datePickerStart;
		private System.Windows.Forms.DateTimePicker datePickerEnd;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.HScrollBar ModifyPriority;
        private System.Windows.Forms.Button InvitationsButton;
        private System.Windows.Forms.DateTimePicker timePickerStart;
        private System.Windows.Forms.DateTimePicker timePickerEnd;
        private System.Windows.Forms.TextBox eventTypeText;
    }
}