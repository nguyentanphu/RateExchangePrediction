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
using ExchangeRatePrediction.Application.OpenExchangeRate;

namespace RateExchangePrediction.Presentation
{
	public partial class Form1 : Form
	{
		private readonly IOpenExchangeClient _openExchangeClient;
		public Form1(IOpenExchangeClient openExchangeClient)
		{
			_openExchangeClient = openExchangeClient;

			InitializeComponent();
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			var fromCurrency = FromCurrency.SelectedItem as string;
			var toCurrency = ToCurrency.SelectedItem as string;

			var sampleArr = new List<Tuple<long, double>>()
			{
				new Tuple<long, double>(1514764800, 3.2345),
				new Tuple<long, double>(1517443200, 3.1345),
				new Tuple<long, double>(1519862400, 3.0563)
			};

			var n = sampleArr.Count;
			double sumX = 0;
			double sumY = 0;
			double sumXY = 0;
			double sumXSquare = 0;

			foreach (var sample in sampleArr)
			{
				sumX += sample.Item1;
				sumY += sample.Item2;
				sumXY += sample.Item1 * sample.Item2;
				sumXSquare += sample.Item1 * sample.Item1;
			}

			var slope = (n * sumXY - sumX * sumY) / (n * sumXSquare - sumX * sumX);
			var intercept = (sumY - slope * sumX) / n;

			Result.Text = (slope * 1546300800 + intercept).ToString(CultureInfo.CurrentCulture);

		    var result = await _openExchangeClient.GetExchangeRateHistoryPeriod(new DateTime(2017,1,1), new DateTime(2017,5,5));
		    MessageBox.Show(result.Count(x => true).ToString());
		}
	}
}
