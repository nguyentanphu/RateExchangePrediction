using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRatePrediction.Application.OpenExchangeRates;

namespace ExchangeRatePrediction.Application.Contract
{
	public interface IPredictionService
	{
		Task<IEnumerable<OpenExchangeRateResult>> FetchSampleData(DateTime fromDate, DateTime toDate,
			bool overrideCache = false);

		/// <exception cref="CurrencyNotFoundException">Target currencies are not found from sample list.</exception>
		/// <returns></returns>
		double MakePredictionFromSample(string fromCurrency, string toCurrency, DateTime targetDate,
			IEnumerable<OpenExchangeRateResult> sample);

		Task<IDictionary<string,string>> GetCurrencies();
	}
}
