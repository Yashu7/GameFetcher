
using GameFetcherLogic.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GameFetcherLogic
{
    public sealed class TwitchAuthClient : IAuthClient
    {
        private static TwitchAuth Bearer;
        private string _clientId;
        private string _clientSecret;
        private static TwitchAuthClient Instance;
        
        public static TwitchAuthClient GetInstance()
        {
            if(Instance == null)
            {
                Instance = new TwitchAuthClient("3yo2gt2qjjburcphl30wfyt0e64vxx", "w8jz4hiu4lqgzkgt7huvxcd62893my");
            }
            return Instance;
        }

        public TwitchAuthClient(string clientId, string clientSecret)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            Task.Run(() => GetAuth()).Wait();
        }
        
        public string ReturnToken()
        {
            return Bearer.Token;
        }
        
        /// <summary>
        /// Create access token from Twitch API providing correct ClientId and ClientSecret which can be generated at Twitch website
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns>Model of Twitch Authorization Bearer with token</returns>
        public async Task GetAuth()
        {
            //Get bearer by sending Twitch credentials
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsync(new Uri("https://id.twitch.tv/oauth2/token?client_id=") + _clientId + "&client_secret=" + _clientSecret + "&grant_type=client_credentials", null).ConfigureAwait(false);
                Bearer = await response.Content.ReadAsAsync<TwitchAuth>().ConfigureAwait(true);
            }
           
        }
       
        
    }
}
