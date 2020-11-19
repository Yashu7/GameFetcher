using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace APIapp
{
    public class GamesApiCalls : IGamesApiCalls
    {

        private static async Task<HttpClient> ConnectToApi()
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
        private static async Task<string> GetGamesByTitle(string title)
        {

            HttpClient call = await ConnectToApi().ConfigureAwait(false);
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
        public async Task<string> GetGameByTitle(string title)
        {
            try
            {
                if (title is null) return null;
                return await GetGamesByTitle(title).ConfigureAwait(false);

            }
            catch(ArgumentNullException)
            {
                return null;
            }
        }
        public async Task<string> GetAllPlatforms()
        {
            HttpClient call = await ConnectToApi().ConfigureAwait(false);
            HttpContent requestMessage;
            requestMessage = new StringContent(($"fields id,name; limit 500;"), Encoding.UTF8, "application/json");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = (snder, cert, chain, error) => true;
            Uri connection = new Uri("https://api.igdb.com/v4/platforms");
            
            HttpResponseMessage response = await call.PostAsync(connection, requestMessage).ConfigureAwait(false);
            var result = await call.PostAsync(connection, null).ConfigureAwait(false);
            List<PlatformModel> game = new List<PlatformModel>();

            var a = response.Content.ReadAsStringAsync().Result;
            return a;
        }
    }
}
