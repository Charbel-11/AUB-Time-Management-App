namespace AUBTimeManagementApp.GUI
{
    partial class InvitationsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.InvitationButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.DeclineButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(222, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pending Invitations";
            // 
            // InvitationButton
            // 
            this.InvitationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.InvitationButton.Location = new System.Drawing.Point(3, 3);
            this.InvitationButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InvitationButton.Name = "InvitationButton";
            this.InvitationButton.Size = new System.Drawing.Size(482, 44);
            this.InvitationButton.TabIndex = 1;
            this.InvitationButton.Text = "Invitation1";
            this.InvitationButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InvitationButton.UseVisualStyleBackColor = true;
            this.InvitationButton.Click += new System.EventHandler(this.InvitationButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(146, 86);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(487, 279);
            this.flowLayoutPanel1.TabIndex = 13;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DeclineButton);
            this.groupBox1.Controls.Add(this.AcceptButton);
            this.groupBox1.Controls.Add(this.InvitationButton);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(482, 44);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // AcceptButton
            // 
            this.AcceptButton.BackColor = System.Drawing.Color.LimeGreen;
            this.AcceptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AcceptButton.ForeColor = System.Drawing.Color.White;
            this.AcceptButton.Location = new System.Drawing.Point(206, 8);
            this.AcceptButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(116, 34);
            this.AcceptButton.TabIndex = 3;
            this.AcceptButton.Text = "Accept";
            this.AcceptButton.UseVisualStyleBackColor = false;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // DeclineButton
            // 
            this.DeclineButton.BackColor = System.Drawing.Color.LightCoral;
            this.DeclineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.DeclineButton.ForeColor = System.Drawing.Color.White;
            this.DeclineButton.Location = new System.Drawing.Point(360, 8);
            this.DeclineButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeclineButton.Name = "DeclineButton";
            this.DeclineButton.Size = new System.Drawing.Size(116, 34);
            this.DeclineButton.TabIndex = 4;
            this.DeclineButton.Text = "Decline";
            this.DeclineButton.UseVisualStyleBackColor = false;
            this.DeclineButton.Click += new System.EventHandler(this.DeclineButton_Click);
            // 
            // InvitationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Name = "InvitationsForm";
            this.Text = "Invitations";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button InvitationButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.Button DeclineButton;
    }
}