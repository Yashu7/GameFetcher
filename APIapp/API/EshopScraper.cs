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
        public async Task<HttpClient> Connect()
        {
            
            TwitchAuth bearer = await TwitchApiCalls.GetAuth("a","b").ConfigureAwait(false);
            var apiCall = new HttpClient
            {
                BaseAddress = new Uri("http://eshopfetcher.aspnet.pl/api/gamemodels")
            };
            apiCall.DefaultRequestHeaders.Accept.Clear();
            apiCall.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            return apiCall;
        }

        public async Task<string> GetAll()
        {
            HttpClient call = await Connect().ConfigureAwait(false);

            HttpResponseMessage response = await call.GetAsync(call.BaseAddress).ConfigureAwait(false);
            var output = response.Content.ReadAsStringAsync().Result;
            return output;
        }

        public async Task<string> GetByValue(string value)
        {
            HttpClient call = await Connect().ConfigureAwait(false);

            HttpResponseMessage response = await call.GetAsync(call.BaseAddress).ConfigureAwait(false);
            var output = response.Content.ReadAsStringAsync().Result;
            return output;
        }
    }
}
