using GameFetcherLogic.ApiClients.Interfaces;
using GameFetcherLogic.Auth;
using GameFetcherLogic.Helpers;
using GameFetcherLogic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GameFetcherLogic.ApiClients
{
    class IGDBApiClient : IApiClient<GameDetailsModel>
    {
        private Uri _address;

        public async Task<List<GameDetailsModel>> Get(string value)
        {
            _address = new Uri("https://api.igdb.com/v4/games");
            string queryName = StringFormatter.ReturnFormattedValue(value);

            #region HttpClient Settings

            //Clear HttpClient
            HttpStaticClient.GetInstance.DefaultRequestHeaders.Accept.Clear();
            HttpStaticClient.GetInstance.DefaultRequestHeaders.Clear();

            //Set HttpClient
            HttpStaticClient.GetInstance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpStaticClient.GetInstance.DefaultRequestHeaders.Add("Client-ID", "3yo2gt2qjjburcphl30wfyt0e64vxx");
            HttpStaticClient.GetInstance.DefaultRequestHeaders.Add("Authorization", "Bearer " + AuthManager.GetToken(nameof(TwitchAuthClient)));
            HttpContent requestMessage = null;

            #endregion

            #region Api Call

            requestMessage = new StringContent(($"fields id,name,first_release_date,summary,platforms; where name ~ *\"{queryName}\"* & version_parent = null; limit 500; sort name asc;"), Encoding.UTF8, "application/json");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = (snder, cert, chain, error) => true;
            try
            {
                HttpResponseMessage response = await HttpStaticClient.GetInstance.PostAsync(_address, requestMessage).ConfigureAwait(false);
                var result = await HttpStaticClient.GetInstance.PostAsync(_address, null).ConfigureAwait(false);
                var jsonOutput = response.Content.ReadAsStringAsync().Result;
                List<GameDetailsModel> game = JsonConvert.DeserializeObject<List<GameDetailsModel>>(jsonOutput);
                return game;
            }
            catch (HttpRequestException)
            {

                throw new HttpRequestException();
            }

            #endregion
        }

        public Task<List<GameDetailsModel>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
