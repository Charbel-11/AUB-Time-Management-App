
namespace AUBTimeManagementApp.GUI
{
	partial class FilterUserScheduleForm
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
			this.filterPriority = new System.Windows.Forms.HScrollBar();
			this.PriorityEqualTo = new System.Windows.Forms.RadioButton();
			this.PriorityLessThan = new System.Windows.Forms.RadioButton();
			this.PriorityGreaterThan = new System.Windows.Forms.RadioButton();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.applyFilter = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// filterPriority
			// 
			this.filterPriority.LargeChange = 1;
			this.filterPriority.Location = new System.Drawing.Point(334, 140);
			this.filterPriority.Maximum = 3;
			this.filterPriority.Minimum = 1;
			this.filterPriority.Name = "filterPriority";
			this.filterPriority.Size = new System.Drawing.Size(153, 27);
			this.filterPriority.TabIndex = 2;
			this.filterPriority.Value = 1;
			this.filterPriority.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
			// 
			// PriorityEqualTo
			// 
			this.PriorityEqualTo.AutoSize = true;
			this.PriorityEqualTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PriorityEqualTo.Location = new System.Drawing.Point(43, 140);
			this.PriorityEqualTo.Name = "PriorityEqualTo";
			this.PriorityEqualTo.Size = new System.Drawing.Size(75, 20);
			this.PriorityEqualTo.TabIndex = 5;
			this.PriorityEqualTo.TabStop = true;
			this.PriorityEqualTo.Text = "Equal to";
			this.PriorityEqualTo.UseVisualStyleBackColor = true;
			this.PriorityEqualTo.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// PriorityLessThan
			// 
			this.PriorityLessThan.AutoSize = true;
			this.PriorityLessThan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PriorityLessThan.Location = new System.Drawing.Point(43, 104);
			this.PriorityLessThan.Name = "PriorityLessThan";
			this.PriorityLessThan.Size = new System.Drawing.Size(83, 20);
			this.PriorityLessThan.TabIndex = 7;
			this.PriorityLessThan.TabStop = true;
			this.PriorityLessThan.Text = "Less than";
			this.PriorityLessThan.UseVisualStyleBackColor = true;
			this.PriorityLessThan.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
			// 
			// PriorityGreaterThan
			// 
			this.PriorityGreaterThan.AutoSize = true;
			this.PriorityGreaterThan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PriorityGreaterThan.Location = new System.Drawing.Point(43, 179);
			this.PriorityGreaterThan.Name = "PriorityGreaterThan";
			this.PriorityGreaterThan.Size = new System.Drawing.Size(99, 20);
			this.PriorityGreaterThan.TabIndex = 8;
			this.PriorityGreaterThan.TabStop = true;
			this.PriorityGreaterThan.Text = "Greater than";
			this.PriorityGreaterThan.UseVisualStyleBackColor = true;
			this.PriorityGreaterThan.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.Control;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(166, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(195, 31);
			this.textBox1.TabIndex = 9;
			this.textBox1.Text = "Filter Schedule";
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// textBox2
			// 
			this.textBox2.BackColor = System.Drawing.SystemColors.Control;
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox2.Location = new System.Drawing.Point(21, 69);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(261, 19);
			this.textBox2.TabIndex = 10;
			this.textBox2.Text = "Display events with priority:";
			this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			// 
			// textBox3
			// 
			this.textBox3.BackColor = System.Drawing.SystemColors.Control;
			this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox3.Location = new System.Drawing.Point(216, 148);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(100, 19);
			this.textBox3.TabIndex = 11;
			this.textBox3.Text = "Pick Priority";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(43, 253);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(150, 39);
			this.button1.TabIndex = 12;
			this.button1.Text = "Back";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// applyFilter
			// 
			this.applyFilter.Location = new System.Drawing.Point(273, 254);
			this.applyFilter.Name = "applyFilter";
			this.applyFilter.Size = new System.Drawing.Size(155, 38);
			this.applyFilter.TabIndex = 13;
			this.applyFilter.Text = "Done";
			this.applyFilter.UseVisualStyleBackColor = true;
			this.applyFilter.Click += new System.EventHandler(this.applyFilter_Click);
			// 
			// FilterUserScheduleForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(514, 313);
			this.Controls.Add(this.applyFilter);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.PriorityGreaterThan);
			this.Controls.Add(this.PriorityLessThan);
			this.Controls.Add(this.PriorityEqualTo);
			this.Controls.Add(this.filterPriority);
			this.Name = "FilterUserScheduleForm";
			this.Text = "FilterUserSchedule";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.HScrollBar filterPriority;
		private System.Windows.Forms.RadioButton PriorityEqualTo;
		private System.Windows.Forms.RadioButton PriorityLessThan;
		private System.Windows.Forms.RadioButton PriorityGreaterThan;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button applyFilter;
	}
}