using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace APIapp.API
{
    public sealed class EshopScraperApiClient : IApiClient<string>
    {
        /// <summary>
        /// Get all discounts for Nintendo Switch games from API.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetAll()
        {
            HttpStaticClient.GetInstance.BaseAddress = new Uri("http://eshopfetcher.aspnet.pl/api/gamemodels");
            HttpStaticClient.GetInstance.DefaultRequestHeaders.Accept.Clear();
            HttpStaticClient.GetInstance.DefaultRequestHeaders.Clear();
            HttpStaticClient.GetInstance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await HttpStaticClient.GetInstance.GetAsync(HttpStaticClient.GetInstance.BaseAddress).ConfigureAwait(false);
            var output = response.Content.ReadAsStringAsync().Result;
            return output;
        }

        /// <summary>
        /// Check if specific game is on discount.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetByValue(string value)
        {
            HttpStaticClient.GetInstance.BaseAddress = new Uri("http://eshopfetcher.aspnet.pl/api/gamemodels");
            HttpStaticClient.GetInstance.DefaultRequestHeaders.Accept.Clear();
            HttpStaticClient.GetInstance.DefaultRequestHeaders.Clear();
            HttpStaticClient.GetInstance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await HttpStaticClient.GetInstance.GetAsync(HttpStaticClient.GetInstance.BaseAddress).ConfigureAwait(false);
            var output = response.Content.ReadAsStringAsync().Result;
            return output;
        }
    }
}
