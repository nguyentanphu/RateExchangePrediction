using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRatePrediction.Application.Data;
using Xunit;

namespace ExchangeRatePrediction.UnitTests
{
	public class CurrencyHistoryTests
	{
		[Fact]
		public void MakePrediction_With0Sample_ReturnDefault()
		{
			var currencyHistory = new CurrencyHistory("USD", "VND",new List<Tuple<long, double>>());
			var result = currencyHistory.MakePrediction(new DateTime(2000, 1, 1));

			Assert.Equal(default(double), result);

		}
	}
}
