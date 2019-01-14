namespace RateExchangePrediction.Presentation
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
            this.button1 = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RSquaredResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(588, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select date (including future)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To currency";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(547, 88);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "From currency";
            // 
            // ToCurrency
            // 
            this.ToCurrency.FormattingEnabled = true;
            this.ToCurrency.Location = new System.Drawing.Point(330, 88);
            this.ToCurrency.Margin = new System.Windows.Forms.Padding(1);
            this.ToCurrency.Name = "ToCurrency";
            this.ToCurrency.Size = new System.Drawing.Size(140, 134);
            this.ToCurrency.TabIndex = 7;
            // 
            // FromCurrency
            // 
            this.FromCurrency.FormattingEnabled = true;
            this.FromCurrency.Location = new System.Drawing.Point(93, 88);
            this.FromCurrency.Margin = new System.Windows.Forms.Padding(1);
            this.FromCurrency.Name = "FromCurrency";
            this.FromCurrency.Size = new System.Drawing.Size(140, 134);
            this.FromCurrency.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(125, 309);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 40);
            this.button1.TabIndex = 9;
            this.button1.Text = "Predict!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result.Location = new System.Drawing.Point(342, 321);
            this.Result.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(17, 17);
            this.Result.TabIndex = 10;
            this.Result.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "R Squared";
            // 
            // RSquaredResult
            // 
            this.RSquaredResult.AutoSize = true;
            this.RSquaredResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RSquaredResult.Location = new System.Drawing.Point(342, 374);
            this.RSquaredResult.Name = "RSquaredResult";
            this.RSquaredResult.Size = new System.Drawing.Size(17, 17);
            this.RSquaredResult.TabIndex = 12;
            this.RSquaredResult.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 478);
            this.Controls.Add(this.RSquaredResult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FromCurrency);
            this.Controls.Add(this.ToCurrency);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Form1";
            this.Text = "Rate exchange prediction";
            this.Load += new System.EventHandler(this.Form1_Load);
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
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label Result;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label RSquaredResult;
    }
}

