namespace AUBTimeManagementApp.GUI
{
    partial class RegistrationForm
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
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmPasswordLabel = new System.Windows.Forms.Label();
            this.ConfirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.DateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.DateOfBirthLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(320, 84);
            this.UsernameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(220, 26);
            this.UsernameTextBox.TabIndex = 0;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(163, 90);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(83, 20);
            this.UsernameLabel.TabIndex = 1;
            this.UsernameLabel.Text = "Username";
            this.UsernameLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(163, 194);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(86, 20);
            this.lastNameLabel.TabIndex = 3;
            this.lastNameLabel.Text = "Last Name";
            this.lastNameLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Location = new System.Drawing.Point(320, 188);
            this.LastNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(220, 26);
            this.LastNameTextBox.TabIndex = 2;
            this.LastNameTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(163, 306);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(78, 20);
            this.PasswordLabel.TabIndex = 5;
            this.PasswordLabel.Text = "Password";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(320, 300);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(220, 26);
            this.PasswordTextBox.TabIndex = 4;
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(163, 141);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(86, 20);
            this.FirstNameLabel.TabIndex = 7;
            this.FirstNameLabel.Text = "First Name";
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(320, 135);
            this.FirstNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(220, 26);
            this.FirstNameTextBox.TabIndex = 1;
            // 
            // ConfirmPasswordLabel
            // 
            this.ConfirmPasswordLabel.AutoSize = true;
            this.ConfirmPasswordLabel.Location = new System.Drawing.Point(163, 360);
            this.ConfirmPasswordLabel.Name = "ConfirmPasswordLabel";
            this.ConfirmPasswordLabel.Size = new System.Drawing.Size(137, 20);
            this.ConfirmPasswordLabel.TabIndex = 9;
            this.ConfirmPasswordLabel.Text = "Confirm Password";
            // 
            // ConfirmPasswordTextBox
            // 
            this.ConfirmPasswordTextBox.Location = new System.Drawing.Point(320, 354);
            this.ConfirmPasswordTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConfirmPasswordTextBox.Name = "ConfirmPasswordTextBox";
            this.ConfirmPasswordTextBox.PasswordChar = '*';
            this.ConfirmPasswordTextBox.Size = new System.Drawing.Size(220, 26);
            this.ConfirmPasswordTextBox.TabIndex = 5;
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(163, 252);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(111, 20);
            this.EmailLabel.TabIndex = 11;
            this.EmailLabel.Text = "Email Address";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(320, 246);
            this.EmailTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(220, 26);
            this.EmailTextBox.TabIndex = 3;
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.Location = new System.Drawing.Point(320, 418);
            this.DateOfBirth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.Size = new System.Drawing.Size(224, 26);
            this.DateOfBirth.TabIndex = 6;
            // 
            // DateOfBirthLabel
            // 
            this.DateOfBirthLabel.AutoSize = true;
            this.DateOfBirthLabel.Location = new System.Drawing.Point(163, 424);
            this.DateOfBirthLabel.Name = "DateOfBirthLabel";
            this.DateOfBirthLabel.Size = new System.Drawing.Size(99, 20);
            this.DateOfBirthLabel.TabIndex = 14;
            this.DateOfBirthLabel.Text = "Date of Birth";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(709, 166);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 49);
            this.button1.TabIndex = 8;
            this.button1.Text = "Go Back";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(709, 252);
            this.RegisterButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(84, 49);
            this.RegisterButton.TabIndex = 7;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DateOfBirthLabel);
            this.Controls.Add(this.DateOfBirth);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.ConfirmPasswordLabel);
            this.Controls.Add(this.ConfirmPasswordTextBox);
            this.Controls.Add(this.FirstNameLabel);
            this.Controls.Add(this.FirstNameTextBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.LastNameTextBox);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.UsernameTextBox);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegistrationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.Label ConfirmPasswordLabel;
        private System.Windows.Forms.TextBox ConfirmPasswordTextBox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.DateTimePicker DateOfBirth;
        private System.Windows.Forms.Label DateOfBirthLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button RegisterButton;
    }
}