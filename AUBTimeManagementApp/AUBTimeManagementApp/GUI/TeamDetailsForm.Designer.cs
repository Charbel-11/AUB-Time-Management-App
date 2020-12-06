namespace AUBTimeManagementApp.GUI {
    partial class TeamDetailsForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamDetailsForm));
			this.teamName = new System.Windows.Forms.Label();
			this.memberState = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.adminBut = new System.Windows.Forms.Button();
			this.remBut = new System.Windows.Forms.Button();
			this.adminLabel = new System.Windows.Forms.Label();
			this.memberBut = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textField = new System.Windows.Forms.TextBox();
			this.addBut = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.backFromAddBut = new System.Windows.Forms.Button();
			this.feedbackText = new System.Windows.Forms.TextBox();
			this.addMemberBox = new System.Windows.Forms.Panel();
			this.buttonsBox = new System.Windows.Forms.Panel();
			this.backBut = new System.Windows.Forms.Button();
			this.leaveTeamBut = new System.Windows.Forms.Button();
			this.teamScheduleBut = new System.Windows.Forms.Button();
			this.scheduleEventBut = new System.Windows.Forms.Button();
			this.addMembersButton = new System.Windows.Forms.Button();
			this.flowLayoutPanel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.addMemberBox.SuspendLayout();
			this.buttonsBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// teamName
			// 
			this.teamName.AutoSize = true;
			this.teamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.teamName.Location = new System.Drawing.Point(184, 18);
			this.teamName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.teamName.Name = "teamName";
			this.teamName.Size = new System.Drawing.Size(162, 31);
			this.teamName.TabIndex = 0;
			this.teamName.Text = "Team Name";
			// 
			// memberState
			// 
			this.memberState.AutoSize = true;
			this.memberState.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.memberState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.memberState.Location = new System.Drawing.Point(507, 23);
			this.memberState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.memberState.Name = "memberState";
			this.memberState.Size = new System.Drawing.Size(68, 25);
			this.memberState.TabIndex = 1;
			this.memberState.Text = "Admin";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoScroll = true;
			this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel1.Controls.Add(this.groupBox1);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(28, 106);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(381, 227);
			this.flowLayoutPanel1.TabIndex = 12;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.adminBut);
			this.groupBox1.Controls.Add(this.remBut);
			this.groupBox1.Controls.Add(this.adminLabel);
			this.groupBox1.Controls.Add(this.memberBut);
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox1.Size = new System.Drawing.Size(361, 36);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// adminBut
			// 
			this.adminBut.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.adminBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.adminBut.ForeColor = System.Drawing.Color.White;
			this.adminBut.Location = new System.Drawing.Point(155, 4);
			this.adminBut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.adminBut.Name = "adminBut";
			this.adminBut.Size = new System.Drawing.Size(87, 27);
			this.adminBut.TabIndex = 3;
			this.adminBut.Text = "Dismiss as Admin";
			this.adminBut.UseVisualStyleBackColor = false;
			// 
			// remBut
			// 
			this.remBut.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.remBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.remBut.ForeColor = System.Drawing.Color.White;
			this.remBut.Location = new System.Drawing.Point(260, 4);
			this.remBut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.remBut.Name = "remBut";
			this.remBut.Size = new System.Drawing.Size(87, 27);
			this.remBut.TabIndex = 4;
			this.remBut.Text = "Remove from Team";
			this.remBut.UseVisualStyleBackColor = false;
			// 
			// adminLabel
			// 
			this.adminLabel.AutoSize = true;
			this.adminLabel.BackColor = System.Drawing.SystemColors.ControlLight;
			this.adminLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.adminLabel.Location = new System.Drawing.Point(289, 12);
			this.adminLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.adminLabel.Name = "adminLabel";
			this.adminLabel.Size = new System.Drawing.Size(36, 13);
			this.adminLabel.TabIndex = 2;
			this.adminLabel.Text = "Admin";
			// 
			// memberBut
			// 
			this.memberBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.memberBut.Location = new System.Drawing.Point(0, 0);
			this.memberBut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.memberBut.Name = "memberBut";
			this.memberBut.Size = new System.Drawing.Size(361, 34);
			this.memberBut.TabIndex = 1;
			this.memberBut.Text = "Member1";
			this.memberBut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.memberBut.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(172, 76);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 25);
			this.label1.TabIndex = 13;
			this.label1.Text = "Members";
			// 
			// textField
			// 
			this.textField.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textField.Location = new System.Drawing.Point(32, 71);
			this.textField.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.textField.Name = "textField";
			this.textField.Size = new System.Drawing.Size(172, 30);
			this.textField.TabIndex = 19;
			// 
			// addBut
			// 
			this.addBut.ImageList = this.imageList1;
			this.addBut.Location = new System.Drawing.Point(32, 121);
			this.addBut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.addBut.Name = "addBut";
			this.addBut.Size = new System.Drawing.Size(171, 41);
			this.addBut.TabIndex = 20;
			this.addBut.Text = "Add";
			this.addBut.UseVisualStyleBackColor = true;
			this.addBut.Click += new System.EventHandler(this.addBut_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "refresh-button-icon-18.jpg");
			this.imageList1.Images.SetKeyName(1, "filter.png");
			this.imageList1.Images.SetKeyName(2, "home.png");
			this.imageList1.Images.SetKeyName(3, "group.png");
			this.imageList1.Images.SetKeyName(4, "add.png");
			this.imageList1.Images.SetKeyName(5, "add-user.png");
			this.imageList1.Images.SetKeyName(6, "invitation.png");
			this.imageList1.Images.SetKeyName(7, "logout.png");
			this.imageList1.Images.SetKeyName(8, "calendar (1).png");
			this.imageList1.Images.SetKeyName(9, "schedule.png");
			// 
			// backFromAddBut
			// 
			this.backFromAddBut.Location = new System.Drawing.Point(32, 175);
			this.backFromAddBut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.backFromAddBut.Name = "backFromAddBut";
			this.backFromAddBut.Size = new System.Drawing.Size(171, 41);
			this.backFromAddBut.TabIndex = 21;
			this.backFromAddBut.Text = "Back";
			this.backFromAddBut.UseVisualStyleBackColor = true;
			this.backFromAddBut.Click += new System.EventHandler(this.backFromAddBut_Click);
			// 
			// feedbackText
			// 
			this.feedbackText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.feedbackText.Location = new System.Drawing.Point(32, 38);
			this.feedbackText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.feedbackText.Multiline = true;
			this.feedbackText.Name = "feedbackText";
			this.feedbackText.ReadOnly = true;
			this.feedbackText.Size = new System.Drawing.Size(171, 30);
			this.feedbackText.TabIndex = 22;
			this.feedbackText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// addMemberBox
			// 
			this.addMemberBox.Controls.Add(this.textField);
			this.addMemberBox.Controls.Add(this.backFromAddBut);
			this.addMemberBox.Controls.Add(this.feedbackText);
			this.addMemberBox.Controls.Add(this.addBut);
			this.addMemberBox.Location = new System.Drawing.Point(427, 102);
			this.addMemberBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.addMemberBox.Name = "addMemberBox";
			this.addMemberBox.Size = new System.Drawing.Size(229, 233);
			this.addMemberBox.TabIndex = 25;
			// 
			// buttonsBox
			// 
			this.buttonsBox.Controls.Add(this.backBut);
			this.buttonsBox.Controls.Add(this.leaveTeamBut);
			this.buttonsBox.Controls.Add(this.teamScheduleBut);
			this.buttonsBox.Controls.Add(this.scheduleEventBut);
			this.buttonsBox.Controls.Add(this.addMembersButton);
			this.buttonsBox.Location = new System.Drawing.Point(442, 87);
			this.buttonsBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.buttonsBox.Name = "buttonsBox";
			this.buttonsBox.Size = new System.Drawing.Size(213, 259);
			this.buttonsBox.TabIndex = 19;
			// 
			// backBut
			// 
			this.backBut.ImageIndex = 2;
			this.backBut.ImageList = this.imageList1;
			this.backBut.Location = new System.Drawing.Point(15, 213);
			this.backBut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.backBut.Name = "backBut";
			this.backBut.Size = new System.Drawing.Size(182, 41);
			this.backBut.TabIndex = 18;
			this.backBut.Text = "     Back    ";
			this.backBut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.backBut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.backBut.UseVisualStyleBackColor = true;
			this.backBut.Click += new System.EventHandler(this.backBut_Click);
			// 
			// leaveTeamBut
			// 
			this.leaveTeamBut.ImageIndex = 7;
			this.leaveTeamBut.ImageList = this.imageList1;
			this.leaveTeamBut.Location = new System.Drawing.Point(15, 162);
			this.leaveTeamBut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.leaveTeamBut.Name = "leaveTeamBut";
			this.leaveTeamBut.Size = new System.Drawing.Size(182, 41);
			this.leaveTeamBut.TabIndex = 17;
			this.leaveTeamBut.Text = "     Leave Team";
			this.leaveTeamBut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.leaveTeamBut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.leaveTeamBut.UseVisualStyleBackColor = true;
			this.leaveTeamBut.Click += new System.EventHandler(this.leaveTeamBut_Click);
			// 
			// teamScheduleBut
			// 
			this.teamScheduleBut.ImageIndex = 9;
			this.teamScheduleBut.ImageList = this.imageList1;
			this.teamScheduleBut.Location = new System.Drawing.Point(15, 111);
			this.teamScheduleBut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.teamScheduleBut.Name = "teamScheduleBut";
			this.teamScheduleBut.Size = new System.Drawing.Size(182, 41);
			this.teamScheduleBut.TabIndex = 16;
			this.teamScheduleBut.Text = "Team Schedule";
			this.teamScheduleBut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.teamScheduleBut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.teamScheduleBut.UseVisualStyleBackColor = true;
			this.teamScheduleBut.Click += new System.EventHandler(this.teamScheduleBut_Click);
			// 
			// scheduleEventBut
			// 
			this.scheduleEventBut.ImageIndex = 9;
			this.scheduleEventBut.ImageList = this.imageList1;
			this.scheduleEventBut.Location = new System.Drawing.Point(15, 60);
			this.scheduleEventBut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.scheduleEventBut.Name = "scheduleEventBut";
			this.scheduleEventBut.Size = new System.Drawing.Size(182, 41);
			this.scheduleEventBut.TabIndex = 15;
			this.scheduleEventBut.Text = "Schedule Event";
			this.scheduleEventBut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.scheduleEventBut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.scheduleEventBut.UseVisualStyleBackColor = true;
			this.scheduleEventBut.Click += new System.EventHandler(this.scheduleEventBut_Click);
			// 
			// addMembersButton
			// 
			this.addMembersButton.ImageIndex = 5;
			this.addMembersButton.ImageList = this.imageList1;
			this.addMembersButton.Location = new System.Drawing.Point(15, 10);
			this.addMembersButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.addMembersButton.Name = "addMembersButton";
			this.addMembersButton.Size = new System.Drawing.Size(182, 41);
			this.addMembersButton.TabIndex = 14;
			this.addMembersButton.Text = "  Add Member";
			this.addMembersButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.addMembersButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.addMembersButton.UseVisualStyleBackColor = true;
			this.addMembersButton.Click += new System.EventHandler(this.addMembersButton_Click);
			// 
			// TeamDetailsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(675, 362);
			this.Controls.Add(this.addMemberBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.memberState);
			this.Controls.Add(this.teamName);
			this.Controls.Add(this.buttonsBox);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "TeamDetailsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TeamDetailsForm";
			this.flowLayoutPanel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.addMemberBox.ResumeLayout(false);
			this.addMemberBox.PerformLayout();
			this.buttonsBox.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label teamName;
        private System.Windows.Forms.Label memberState;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button adminBut;
        private System.Windows.Forms.Button remBut;
        private System.Windows.Forms.Label adminLabel;
        private System.Windows.Forms.Button memberBut;
        private System.Windows.Forms.TextBox textField;
        private System.Windows.Forms.Button addBut;
        private System.Windows.Forms.Button backFromAddBut;
        private System.Windows.Forms.TextBox feedbackText;
        private System.Windows.Forms.Panel addMemberBox;
        private System.Windows.Forms.Panel buttonsBox;
        private System.Windows.Forms.Button backBut;
        private System.Windows.Forms.Button leaveTeamBut;
        private System.Windows.Forms.Button teamScheduleBut;
        private System.Windows.Forms.Button scheduleEventBut;
        private System.Windows.Forms.Button addMembersButton;
        private System.Windows.Forms.ImageList imageList1;
    }
}