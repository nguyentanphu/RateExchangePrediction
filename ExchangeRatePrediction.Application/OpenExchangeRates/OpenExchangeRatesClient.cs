using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ExchangeRatePrediction.Application.Contract;
using ExchangeRatePrediction.Application.Data;
using ExchangeRatePrediction.Application.Utils;

namespace ExchangeRatePrediction.Application.OpenExchangeRates
{
    public class OpenExchangeRatesClient : IOpenExchangeClient
	{
        private readonly HttpClient _httpClient;
	    private readonly OpenExchangeCache _openExchangeCache;

        public OpenExchangeRatesClient(HttpClient httpClient, OpenExchangeCache openExchangeCache)
        {
            _openExchangeCache = openExchangeCache;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(ApplicationConsts.OpenExchangeApiBaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<OpenExchangeRateResult> GetExchangeRateHistory(DateTime targetDate)
        {
            var cacheResult = GetFromCache(targetDate);
            if (cacheResult != null) return cacheResult;


            var response =
                await _httpClient.GetAsync(
                    $"historical/{targetDate:yyyy-MM-dd}.json?app_id={ApplicationConsts.OpenExchangeApiKey}");
            var result = await response.Content.ReadAsAsync<OpenExchangeRateResult>();

            _openExchangeCache.InmemoryData.Add(result);

            return result;
        }

	    public async Task<IDictionary<string, string>> GetExchangeRatesCurencies()
	    {
	        var response =
	            await _httpClient.GetAsync("currencies.json");
	        return await response.Content.ReadAsAsync<IDictionary<string, string>>();
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

	    private OpenExchangeRateResult GetFromCache(DateTime targetDate)
	    {
	        return _openExchangeCache.InmemoryData.FirstOrDefault(x => x.DateFromTimeStamp == targetDate);
        }
        private DateTime GetMidMonthDay(DateTime targetDate)
	    {
			return new DateTime(targetDate.Year, targetDate.Month, 15);
	    }

	}
}
