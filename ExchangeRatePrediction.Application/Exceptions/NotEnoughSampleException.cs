using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRatePrediction.Application.Exceptions
{
    public class NotEnoughSampleException : Exception
    {
        private static readonly int _minSampleSize = 2;
        public NotEnoughSampleException() : base($"Not enough sample size was fetched. Minimum is {_minSampleSize}")
        {
        }
    }
}
