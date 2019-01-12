using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExchangeRatePrediction.Application.Contract;
using ExchangeRatePrediction.Application.Exceptions;

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

			try
			{
				var sampleData =
					await _predictionService.FetchSampleData(new DateTime(2001, 1, 15), new DateTime(2001, 12, 15));

				var result =
					_predictionService.MakePredictionFromSample(fromCurrency, toCurrency, selectedDate, sampleData);
				Result.Text = result.ToString(CultureInfo.InvariantCulture);
			}
			catch (CurrencyNotFoundException exception)
			{
				MessageBox.Show(exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			catch (HttpRequestException)
			{
				var dialogResult = MessageBox.Show("Can't fetch external api resources for sample data. Please try again later", "Exception", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

				if (dialogResult == DialogResult.Abort)
					Application.Exit();

				else if (dialogResult == DialogResult.Retry)
					button1_Click(sender, e);
			}

		}

		private async void Form1_Load(object sender, EventArgs e)
		{
			IDictionary<string, string> currencies = new ConcurrentDictionary<string, string>();

			try
			{
				currencies = await _predictionService.GetCurrencies();
			}
			catch (HttpRequestException)
			{
				var dialogResult = MessageBox.Show("Can't connect to external api resources. Please try again later", "Exception", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

				if (dialogResult == DialogResult.Abort)
					Application.Exit();

				else if (dialogResult == DialogResult.Retry)
					Form1_Load(sender, e);

				return;
			}

			var fromItems = currencies.Select(x => new ListBoxItem { Id = x.Key, Text = $"{x.Key} - {x.Value}" }).ToList();
			var toItems = fromItems.ToList();

			FromCurrency.ValueMember = "Id";
			FromCurrency.DisplayMember = "Text";
			FromCurrency.DataSource = fromItems;
			FromCurrency.SelectedItem = fromItems.FirstOrDefault(c => c.Id == "USD");

			ToCurrency.ValueMember = "Id";
			ToCurrency.DisplayMember = "Text";
			ToCurrency.DataSource = toItems;
			ToCurrency.SelectedItem = toItems.FirstOrDefault(c => c.Id == "VND");

			button1.Enabled = true;
		}
	}
}
