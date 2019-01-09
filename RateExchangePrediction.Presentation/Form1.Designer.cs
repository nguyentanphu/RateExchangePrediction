﻿namespace RateExchangePrediction.Presentation
{
	partial class Form1
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
			this.label2 = new System.Windows.Forms.Label();
			this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
			this.label3 = new System.Windows.Forms.Label();
			this.ToCurrency = new System.Windows.Forms.ListBox();
			this.FromCurrency = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(63, 121);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(378, 32);
			this.label1.TabIndex = 1;
			this.label1.Text = "Select date (including future)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(69, 347);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(163, 32);
			this.label2.TabIndex = 3;
			this.label2.Text = "To currency";
			// 
			// monthCalendar1
			// 
			this.monthCalendar1.Location = new System.Drawing.Point(570, 121);
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(69, 209);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(195, 32);
			this.label3.TabIndex = 6;
			this.label3.Text = "From currency";
			// 
			// ToCurrency
			// 
			this.ToCurrency.FormattingEnabled = true;
			this.ToCurrency.ItemHeight = 31;
			this.ToCurrency.Location = new System.Drawing.Point(283, 347);
			this.ToCurrency.Name = "ToCurrency";
			this.ToCurrency.Size = new System.Drawing.Size(194, 66);
			this.ToCurrency.TabIndex = 7;
			// 
			// FromCurrency
			// 
			this.FromCurrency.FormattingEnabled = true;
			this.FromCurrency.ItemHeight = 31;
			this.FromCurrency.Location = new System.Drawing.Point(283, 209);
			this.FromCurrency.Name = "FromCurrency";
			this.FromCurrency.Size = new System.Drawing.Size(194, 66);
			this.FromCurrency.TabIndex = 8;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1234, 794);
			this.Controls.Add(this.FromCurrency);
			this.Controls.Add(this.ToCurrency);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.monthCalendar1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Rate exchange prediction";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.MonthCalendar monthCalendar1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox ToCurrency;
		private System.Windows.Forms.ListBox FromCurrency;
	}
}

