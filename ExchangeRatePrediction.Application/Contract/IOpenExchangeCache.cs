using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRatePrediction.Application.OpenExchangeRates;

namespace ExchangeRatePrediction.Application.Contract
{
	public interface IOpenExchangeCache
	{
		List<OpenExchangeRateResult> InMemoryData { get; set; }
	}
}
