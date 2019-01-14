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
using ExchangeRatePrediction.Application.OpenExchangeRates;

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

		private async void PredictButton_Click(object sender, EventArgs e)
		{
			try
			{
				await PredictHandler();
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
				    PredictButton_Click(sender, e);
			}

		}

		private async Task PredictHandler()
		{
			PredictButton.Enabled = false;

			var fromCurrency = FromCurrency.SelectedValue as string;
			var toCurrency = ToCurrency.SelectedValue as string;
			var selectedDate = DateTime.SpecifyKind(MonthCalendar1.SelectionStart, DateTimeKind.Utc);

			var sampleData =
				await _predictionService.FetchSampleData(new DateTime(2016, 1, 15), new DateTime(2016, 12, 15));

			var result =
				_predictionService.MakePredictionFromSample(fromCurrency, toCurrency, selectedDate, sampleData);
			Result.Text = result.PredictionRate.ToString(CultureInfo.InvariantCulture);
		    RSquaredResult.Text = result.RSquared.ToString(CultureInfo.InvariantCulture);

            PredictButton.Enabled = true;
		}

		private async void Form1_Load(object sender, EventArgs e)
		{

			try
			{
				await LoadCurrencies();
			}
			catch (HttpRequestException)
			{
				var dialogResult = MessageBox.Show("Can't connect to external api resources. Please try again later", "Exception", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

				if (dialogResult == DialogResult.Abort)
					Application.Exit();

				else if (dialogResult == DialogResult.Retry)
					Form1_Load(sender, e);
			}
		}

		private async Task LoadCurrencies()
		{
			var currencies = await _predictionService.GetCurrencies();
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

		    ListMode.SelectedItem = "Monthly";
			PredictButton.Enabled = true;
		}

        private async void NewSampleDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (FromDatePicker.Value >= ToDatePicker.Value)
                {
                    MessageBox.Show("From date can't be greater or equal to To date", "Wrong options!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                NewSampleDataButton.Enabled = false;

                await FetchSampleHandler();

                MessageBox.Show("Sample has been updated successfully.", "Updated", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (HttpRequestException)
            {
                var dialogResult =
                    MessageBox.Show("Can't fetch external api resources for sample data. Please try again later",
                        "Exception", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

                if (dialogResult == DialogResult.Abort)
                    Application.Exit();

                else if (dialogResult == DialogResult.Retry)
                    PredictButton_Click(sender, e);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Wrong options!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (NotEnoughSampleException ex)
            {
                MessageBox.Show(ex.Message, "Wrong options!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                NewSampleDataButton.Enabled = true;
            }
        }

	    private async Task FetchSampleHandler()
	    {
	        var selectedFromDate = FromDatePicker.Value;
	        var selectedToDate = ToDatePicker.Value;
	        var mode = (PeriodMode)Enum.Parse(typeof(PeriodMode), ListMode.SelectedItem as string);
	        await _predictionService.FetchSampleData(selectedFromDate, selectedToDate, mode, true);
        }
    }
}
