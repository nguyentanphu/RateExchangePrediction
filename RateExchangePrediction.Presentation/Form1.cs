using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExchangeRatePrediction.Application.Contract;

namespace RateExchangePrediction.Presentation
{
	public partial class Form1 : Form
	{
		private readonly IPredictionService _predictionService;
		public Form1(IPredictionService predictionService)
		{
			_predictionService = predictionService;

			InitializeComponent();
		}

		private async void button1_Click(object sender, EventArgs e)
		{
		    var fromCurrency = FromCurrency.SelectedValue as string;
		    var toCurrency = ToCurrency.SelectedValue as string;
			var selectedDate = monthCalendar1.SelectionStart;

			var sampleData =
				await _predictionService.FetchSampleData(new DateTime(2016, 1, 15), new DateTime(2018, 12, 15));

			var result =
				_predictionService.MakePredictionFromSample(fromCurrency, toCurrency, selectedDate, sampleData);

			MessageBox.Show(result.ToString());
		}

        private async void Form1_Load(object sender, EventArgs e)
        {
            var currencies = await _predictionService.GetCurrencies();

            var fromItems = currencies.Select(x => new ListBoxItem {Id = x.Key, Text = $"{x.Key} - {x.Value}"}).ToList();
            var toItems = fromItems.ToList();

            FromCurrency.ValueMember = "Id";
            FromCurrency.DisplayMember = "Text";
            FromCurrency.DataSource = fromItems;
            FromCurrency.SelectedItem = fromItems.FirstOrDefault(c => c.Id == "USD");

            ToCurrency.ValueMember = "Id";
            ToCurrency.DisplayMember = "Text";
            ToCurrency.DataSource = toItems;
            ToCurrency.SelectedItem = toItems.FirstOrDefault(c => c.Id == "VND");
        }
    }
}
