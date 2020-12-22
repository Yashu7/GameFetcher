using APIapp.Auth;
using APIapp.Factories;
using APIapp.Helpers;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace APIapp.API
{
    public class IGDBApiCall : IApiClient<string>
    {
        
        private string address;
        private IFormatter<string> formatter;
       
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

            
            #region HttpClient Settings

            HttpStaticClient.Instance.DefaultRequestHeaders.Accept.Clear();
            HttpStaticClient.Instance.DefaultRequestHeaders.Clear();
            HttpStaticClient.Instance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpStaticClient.Instance.DefaultRequestHeaders.Add("Client-ID", "3yo2gt2qjjburcphl30wfyt0e64vxx");
            HttpStaticClient.Instance.DefaultRequestHeaders.Add("Authorization", "Bearer " + AuthManager.GetToken("TwitchAuthClient"));
            HttpContent requestMessage = null;
            address = "https://api.igdb.com/v4/games";

            #endregion
            formatter = new StringFormatter();
            string queryName = formatter.ReturnFormattedValue(title);

            #region Call
            requestMessage = new StringContent(($"fields id,name,first_release_date,summary,platforms; where name ~ *\"{queryName}\"* & version_parent = null; limit 500; sort name asc;"), Encoding.UTF8, "application/json");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = (snder, cert, chain, error) => true;
            try
            {
                HttpResponseMessage response = await HttpStaticClient.Instance.PostAsync(address, requestMessage).ConfigureAwait(false);
                var result = await HttpStaticClient.Instance.PostAsync(address, null).ConfigureAwait(false);
                var game = response.Content.ReadAsStringAsync().Result;
                return game;
            }
            catch (HttpRequestException)
            {

                return null;
            }
           
            #endregion
        }

    }
}
