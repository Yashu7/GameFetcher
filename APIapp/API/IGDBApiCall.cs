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
        private TwitchAuth bearer;

        public Task<string> GetAll()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Find games by title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<string> GetByValue(string title)
        {
            #region Twitch Token
            bearer = await TwitchApiCalls.GetAuth("3yo2gt2qjjburcphl30wfyt0e64vxx", "w8jz4hiu4lqgzkgt7huvxcd62893my").ConfigureAwait(false);
            #endregion

            #region HttpClient Settings
          
            HttpStaticClient.httpClient.DefaultRequestHeaders.Accept.Clear();
            HttpStaticClient.httpClient.DefaultRequestHeaders.Clear();
            HttpStaticClient.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpStaticClient.httpClient.DefaultRequestHeaders.Add("Client-ID", "3yo2gt2qjjburcphl30wfyt0e64vxx");
            HttpStaticClient.httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + bearer.Token);
            HttpContent requestMessage = null;
            string address = "https://api.igdb.com/v4/games";

            #endregion

            string queryName = StringFormatter(title);

            #region Call
            requestMessage = new StringContent(($"fields id,name,first_release_date,summary,platforms; where name ~ *\"{queryName}\"* & version_parent = null; limit 500; sort name asc;"), Encoding.UTF8, "application/json");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = (snder, cert, chain, error) => true;
            try
            {
                HttpResponseMessage response = await HttpStaticClient.httpClient.PostAsync(address, requestMessage).ConfigureAwait(false);
                var result = await HttpStaticClient.httpClient.PostAsync(address, null).ConfigureAwait(false);
                List<GameModel> game = new List<GameModel>();
                var a = response.Content.ReadAsStringAsync().Result;
             
                return a;
            }
            catch (HttpRequestException)
            {

                return null;
            }
           
            #endregion
        }

        /// <summary>
        /// Formats string to specific format needed for IGDB search query
        /// </summary>
        /// <returns>Formatted string for query</returns>
        private static string StringFormatter(string title)
        {
            if (title == null) return String.Empty;
            String[] separator = title.Split(' ');
            string queryName = "";
            foreach (String s in separator)
            {
                queryName += s + "% ";
            }
            return queryName = queryName.Remove(queryName.Length - 1);
        }


    }
}
