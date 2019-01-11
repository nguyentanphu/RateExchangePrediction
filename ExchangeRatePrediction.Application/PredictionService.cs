using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRatePrediction.Application.Contract;
using ExchangeRatePrediction.Application.Data;
using ExchangeRatePrediction.Application.OpenExchangeRates;

namespace ExchangeRatePrediction.Application
{
	public class PredictionService : IPredictionService
	{
		private readonly IOpenExchangeClient _openExchangeClient;
		private readonly OpenExchangeCache _cache;
		public PredictionService(IOpenExchangeClient openExchangeClient, OpenExchangeCache cache)
		{
			_openExchangeClient = openExchangeClient;
			_cache = cache;
		}

		public async Task<IEnumerable<OpenExchangeRateResult>> FetchSampleData(DateTime fromDate, DateTime toDate, bool overrideCache = false)
		{
			if (!overrideCache && _cache.InmemoryData.Any()) return _cache.InmemoryData;

			var result = await _openExchangeClient.GetExchangeRateHistoryPeriod(fromDate, toDate, PeriodMode.ByMonth);

			_cache.InmemoryData.AddRange(result);

			return result;
		}

		public Task<IDictionary<string, string>> GetCurrencies()
		{
			return _openExchangeClient.GetExchangeRatesCurrencies();
		}

		public double MakePredictionFromSample(string fromCurrency, string toCurrency, DateTime targetDate, IEnumerable<OpenExchangeRateResult> sample)
		{

			var specificSample = sample.Select(s => new Tuple<long, double>(s.TimeStamp, s.Rates.FirstOrDefault(r => r.Key == toCurrency).Value))
				.ToList();

			var currencyHistory = new CurrencyHistory(fromCurrency, toCurrency, specificSample);

			return currencyHistory.MakePrediction(targetDate);
		}
	}
}
