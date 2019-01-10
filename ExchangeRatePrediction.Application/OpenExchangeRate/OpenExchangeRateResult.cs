using System.Collections.Generic;

namespace ExchangeRatePrediction.Application.OpenExchangeRate
{
    public class OpenExchangeRateResult
    {
        public long TimeStamp { get; set; }
        public string Base { get; set; }
        public IDictionary<string, double> Rates { get; set; }
    }
}
