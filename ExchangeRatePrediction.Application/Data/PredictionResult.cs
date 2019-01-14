using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRatePrediction.Application.Data
{
    public class PredictionResult
    {
        public double PredictionRate { get; set; }
        public double RSquared { get; set; }
    }
}
