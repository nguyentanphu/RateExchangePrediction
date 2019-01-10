using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRatePrediction.Application.Data
{
    public class CurrencyHistory
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public List<double> ExchangeRates { get; set; }
    }
}
