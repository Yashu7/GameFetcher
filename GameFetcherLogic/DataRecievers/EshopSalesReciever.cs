
using GameFetcherLogic.ApiClients.Interfaces;
using GameFetcherLogic.Models;
using GameFetcherLogic.Unity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace GameFetcherLogic.ApiServices
{
    public class EshopSalesReciever : IDataReciever<DiscountedSwitchGames, string, int>, IDisposable
    {
    
        public EshopSalesReciever()
        {
            
        }
        /// <summary>
        /// Return all found discounted games from Nintendo website by accessing outside API.
        /// </summary>
        /// <returns>List of DiscountedSwitchGames models</returns>
        public async Task<List<DiscountedSwitchGames>> GetAll()
        {
            var apiClient = UnityRegister.Container.Resolve<IApiClient<string>>("EshopScraperCall");
            List<DiscountedSwitchGames> discountedGames = new List<DiscountedSwitchGames>((IEnumerable<DiscountedSwitchGames>)await apiClient.GetAll().ConfigureAwait(false));
            return discountedGames;
        }

        /// <summary>
        /// Checks by title if game is discounted at Nintendo website. Uses outside API.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>DiscountSwitchGames model</returns>
        public async Task<List<DiscountedSwitchGames>> GetByValue(string value, int value2)
        {
            List<DiscountedSwitchGames> games = new List<DiscountedSwitchGames>();
            try
            {
                var apiClient = UnityRegister.Container.Resolve<IApiClient<string>>("EshopScraperCall");
                List<DiscountedSwitchGames> discountedGames = new List<DiscountedSwitchGames>((IEnumerable<DiscountedSwitchGames>)await apiClient.Get(value).ConfigureAwait(false));
                games = discountedGames.Where(x => x.Title.Contains(value)).ToList();
                return games;
            }
            catch(NullReferenceException ex)
            {
                return null;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
