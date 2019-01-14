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
            this.MonthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label3 = new System.Windows.Forms.Label();
            this.ToCurrency = new System.Windows.Forms.ListBox();
            this.FromCurrency = new System.Windows.Forms.ListBox();
            this.PredictButton = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RSquaredResult = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.ToDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ListMode = new System.Windows.Forms.ListBox();
            this.NewSampleDataButton = new System.Windows.Forms.Button();
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
            // MonthCalendar1
            // 
            this.MonthCalendar1.Location = new System.Drawing.Point(547, 88);
            this.MonthCalendar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MonthCalendar1.MaxSelectionCount = 1;
            this.MonthCalendar1.Name = "MonthCalendar1";
            this.MonthCalendar1.TabIndex = 5;
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
            // PredictButton
            // 
            this.PredictButton.Enabled = false;
            this.PredictButton.Location = new System.Drawing.Point(279, 315);
            this.PredictButton.Margin = new System.Windows.Forms.Padding(1);
            this.PredictButton.Name = "PredictButton";
            this.PredictButton.Size = new System.Drawing.Size(108, 40);
            this.PredictButton.TabIndex = 9;
            this.PredictButton.Text = "Predict!";
            this.PredictButton.UseVisualStyleBackColor = true;
            this.PredictButton.Click += new System.EventHandler(this.PredictButton_Click);
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result.Location = new System.Drawing.Point(496, 327);
            this.Result.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(17, 17);
            this.Result.TabIndex = 10;
            this.Result.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 384);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "R Squared";
            // 
            // RSquaredResult
            // 
            this.RSquaredResult.AutoSize = true;
            this.RSquaredResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RSquaredResult.Location = new System.Drawing.Point(496, 380);
            this.RSquaredResult.Name = "RSquaredResult";
            this.RSquaredResult.Size = new System.Drawing.Size(17, 17);
            this.RSquaredResult.TabIndex = 12;
            this.RSquaredResult.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(943, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Sample data";
            // 
            // FromDatePicker
            // 
            this.FromDatePicker.Location = new System.Drawing.Point(899, 88);
            this.FromDatePicker.Name = "FromDatePicker";
            this.FromDatePicker.Size = new System.Drawing.Size(200, 20);
            this.FromDatePicker.TabIndex = 14;
            this.FromDatePicker.Value = new System.DateTime(2016, 1, 15, 0, 0, 0, 0);
            // 
            // ToDatePicker
            // 
            this.ToDatePicker.Location = new System.Drawing.Point(899, 149);
            this.ToDatePicker.Name = "ToDatePicker";
            this.ToDatePicker.Size = new System.Drawing.Size(200, 20);
            this.ToDatePicker.TabIndex = 15;
            this.ToDatePicker.Value = new System.DateTime(2016, 12, 15, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(813, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "From date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(813, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "To date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(813, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Sample mode";
            // 
            // ListMode
            // 
            this.ListMode.FormattingEnabled = true;
            this.ListMode.Items.AddRange(new object[] {
            "Monthly",
            "Daily"});
            this.ListMode.Location = new System.Drawing.Point(899, 208);
            this.ListMode.Name = "ListMode";
            this.ListMode.Size = new System.Drawing.Size(200, 30);
            this.ListMode.TabIndex = 19;
            // 
            // NewSampleDataButton
            // 
            this.NewSampleDataButton.Location = new System.Drawing.Point(946, 278);
            this.NewSampleDataButton.Name = "NewSampleDataButton";
            this.NewSampleDataButton.Size = new System.Drawing.Size(109, 30);
            this.NewSampleDataButton.TabIndex = 20;
            this.NewSampleDataButton.Text = "New sample data";
            this.NewSampleDataButton.UseVisualStyleBackColor = true;
            this.NewSampleDataButton.Click += new System.EventHandler(this.NewSampleDataButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 506);
            this.Controls.Add(this.NewSampleDataButton);
            this.Controls.Add(this.ListMode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ToDatePicker);
            this.Controls.Add(this.FromDatePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RSquaredResult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.PredictButton);
            this.Controls.Add(this.FromCurrency);
            this.Controls.Add(this.ToCurrency);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MonthCalendar1);
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
		private System.Windows.Forms.MonthCalendar MonthCalendar1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox ToCurrency;
		private System.Windows.Forms.ListBox FromCurrency;
		private System.Windows.Forms.Button PredictButton;
		private System.Windows.Forms.Label Result;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label RSquaredResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker FromDatePicker;
        private System.Windows.Forms.DateTimePicker ToDatePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListBox ListMode;
        private System.Windows.Forms.Button NewSampleDataButton;
    }
}

