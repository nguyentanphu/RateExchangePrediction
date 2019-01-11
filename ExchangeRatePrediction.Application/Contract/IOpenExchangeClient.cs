using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRatePrediction.Application.OpenExchangeRates;

namespace ExchangeRatePrediction.Application.Contract
{
	public interface IOpenExchangeClient
	{
		Task<OpenExchangeRateResult> GetExchangeRateHistory(DateTime targetDate);
		Task<IEnumerable<OpenExchangeRateResult>> GetExchangeRateHistoryPeriod(DateTime fromDate, DateTime toDate);
	    Task<IDictionary<string, string>> GetExchangeRatesCurencies();

	}
}
