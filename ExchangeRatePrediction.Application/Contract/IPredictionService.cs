using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ExchangeRatePrediction.Application.Data;
using ExchangeRatePrediction.Application.Exceptions;
using ExchangeRatePrediction.Application.OpenExchangeRates;

namespace ExchangeRatePrediction.Application.Contract
{
    public interface IPredictionService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="mode">Default monthly, change to daily if you want to get sample daily.</param>
        /// <param name="overrideCache">Default true</param>
        /// <returns></returns>
        /// <exception cref="HttpRequestException">Cannot connect to external api source.</exception>
        /// <exception cref="ArgumentException">Throw if fromDate is greater than startDate</exception>
        /// <exception cref="NotEnoughSampleException">Throw if sample return is less than 2 items.</exception>
        Task<IEnumerable<OpenExchangeRateResult>> FetchSampleData(DateTime fromDate, DateTime toDate, PeriodMode mode = PeriodMode.Monthly, bool overrideCache = false);

        /// <exception cref="CurrencyNotFoundException">Throw if target currencies are not found from sample list.</exception>
        /// <exception cref="ArgumentException">Throw if sample is null or has less than 2 items</exception>
        /// <returns></returns>
        PredictionResult MakePredictionFromSample(string fromCurrency, string toCurrency, DateTime targetDate,
            IEnumerable<OpenExchangeRateResult> sample);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="HttpRequestException">Cannot connect to external api source.</exception>
        Task<IDictionary<string, string>> GetCurrencies();
    }
}
