using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace APIapp
{
    public class EshopApiCaller : IGamesApiCalls
    {
        private static HttpClient ConnectToApi()
        {
            
            var apiCall = new HttpClient
            {
                BaseAddress = new Uri("http://eshopfetcher.aspnet.pl/api/gamemodels")
            };
            apiCall.DefaultRequestHeaders.Accept.Clear();
            apiCall.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            return apiCall;
        }
        public async Task<string> GetAllPlatforms()
        {
            HttpClient call = ConnectToApi();
            
            HttpResponseMessage response = await call.GetAsync(call.BaseAddress).ConfigureAwait(true);
            var a = response.Content.ReadAsStringAsync().Result;
            return a;
        }
        public Task<string> GetGameByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
