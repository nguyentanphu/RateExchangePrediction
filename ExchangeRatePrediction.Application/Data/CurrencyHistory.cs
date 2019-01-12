using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRatePrediction.Application.Data
{
    public class CurrencyHistory
    {
	    private readonly string _fromCurrency;
		private readonly string _toCurrency;
	    private IList<Tuple<long, double>> _exchangeRateSample;

		public CurrencyHistory(string fromCurrency, string toCurrency, IList<Tuple<long, double>> exchangeRateSample)
		{
			_fromCurrency = fromCurrency;
			_toCurrency = toCurrency;
			_exchangeRateSample = exchangeRateSample;
		}

	    public double MakePrediction(DateTime targetDate)
	    {
		    var n = _exchangeRateSample.Count;

		    if (n == 0) return default(double);

		    double sumX = 0;
		    double sumY = 0;
		    double sumXY = 0;
		    double sumXSquare = 0;

		    foreach (var sample in _exchangeRateSample)
		    {
			    sumX += sample.Item1;
			    sumY += sample.Item2;
			    sumXY += sample.Item1 * sample.Item2;
			    sumXSquare += sample.Item1 * sample.Item1;
		    }

		    var slope = (n * sumXY - sumX * sumY) / (n * sumXSquare - sumX * sumX);
		    var intercept = (sumY - slope * sumX) / n;

		    return slope * ((DateTimeOffset)targetDate).ToUnixTimeSeconds() + intercept;
	    }
	}
}
