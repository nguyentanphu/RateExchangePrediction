using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRatePrediction.Application.OpenExchangeRates;

namespace ExchangeRatePrediction.Application.Data
{
    public class OpenExchangeCache
    {
        public List<OpenExchangeRateResult> InmemoryData { get; set; } = new List<OpenExchangeRateResult>();
    }
}
