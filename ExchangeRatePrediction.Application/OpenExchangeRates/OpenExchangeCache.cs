using System.Collections.Generic;

namespace ExchangeRatePrediction.Application.OpenExchangeRates
{
    public class OpenExchangeCache
    {
        public List<OpenExchangeRateResult> InmemoryData { get; set; } = new List<OpenExchangeRateResult>();
    }
}
