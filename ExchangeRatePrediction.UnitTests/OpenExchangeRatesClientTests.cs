using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExchangeRatePrediction.Application.OpenExchangeRates;
using Moq;
using Xunit;

namespace ExchangeRatePrediction.UnitTests
{
	public class OpenExchangeRatesClientTests
	{
		private readonly Mock<OpenExchangeRatesClient> _client;
		public OpenExchangeRatesClientTests()
		{
			_client = new Mock<OpenExchangeRatesClient>(MockBehavior.Strict, new HttpClient(), new SemaphoreSlim(100));

			_client.Setup(c => c.GetExchangeRateHistory(It.IsAny<DateTime>())).Returns(Task.FromResult(
				new OpenExchangeRateResult
				{
					Base = "USD",
					TimeStamp = 2434343,
					Rates = new Dictionary<string, double>
					{
						{"VND", 343524},
						{"CNY", 434334}
					}
				}));
		}

		[Fact]
		public void GetExchangeRateHistoryPeriod_FromDateGreaterThanToDate_ThrowArgumentException()
		{
			Assert.ThrowsAsync<ArgumentException>(() =>
				_client.Object.GetExchangeRateHistoryPeriod(new DateTime(2016, 1, 1), new DateTime(2015, 1, 1)));
		}

		[Fact]
		public async Task GetExchangeRateHistoryPeriod_MonthModeWith12Months_ReturnListOf12ElementsApiObjects()
		{
			var result =
				await _client.Object.GetExchangeRateHistoryPeriod(new DateTime(2016, 1, 15),
					new DateTime(2016, 12, 15));

			Assert.Equal(12, result.Count());
		}

		[Fact]
		public async Task GetExchangeRateHistoryPeriod_DateModeWith30Days_ReturnListOf30ElementsApiObjects()
		{
			var result =
				await _client.Object.GetExchangeRateHistoryPeriod(new DateTime(2013, 1, 1),
					new DateTime(2013, 1, 30), PeriodMode.Daily);

			Assert.Equal(30, result.Count());
		}
	}
}
