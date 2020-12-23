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
    /// <summary>
    /// IGDB uses APIcalypse Query Language. https://apicalypse.io/
    /// <para>For more information about IGDB API visit: https://api-docs.igdb.com/#about </para>
    /// </summary>
    public sealed class IGDBApiClient : IApiClient<string>
    {
        
        private Uri _address;

        public IGDBApiClient()
        {
           
        }

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
            _address = new Uri("https://api.igdb.com/v4/games");
            string queryName = StringFormatter.ReturnFormattedValue(title);

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
