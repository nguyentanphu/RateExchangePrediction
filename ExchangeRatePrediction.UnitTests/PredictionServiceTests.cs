using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;
using ExchangeRatePrediction.Application;
using ExchangeRatePrediction.Application.Contract;
using ExchangeRatePrediction.Application.Exceptions;
using ExchangeRatePrediction.Application.OpenExchangeRates;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace ExchangeRatePrediction.UnitTests
{
	[UseReporter(typeof(DiffReporter))]
	public class PredictionServiceTests
	{
		private readonly Mock<IOpenExchangeClient> _openExchangeClient;
		private readonly Mock<IOpenExchangeCache> _cache;
		public PredictionServiceTests()
		{
			_openExchangeClient = new Mock<IOpenExchangeClient>();
			_cache = new Mock<IOpenExchangeCache>();
		}

		[Fact]
		public async Task FetchSampleData_FirstFetchWithDefaultOption_ReturnApiData()
		{
			_cache.Setup(cache => cache.InMemoryData).Returns(new List<OpenExchangeRateResult>());

			IEnumerable<OpenExchangeRateResult> clientResult = new List<OpenExchangeRateResult>
			{
				new OpenExchangeRateResult
				{
					Base = "USD",
					TimeStamp = 34343423,
					Rates = new Dictionary<string, double>
					{
						{ "VND", 23455 },
						{ "CYN", 6435 }
					}
				}
			};
			_openExchangeClient
				.Setup(client =>
					client.GetExchangeRateHistoryPeriod(It.IsAny<DateTime>(), It.IsAny<DateTime>(),
						It.IsAny<PeriodMode>())).Returns(Task.FromResult(clientResult));

			var predictionService = new PredictionService(_openExchangeClient.Object, _cache.Object);

			var result = await predictionService.FetchSampleData(new DateTime(2016, 1, 1), new DateTime(2016, 12, 1));

			Approvals.VerifyJson(JsonConvert.SerializeObject(_cache.Object.InMemoryData));
			Approvals.VerifyJson(JsonConvert.SerializeObject(result));

		}

		[Fact]
		public async Task FetchSampleData_FetchWithCacheData_ReturnCache()
		{
			_cache.Setup(cache => cache.InMemoryData).Returns(new List<OpenExchangeRateResult>
			{
				new OpenExchangeRateResult
				{
					Base = "USD",
					TimeStamp = 34343423,
					Rates = new Dictionary<string, double>
					{
						{ "VND", 23455 },
						{ "CYN", 6435 }
					}
				}
			});

			var predictionService = new PredictionService(_openExchangeClient.Object, _cache.Object);

			var result = await predictionService.FetchSampleData(new DateTime(2016, 1, 1), new DateTime(2016, 12, 1));

			_openExchangeClient.Verify(client => client.GetExchangeRateHistoryPeriod(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<PeriodMode>()), Times.Never);
			_cache.Verify(cache => cache.InMemoryData, Times.Exactly(2));
			Approvals.VerifyJson(JsonConvert.SerializeObject(result));

		}

		[Fact]
		public async Task FetchSampleData_FetchWithOverrideCache_ReturnApiData()
		{
			_cache.Setup(cache => cache.InMemoryData).Returns(new List<OpenExchangeRateResult>
			{
				new OpenExchangeRateResult
				{
					Base = "USD",
					TimeStamp = 34343423,
					Rates = new Dictionary<string, double>
					{
						{ "VND", 23455 },
						{ "CYN", 6435 }
					}
				}
			});

			IEnumerable<OpenExchangeRateResult> clientResult = new List<OpenExchangeRateResult>
			{

				new OpenExchangeRateResult
				{
					Base = "CNY",
					TimeStamp = 3523232,
					Rates = new Dictionary<string, double>
					{
						{ "VND", 23455 },
						{ "CYN", 6435 },
						{ "BTN", 46.693954 },
						{ "COP", 2236.382675 }
					}
				}
			};
			_openExchangeClient
				.Setup(client =>
					client.GetExchangeRateHistoryPeriod(It.IsAny<DateTime>(), It.IsAny<DateTime>(),
						It.IsAny<PeriodMode>())).Returns(Task.FromResult(clientResult));

			var predictionService = new PredictionService(_openExchangeClient.Object, _cache.Object);

			var result = await predictionService.FetchSampleData(new DateTime(2016, 1, 1), new DateTime(2016, 12, 1), overrideCache: true);

			Approvals.VerifyJson(JsonConvert.SerializeObject(result));
		}

		[Fact]
		public void MakePredictionFromSample_NullArgument_ThrowArgumentException()
		{
			var predictionService = new PredictionService(_openExchangeClient.Object, _cache.Object);

			Assert.Throws<ArgumentException>(() =>
				predictionService.MakePredictionFromSample("USD", "VND", DateTime.Today, null));
		}

		[Fact]
		public void MakePredictionFromSample_DoesNotHaveFromCurrencyInSample_ThrowCurrencyNotFoundException()
		{
			var predictionService = new PredictionService(_openExchangeClient.Object, _cache.Object);

			Assert.Throws<CurrencyNotFoundException>(() =>
				predictionService.MakePredictionFromSample("CNY", "VND", new DateTime(2019, 12, 31),
					new List<OpenExchangeRateResult>
					{
						new OpenExchangeRateResult
						{
							Base = "USD",
							Rates = new Dictionary<string, double>(),
							TimeStamp = 123234
						}
					}));
		}

		[Fact]
		public void MakePredictionFromSample_DoesNotHaveToCurrencyInSample_ThrowCurrencyNotFoundException()
		{
			var predictionService = new PredictionService(_openExchangeClient.Object, _cache.Object);

			Assert.Throws<CurrencyNotFoundException>(() =>
				predictionService.MakePredictionFromSample("USD", "VND", new DateTime(2019, 12, 31),
					new List<OpenExchangeRateResult>
					{
						new OpenExchangeRateResult
						{
							Base = "USD",
							Rates = new Dictionary<string, double>(),
							TimeStamp = 123234
						}
					}));
		}

		[Fact]
		public void MakePredictionFromSample_HaveCorrectUSDBaseSample_ReturnCorrectResultFromDirectRates()
		{
			var predictionService = new PredictionService(_openExchangeClient.Object, _cache.Object);

			var result = predictionService.MakePredictionFromSample("USD", "VND",
				DateTimeOffset.FromUnixTimeSeconds(40).UtcDateTime,
				new List<OpenExchangeRateResult>
				{
					new OpenExchangeRateResult
					{
						Base = "USD",
						Rates = new Dictionary<string, double>()
						{
							{"VND", 23050}
						},
						TimeStamp = 10
					},
					new OpenExchangeRateResult
					{
						Base = "USD",
						Rates = new Dictionary<string, double>()
						{
							{"VND", 23100}
						},
						TimeStamp = 20
					},
					new OpenExchangeRateResult
					{
						Base = "USD",
						Rates = new Dictionary<string, double>()
						{
							{"VND", 23150}
						},
						TimeStamp = 30
					}
				});

			Assert.Equal(23200, result);
		}

		[Fact]
		public void MakePredictionFromSample_HaveCorrectNoneUSDSample_ReturnCorrectResultFromConvertedRates()
		{
			var predictionService = new PredictionService(_openExchangeClient.Object, _cache.Object);

			var result = predictionService.MakePredictionFromSample("CNY", "VND",
				DateTimeOffset.FromUnixTimeSeconds(40).UtcDateTime,
				new List<OpenExchangeRateResult>
				{
					new OpenExchangeRateResult
					{
						Base = "USD",
						Rates = new Dictionary<string, double>()
						{
							{"VND", 23050},
							{"CNY", 6.5434 }
						},
						TimeStamp = 10
					},
					new OpenExchangeRateResult
					{
						Base = "USD",
						Rates = new Dictionary<string, double>()
						{
							{"VND", 23100},
							{"CNY", 6.6434 }
						},
						TimeStamp = 20
					},
					new OpenExchangeRateResult
					{
						Base = "USD",
						Rates = new Dictionary<string, double>()
						{
							{"VND", 23150},
							{"CNY", 6.7434 }
						},
						TimeStamp = 30
					}
				});

			Assert.Equal(3387.9378, result);
		}
	}
}
