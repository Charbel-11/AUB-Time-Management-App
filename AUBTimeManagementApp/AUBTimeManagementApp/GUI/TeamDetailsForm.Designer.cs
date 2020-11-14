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
            this.teamName = new System.Windows.Forms.Label();
            this.memberState = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.addMembersButton = new System.Windows.Forms.Button();
            this.scheduleEventBut = new System.Windows.Forms.Button();
            this.teamScheduleBut = new System.Windows.Forms.Button();
            this.leaveTeamBut = new System.Windows.Forms.Button();
            this.backBut = new System.Windows.Forms.Button();
            this.memberBut = new System.Windows.Forms.Button();
            this.adminLabel = new System.Windows.Forms.Label();
            this.remBut = new System.Windows.Forms.Button();
            this.adminBut = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // teamName
            // 
            this.teamName.AutoSize = true;
            this.teamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamName.Location = new System.Drawing.Point(276, 27);
            this.teamName.Name = "teamName";
            this.teamName.Size = new System.Drawing.Size(238, 46);
            this.teamName.TabIndex = 0;
            this.teamName.Text = "Team Name";
            // 
            // memberState
            // 
            this.memberState.AutoSize = true;
            this.memberState.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.memberState.Location = new System.Drawing.Point(761, 35);
            this.memberState.Name = "memberState";
            this.memberState.Size = new System.Drawing.Size(100, 36);
            this.memberState.TabIndex = 1;
            this.memberState.Text = "Admin";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(42, 163);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(571, 348);
            this.flowLayoutPanel1.TabIndex = 12;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(258, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 36);
            this.label1.TabIndex = 13;
            this.label1.Text = "Members";
            // 
            // addMembersButton
            // 
            this.addMembersButton.Location = new System.Drawing.Point(693, 129);
            this.addMembersButton.Name = "addMembersButton";
            this.addMembersButton.Size = new System.Drawing.Size(256, 53);
            this.addMembersButton.TabIndex = 14;
            this.addMembersButton.Text = "Add Members";
            this.addMembersButton.UseVisualStyleBackColor = true;
            this.addMembersButton.Click += new System.EventHandler(this.addMembersButton_Click);
            // 
            // scheduleEventBut
            // 
            this.scheduleEventBut.Location = new System.Drawing.Point(693, 215);
            this.scheduleEventBut.Name = "scheduleEventBut";
            this.scheduleEventBut.Size = new System.Drawing.Size(256, 53);
            this.scheduleEventBut.TabIndex = 15;
            this.scheduleEventBut.Text = "Schedule Event";
            this.scheduleEventBut.UseVisualStyleBackColor = true;
            this.scheduleEventBut.Click += new System.EventHandler(this.scheduleEventBut_Click);
            // 
            // teamScheduleBut
            // 
            this.teamScheduleBut.Location = new System.Drawing.Point(693, 303);
            this.teamScheduleBut.Name = "teamScheduleBut";
            this.teamScheduleBut.Size = new System.Drawing.Size(256, 53);
            this.teamScheduleBut.TabIndex = 16;
            this.teamScheduleBut.Text = "Team Schedule";
            this.teamScheduleBut.UseVisualStyleBackColor = true;
            this.teamScheduleBut.Click += new System.EventHandler(this.teamScheduleBut_Click);
            // 
            // leaveTeamBut
            // 
            this.leaveTeamBut.Location = new System.Drawing.Point(693, 389);
            this.leaveTeamBut.Name = "leaveTeamBut";
            this.leaveTeamBut.Size = new System.Drawing.Size(256, 53);
            this.leaveTeamBut.TabIndex = 17;
            this.leaveTeamBut.Text = "Leave Team";
            this.leaveTeamBut.UseVisualStyleBackColor = true;
            // 
            // backBut
            // 
            this.backBut.Location = new System.Drawing.Point(693, 473);
            this.backBut.Name = "backBut";
            this.backBut.Size = new System.Drawing.Size(256, 53);
            this.backBut.TabIndex = 18;
            this.backBut.Text = "Back";
            this.backBut.UseVisualStyleBackColor = true;
            // 
            // memberBut
            // 
            this.memberBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberBut.Location = new System.Drawing.Point(0, 0);
            this.memberBut.Name = "memberBut";
            this.memberBut.Size = new System.Drawing.Size(542, 53);
            this.memberBut.TabIndex = 1;
            this.memberBut.Text = "Member1";
            this.memberBut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.memberBut.UseVisualStyleBackColor = true;
            // 
            // adminLabel
            // 
            this.adminLabel.AutoSize = true;
            this.adminLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.adminLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.adminLabel.Location = new System.Drawing.Point(433, 18);
            this.adminLabel.Name = "adminLabel";
            this.adminLabel.Size = new System.Drawing.Size(54, 20);
            this.adminLabel.TabIndex = 2;
            this.adminLabel.Text = "Admin";
            // 
            // remBut
            // 
            this.remBut.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.remBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remBut.ForeColor = System.Drawing.Color.White;
            this.remBut.Location = new System.Drawing.Point(390, 6);
            this.remBut.Name = "remBut";
            this.remBut.Size = new System.Drawing.Size(131, 42);
            this.remBut.TabIndex = 4;
            this.remBut.Text = "Remove from Team";
            this.remBut.UseVisualStyleBackColor = false;
            // 
            // adminBut
            // 
            this.adminBut.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.adminBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminBut.ForeColor = System.Drawing.Color.White;
            this.adminBut.Location = new System.Drawing.Point(232, 6);
            this.adminBut.Name = "adminBut";
            this.adminBut.Size = new System.Drawing.Size(131, 42);
            this.adminBut.TabIndex = 3;
            this.adminBut.Text = "Dismiss as Admin";
            this.adminBut.UseVisualStyleBackColor = false;
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
            this.groupBox1.Size = new System.Drawing.Size(542, 55);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // TeamDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 557);
            this.Controls.Add(this.backBut);
            this.Controls.Add(this.leaveTeamBut);
            this.Controls.Add(this.teamScheduleBut);
            this.Controls.Add(this.scheduleEventBut);
            this.Controls.Add(this.addMembersButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.memberState);
            this.Controls.Add(this.teamName);
            this.Name = "TeamDetailsForm";
            this.Text = "TeamDetailsForm";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label teamName;
        private System.Windows.Forms.Label memberState;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addMembersButton;
        private System.Windows.Forms.Button scheduleEventBut;
        private System.Windows.Forms.Button teamScheduleBut;
        private System.Windows.Forms.Button leaveTeamBut;
        private System.Windows.Forms.Button backBut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button adminBut;
        private System.Windows.Forms.Button remBut;
        private System.Windows.Forms.Label adminLabel;
        private System.Windows.Forms.Button memberBut;
    }
}