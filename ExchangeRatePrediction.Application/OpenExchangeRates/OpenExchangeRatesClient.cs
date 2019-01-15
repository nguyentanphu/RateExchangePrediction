using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ExchangeRatePrediction.Application.Contract;

namespace ExchangeRatePrediction.Application.OpenExchangeRates
{
    public class OpenExchangeRatesClient : IOpenExchangeClient
	{
        private readonly HttpClient _httpClient;
		private const string OpenExchangeApiBaseUrl = "https://openexchangerates.org/api/";
		private const string OpenExchangeApiKey = "3c9144dfedec4896ba18829d9019d877";

		public OpenExchangeRatesClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(OpenExchangeApiBaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public virtual async Task<OpenExchangeRateResult> GetExchangeRateHistory(DateTime targetDate)
        {
            var response =
                await _httpClient.GetAsync(
                    $"historical/{targetDate:yyyy-MM-dd}.json?app_id={OpenExchangeApiKey}");
            var result = await response.Content.ReadAsAsync<OpenExchangeRateResult>();

            return result;
        }

	    public async Task<IDictionary<string, string>> GetExchangeRatesCurrencies()
	    {
	        var response =
	            await _httpClient.GetAsync("currencies.json");
	        return await response.Content.ReadAsAsync<IDictionary<string, string>>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throw if fromDate is greater than startDate</exception>
	    public async Task<IEnumerable<OpenExchangeRateResult>> GetExchangeRateHistoryPeriod(DateTime fromDate, DateTime toDate, PeriodMode mode = PeriodMode.Monthly)
	    {
		    if (fromDate >= toDate) throw new ArgumentException("fromDate cannot be greater than toDate", nameof(fromDate));
		    if (mode == PeriodMode.Monthly) fromDate = GetMidMonthDay(fromDate);

			var allTasks = new List<Task<OpenExchangeRateResult>>();

		    while (fromDate <= toDate)
		    {
				allTasks.Add(GetExchangeRateHistory(fromDate));
			    fromDate = mode == PeriodMode.Monthly ? fromDate.AddMonths(1) : fromDate.AddDays(1);
		    }

            return await Task.WhenAll(allTasks);

	    }
        private DateTime GetMidMonthDay(DateTime targetDate)
	    {
			return new DateTime(targetDate.Year, targetDate.Month, 15);
	    }

	}
}
