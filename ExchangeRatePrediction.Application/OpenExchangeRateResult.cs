using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRatePrediction.Application
{
    public class OpenExchangeRateResult
    {
        public long TimeStamp { get; set; }
        public string Base { get; set; }
        public IDictionary<string, double> Rates { get; set; }
    }
}
