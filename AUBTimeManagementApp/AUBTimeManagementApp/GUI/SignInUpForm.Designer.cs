namespace AUBTimeManagementApp.GUI
{
    partial class SignInUpForm
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
            System.Windows.Forms.Label Title;
            this.SignUpButton = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.ErrorLabel = new System.Windows.Forms.Label();
            Title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.BackColor = System.Drawing.Color.Transparent;
            Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Title.ForeColor = System.Drawing.Color.Navy;
            Title.Location = new System.Drawing.Point(87, 18);
            Title.Name = "Title";
            Title.Size = new System.Drawing.Size(654, 44);
            Title.TabIndex = 0;
            Title.Text = "AUB Time Management Application";
            // 
            // SignUpButton
            // 
            this.SignUpButton.BackColor = System.Drawing.Color.SkyBlue;
            this.SignUpButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.SignUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.SignUpButton.ForeColor = System.Drawing.Color.Navy;
            this.SignUpButton.Location = new System.Drawing.Point(275, 361);
            this.SignUpButton.Name = "SignUpButton";
            this.SignUpButton.Size = new System.Drawing.Size(217, 51);
            this.SignUpButton.TabIndex = 1;
            this.SignUpButton.Text = "Sign Up";
            this.SignUpButton.UseVisualStyleBackColor = false;
            this.SignUpButton.Click += new System.EventHandler(this.SignUpButton_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.MistyRose;
            this.LoginButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.LoginButton.ForeColor = System.Drawing.Color.Navy;
            this.LoginButton.Location = new System.Drawing.Point(275, 277);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(217, 51);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.UsernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.UsernameTextBox.ForeColor = System.Drawing.Color.Navy;
            this.UsernameTextBox.Location = new System.Drawing.Point(275, 141);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(217, 28);
            this.UsernameTextBox.TabIndex = 3;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.PasswordTextBox.ForeColor = System.Drawing.Color.Navy;
            this.PasswordTextBox.Location = new System.Drawing.Point(275, 215);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(217, 28);
            this.PasswordTextBox.TabIndex = 4;
            this.PasswordTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.UsernameLabel.ForeColor = System.Drawing.Color.Navy;
            this.UsernameLabel.Location = new System.Drawing.Point(272, 108);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(97, 24);
            this.UsernameLabel.TabIndex = 5;
            this.UsernameLabel.Text = "Username";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.PasswordLabel.ForeColor = System.Drawing.Color.Navy;
            this.PasswordLabel.Location = new System.Drawing.Point(272, 184);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(92, 24);
            this.PasswordLabel.TabIndex = 6;
            this.PasswordLabel.Text = "Password";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Location = new System.Drawing.Point(535, 293);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(0, 17);
            this.ErrorLabel.TabIndex = 7;
            // 
            // SignInUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.SignUpButton);
            this.Controls.Add(Title);
            this.Name = "SignInUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.TransparencyKey = System.Drawing.Color.Red;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button SignUpButton;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label ErrorLabel;
    }
}