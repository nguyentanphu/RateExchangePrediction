using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRatePrediction.Application.Data
{
    public class ExchangeRatesHistory
    {
	    private IList<Tuple<long, double>> _exchangeRateSample;

        private double _slope;
        private double _intercept;
        private double _rSquared;

		public ExchangeRatesHistory(IList<Tuple<long, double>> exchangeRateSample)
		{
			_exchangeRateSample = exchangeRateSample ?? throw new ArgumentException();
		    CalculateRegressionLine();
		    CalculateRSquared();
		}

        private void CalculateRegressionLine()
        {
            var n = _exchangeRateSample.Count;
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

            _slope = (n * sumXY - sumX * sumY) / (n * sumXSquare - sumX * sumX);
            _intercept = (sumY - _slope * sumX) / n;
        }

        private void CalculateRSquared()
        {
            double sumActualDistance = 0;
            double sumEstimatedDistance = 0;
            double meanY = _exchangeRateSample.Average(r => r.Item2);
            foreach (var sample in _exchangeRateSample)
            {
                sumActualDistance += Math.Pow(sample.Item2 - meanY, 2);
                var estimatedY = _slope * sample.Item1 + _intercept;
                sumEstimatedDistance += Math.Pow(estimatedY - meanY, 2);
            }

            _rSquared = sumEstimatedDistance / sumActualDistance;
        }

	    public double MakePrediction(DateTime targetDateUtc)
	    {
		    var n = _exchangeRateSample.Count;

		    if (n == 0) return default(double);

		    return Math.Round(_slope * ((DateTimeOffset)targetDateUtc).ToUnixTimeSeconds() + _intercept, 4, MidpointRounding.AwayFromZero);
	    }

        public double GetRSquared()
        {
            return Math.Round(_rSquared, 4, MidpointRounding.AwayFromZero);
        }
	}
}
