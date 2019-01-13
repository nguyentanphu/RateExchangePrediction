using System.Collections.Generic;
using ExchangeRatePrediction.Application.Contract;

namespace ExchangeRatePrediction.Application.OpenExchangeRates
{
    public class OpenExchangeCache : IOpenExchangeCache
    {
        public List<OpenExchangeRateResult> InMemoryData { get; set; } = new List<OpenExchangeRateResult>();
    }
}
