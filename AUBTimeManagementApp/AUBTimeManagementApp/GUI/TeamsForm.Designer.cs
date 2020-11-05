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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.TeamsLayout.SuspendLayout();
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
            this.TeamsLayout.Controls.Add(this.button1);
            this.TeamsLayout.Controls.Add(this.button2);
            this.TeamsLayout.Controls.Add(this.button3);
            this.TeamsLayout.Controls.Add(this.button4);
            this.TeamsLayout.Controls.Add(this.button5);
            this.TeamsLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.TeamsLayout.Location = new System.Drawing.Point(12, 28);
            this.TeamsLayout.Name = "TeamsLayout";
            this.TeamsLayout.Size = new System.Drawing.Size(776, 371);
            this.TeamsLayout.TabIndex = 1;
            this.TeamsLayout.WrapContents = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(727, 71);
            this.button1.TabIndex = 2;
            this.button1.Text = "Team 1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 71);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(727, 71);
            this.button2.TabIndex = 3;
            this.button2.Text = "Team 1";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 142);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(727, 71);
            this.button3.TabIndex = 4;
            this.button3.Text = "Team 1";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(0, 213);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(727, 71);
            this.button4.TabIndex = 5;
            this.button4.Text = "Team 1";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(0, 284);
            this.button5.Margin = new System.Windows.Forms.Padding(0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(727, 71);
            this.button5.TabIndex = 6;
            this.button5.Text = "Team 1";
            this.button5.UseVisualStyleBackColor = true;
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
            this.Text = "Teams";
            this.TeamsLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addTeamButton;
        private System.Windows.Forms.FlowLayoutPanel TeamsLayout;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button backButton;
    }
}