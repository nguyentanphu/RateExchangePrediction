using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRatePrediction.Application.Contract;
using ExchangeRatePrediction.Application.Data;
using ExchangeRatePrediction.Application.Exceptions;
using ExchangeRatePrediction.Application.OpenExchangeRates;

namespace ExchangeRatePrediction.Application
{
	public class PredictionService : IPredictionService
	{
		private readonly IOpenExchangeClient _openExchangeClient;
		private readonly IOpenExchangeCache _cache;
		public PredictionService(IOpenExchangeClient openExchangeClient, IOpenExchangeCache cache)
		{
			_openExchangeClient = openExchangeClient;
			_cache = cache;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="mode"></param>
        /// <param name="overrideCache"></param>
        /// <returns></returns>
        /// <exception cref="NotEnoughSampleException">Throw if sample return is less than 2 items.</exception>
		public async Task<IEnumerable<OpenExchangeRateResult>> FetchSampleData(DateTime fromDate, DateTime toDate, PeriodMode mode = PeriodMode.Monthly, bool overrideCache = false)
		{
			if (!overrideCache && _cache.InMemoryData.Any()) return _cache.InMemoryData;

			var result = await _openExchangeClient.GetExchangeRateHistoryPeriod(fromDate, toDate, mode);

            if (result.Count() < 2) 
                throw new NotEnoughSampleException();

			_cache.InMemoryData.AddRange(result);

			return result;
		}

		public Task<IDictionary<string, string>> GetCurrencies()
		{
			return _openExchangeClient.GetExchangeRatesCurrencies();
		}

        /// <exception cref="CurrencyNotFoundException">Throw if target currencies are not found from sample list.</exception>
        /// <exception cref="ArgumentException">Throw if sample is null or has less than 2 items</exception>
        /// <returns></returns>
        public PredictionResult MakePredictionFromSample(string fromCurrency, string toCurrency, DateTime targetDate, IEnumerable<OpenExchangeRateResult> sample)
		{
			if (sample == null)
				throw new ArgumentException("Sample cannot be null", nameof(sample));

			var specificSample = sample.Select(s => MakeSamplePoint(s, fromCurrency, toCurrency))
				.ToList();

			var ratesHistory = new ExchangeRatesHistory(specificSample);

		    return new PredictionResult
		    {
		        PredictionRate = ratesHistory.MakePrediction(targetDate),
		        RSquared = ratesHistory.GetRSquared()
		    };
		}

		private Tuple<long, double> MakeSamplePoint(OpenExchangeRateResult samplePoint, string fromCurrency, string toCurrency)
		{
			double fromCurrencyValue;
			double toCurrencyValue;
			try
			{
				fromCurrencyValue = fromCurrency == "USD" ? 1 : samplePoint.Rates.First(r => r.Key == fromCurrency).Value;
				toCurrencyValue = samplePoint.Rates.First(r => r.Key == toCurrency).Value;
			}
			catch (InvalidOperationException ex)
			{
				throw new CurrencyNotFoundException(ex);
			}


			return new Tuple<long, double>(samplePoint.TimeStamp, toCurrencyValue / fromCurrencyValue);
		}
	}
}
