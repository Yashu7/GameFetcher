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
    public class GamesApiCalls
    {
        
        private async Task<HttpClient> ConnectToApi()
        {
            //Get bearer token
            TwitchApiCalls twitchCall = new TwitchApiCalls();
            TwitchAuth bearer = await twitchCall.GetAuth();

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
        private async Task<string> GetGamesByTitle(string title)
        {
            
            HttpClient call = await ConnectToApi();
                HttpContent requestMessage = null;

            #region String converter.
            //Convert string for proper search query.
            String[] separator = title.Split(' ');
            string queryName = "";
            foreach(String s in separator)
            {
                queryName += s + "% ";
            }
            queryName = queryName.Remove(queryName.Length - 1);
            #endregion

            requestMessage = new StringContent(($"fields *; where name ~ *\"{queryName}\"* & version_parent = null; limit 500; sort name asc;"), Encoding.UTF8, "application/json");
            
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = (snder, cert, chain, error) => true;
            try
            {
                HttpResponseMessage response = await call.PostAsync("https://api.igdb.com/v4/games", requestMessage);
                var result = await call.PostAsync("https://api.igdb.com/v4/games", null);
                List<GameModel> game = new List<GameModel>();
                var a = response.Content.ReadAsStringAsync().Result;
                return a;
            }
            catch(Exception)
            {
                return null;
            }
            
            

        }
        public async Task<string> GetGameByTitle(string title)
        {
            return await GetGamesByTitle(title);
        }

        public async Task<string> GetAllPlatforms()
        {
            HttpClient call = await ConnectToApi();
            HttpContent requestMessage;
            requestMessage = new StringContent(($"fields id,name; limit 500;"), Encoding.UTF8, "application/json");
           
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = (snder, cert, chain, error) => true;
            
            HttpResponseMessage response = await call.PostAsync("https://api.igdb.com/v4/platforms", requestMessage);
            var result = await call.PostAsync("https://api.igdb.com/v4/platforms", null);
            List<PlatformModel> game = new List<PlatformModel>();
          
            var a = response.Content.ReadAsStringAsync().Result;


            return a;
        }
    }
}
