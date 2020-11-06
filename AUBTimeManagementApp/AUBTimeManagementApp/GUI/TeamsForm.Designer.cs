namespace AUBTimeManagementApp.GUI {
    partial class TeamsForm {
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
            this.addTeamButton = new System.Windows.Forms.Button();
            this.TeamsLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addTeamButton
            // 
            this.addTeamButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTeamButton.ForeColor = System.Drawing.Color.Green;
            this.addTeamButton.Location = new System.Drawing.Point(656, 369);
            this.addTeamButton.Name = "addTeamButton";
            this.addTeamButton.Size = new System.Drawing.Size(132, 69);
            this.addTeamButton.TabIndex = 0;
            this.addTeamButton.Text = "New Team";
            this.addTeamButton.UseVisualStyleBackColor = true;
            this.addTeamButton.Click += new System.EventHandler(this.addTeamButton_Click);
            // 
            // TeamsLayout
            // 
            this.TeamsLayout.AutoScroll = true;
            this.TeamsLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.TeamsLayout.Location = new System.Drawing.Point(12, 28);
            this.TeamsLayout.Name = "TeamsLayout";
            this.TeamsLayout.Size = new System.Drawing.Size(776, 371);
            this.TeamsLayout.TabIndex = 1;
            this.TeamsLayout.WrapContents = false;
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.Red;
            this.backButton.Location = new System.Drawing.Point(12, 369);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(132, 69);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // TeamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.TeamsLayout);
            this.Controls.Add(this.addTeamButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TeamsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teams";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addTeamButton;
        private System.Windows.Forms.FlowLayoutPanel TeamsLayout;
        private System.Windows.Forms.Button backButton;
    }
}