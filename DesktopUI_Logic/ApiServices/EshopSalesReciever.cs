using APIapp.API;
using DesktopUI_Logic.Models;
using DesktopUI_Logic.Unity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace DesktopUI_Logic.ApiServices
{
    public class EshopSalesReciever : IDataReciever<DiscountedSwitchGames, string, int>
    {
        IUnityContainer container;
        public EshopSalesReciever()
        {
            container = new UnityContainer();
            UnityRegister.Register(container);
        }       
        public async Task<List<DiscountedSwitchGames>> GetAll()
        {
            var apiClient = container.Resolve<IApiClient<string>>("EshopScraperCall");
            List<DiscountedSwitchGames> discountedGames = JsonConvert.DeserializeObject<List<DiscountedSwitchGames>>(await apiClient.GetAll().ConfigureAwait(false));
            return discountedGames;
        }

        public async Task<List<DiscountedSwitchGames>> GetByValue(string value, int value2)
        {
            List<DiscountedSwitchGames> games = new List<DiscountedSwitchGames>();
            try
            {
                var apiClient = container.Resolve<IApiClient<string>>("EshopScraperCall");
                List<DiscountedSwitchGames> discountedGames = JsonConvert.DeserializeObject<List<DiscountedSwitchGames>>(await apiClient.GetByValue(value).ConfigureAwait(false));
                games = discountedGames.Where(x => x.Title.Contains(value)).ToList();
                return games;
            }
            catch(NullReferenceException ex)
            {
                return null;
            }
        }
    }
}
