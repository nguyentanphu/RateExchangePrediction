using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ExchangeRatePrediction.Application.OpenExchangeRates
{
    public class OpenExchangeRateResult
    {
        public DateTime DateFromTimeStamp => DateTimeOffset.FromUnixTimeSeconds(TimeStamp).Date;
        public long TimeStamp { get; set; }
        public string Base { get; set; }
        public IDictionary<string, double> Rates { get; set; } = new ConcurrentDictionary<string, double>();
    }
}
