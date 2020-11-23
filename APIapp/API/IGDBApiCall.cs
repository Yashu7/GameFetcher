using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace APIapp.API
{
    public class IGDBApiCall : IApiClient<string>
    {
        public async Task<HttpClient> Connect()
        {
            //Get bearer token
            TwitchApiCalls twitchCall = new TwitchApiCalls();
            TwitchAuth bearer = await twitchCall.GetAuth().ConfigureAwait(false);
            //call address
            var apiCall = new HttpClient
            {
                BaseAddress = new Uri("https://api.igdb.com/v4/games")
            };
            apiCall.DefaultRequestHeaders.Accept.Clear();
            apiCall.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            apiCall.DefaultRequestHeaders.Add("Client-ID", "3yo2gt2qjjburcphl30wfyt0e64vxx");
            apiCall.DefaultRequestHeaders.Add("Authorization", "Bearer " + bearer.Token);
            return apiCall;
        }

        public Task<string> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetByValue(string title)
        {
            HttpClient call = await Connect().ConfigureAwait(false);
            HttpContent requestMessage = null;

            #region String converter.
            //Convert string for proper search query.
            String[] separator = title.Split(' ');
            string queryName = "";
            foreach (String s in separator)
            {
                queryName += s + "% ";
            }
            queryName = queryName.Remove(queryName.Length - 1);
            #endregion

            requestMessage = new StringContent(($"fields id,name,first_release_date,summary,platforms; where name ~ *\"{queryName}\"* & version_parent = null; limit 500; sort name asc;"), Encoding.UTF8, "application/json");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = (snder, cert, chain, error) => true;
            try
            {
                HttpResponseMessage response = await call.PostAsync(call.BaseAddress, requestMessage).ConfigureAwait(false);
                var result = await call.PostAsync(call.BaseAddress, null).ConfigureAwait(false);
                List<GameModel> game = new List<GameModel>();
                var a = response.Content.ReadAsStringAsync().Result;
                return a;
            }
            catch (HttpRequestException)
            {

                return null;
            }
        }

       
    }
}
