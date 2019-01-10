using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRatePrediction.Application
{
    public class OpenExchangeClient
    {
        private HttpClient _httpClient;

        public OpenExchangeClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ApplicationConsts.OpenExchangeApiBaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<OpenExchangeRateResult> GetExchangeRateHistory(DateTime targetDate)
        {
            var response =
                await _httpClient.GetAsync(
                    $"historical/{targetDate:yyyy-MM-dd}.json?app_id={ApplicationConsts.OpenExchangeApiKey}");

            return await response.Content.ReadAsAsync<OpenExchangeRateResult>();
        }

	    public async Task<IEnumerable<OpenExchangeRateResult>> GetExchangeRateHistoryPeriod(DateTime fromDate, DateTime toDate)
	    {
		    if (fromDate > toDate) throw new ArgumentException("fromDate cannot be greater than toDate", nameof(fromDate));
		    var midMonthFromDate = GetMidMonthDay(fromDate);

			var allTasks = new List<Task<OpenExchangeRateResult>>();

		    while (midMonthFromDate <= toDate)
		    {
				allTasks.Add(GetExchangeRateHistory(midMonthFromDate));
			    midMonthFromDate = midMonthFromDate.AddMonths(1);
		    }

		    return await Task.WhenAll(allTasks);

	    }

	    private DateTime GetMidMonthDay(DateTime targetDate)
	    {
			return new DateTime(targetDate.Year, targetDate.Month, 15);
	    }

	}
}
