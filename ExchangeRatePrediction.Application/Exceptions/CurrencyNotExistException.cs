using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeRatePrediction.Application.Exceptions
{
	public class CurrencyNotFoundException : Exception
	{
		public CurrencyNotFoundException(Exception innerException = null) : base($"One or more currencies were not found in sample data", innerException)
		{

		}
	}
}
