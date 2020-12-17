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
       
        public void Connect()
        {
            HttpStaticClient.httpClient.BaseAddress = new Uri("http://eshopfetcher.aspnet.pl/api/gamemodels");
            HttpStaticClient.httpClient.DefaultRequestHeaders.Accept.Clear();
            HttpStaticClient.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           
        }

        public async Task<string> GetAll()
        {
            Connect();
            HttpResponseMessage response = await HttpStaticClient.httpClient.GetAsync(HttpStaticClient.httpClient.BaseAddress).ConfigureAwait(false);
            var output = response.Content.ReadAsStringAsync().Result;
            return output;
        }

        public async Task<string> GetByValue(string value)
        {
            Connect();
            HttpResponseMessage response = await HttpStaticClient.httpClient.GetAsync(HttpStaticClient.httpClient.BaseAddress).ConfigureAwait(false);
            var output = response.Content.ReadAsStringAsync().Result;
            return output;
        }
    }
}
