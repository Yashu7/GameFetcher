using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace APIapp.API
{
    public class EshopScraper : IApiClient<string>
    {
        /// <summary>
        /// Get all discounts for Nintendo Switch games from API.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetAll()
        {
            HttpStaticClient.httpClient.BaseAddress = new Uri("http://eshopfetcher.aspnet.pl/api/gamemodels");
            HttpStaticClient.httpClient.DefaultRequestHeaders.Accept.Clear();
            HttpStaticClient.httpClient.DefaultRequestHeaders.Clear();
            HttpStaticClient.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await HttpStaticClient.httpClient.GetAsync(HttpStaticClient.httpClient.BaseAddress).ConfigureAwait(false);
            var output = response.Content.ReadAsStringAsync().Result;
            return output;
        }

        /// <summary>
        /// Check if specific game is on discount.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetByValue(string value)
        {
            HttpStaticClient.httpClient.BaseAddress = new Uri("http://eshopfetcher.aspnet.pl/api/gamemodels");
            HttpStaticClient.httpClient.DefaultRequestHeaders.Accept.Clear();
            HttpStaticClient.httpClient.DefaultRequestHeaders.Clear();
            HttpStaticClient.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await HttpStaticClient.httpClient.GetAsync(HttpStaticClient.httpClient.BaseAddress).ConfigureAwait(false);
            var output = response.Content.ReadAsStringAsync().Result;
            return output;
        }
    }
}
