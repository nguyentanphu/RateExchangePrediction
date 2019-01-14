using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRatePrediction.Application.Data;
using Xunit;

namespace ExchangeRatePrediction.UnitTests
{
	public class CurrencyHistoryTests
	{
		[Fact]
		public void MakePrediction_With0Sample_ReturnDefault()
		{
			var currencyHistory = new ExchangeRatesHistory(new List<Tuple<long, double>>());
			var result = currencyHistory.MakePrediction(new DateTime(2000, 1, 1));

			Assert.Equal(default(double), result);
		}

		[Fact]
		public void MakePrediction_WithSimpleSample_ReturnCorrectResult()
		{
			var currencyHistory = new ExchangeRatesHistory(new List<Tuple<long, double>>
				{
					new Tuple<long, double>(1, 10),
					new Tuple<long, double>(2, 15),
					new Tuple<long, double>(3, 20),
					new Tuple<long, double>(4, 25)
				});
			var unixTimeStamp = DateTimeOffset.FromUnixTimeSeconds(5).UtcDateTime;
			var result = currencyHistory.MakePrediction(unixTimeStamp);

			Assert.Equal(30, result);
		}

		private long CreateUnixTimeStamp(int year, int month, int day)
		{
			var utcDate = DateTime.SpecifyKind(new DateTime(year, month, day), DateTimeKind.Utc);
			return ((DateTimeOffset)utcDate).ToUnixTimeSeconds();
		}

		[Fact]
		public void MakePrediction_WithTimeStampSample_ReturnCorrectResult()
		{
			var currencyHistory = new ExchangeRatesHistory(new List<Tuple<long, double>>
				{
					new Tuple<long, double>(CreateUnixTimeStamp(2018, 8, 15), 23114.292672),
					new Tuple<long, double>(CreateUnixTimeStamp(2018, 9, 15), 23096.240172),
					new Tuple<long, double>(CreateUnixTimeStamp(2018, 10, 15), 23245.690172),
					new Tuple<long, double>(CreateUnixTimeStamp(2018, 11, 15), 23234.180172),
					new Tuple<long, double>(CreateUnixTimeStamp(2018, 12, 15), 23236.342257)
				});
			var result = currencyHistory.MakePrediction(new DateTime(2019, 2, 15));

			Assert.Equal(23338.5313, result);
		}

	}
}
