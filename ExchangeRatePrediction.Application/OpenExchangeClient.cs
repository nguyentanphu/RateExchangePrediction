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

        public async Task<OpenExchangeRateResult> GetExchangeRateHistory(DateTime historyDate)
        {
            var response =
                await _httpClient.GetAsync(
                    $"historical/{historyDate:yyyy-MM-dd}.json?app_id={ApplicationConsts.OpenExchangeApiKey}");

            return await response.Content.ReadAsAsync<OpenExchangeRateResult>();
        }
    }
}
