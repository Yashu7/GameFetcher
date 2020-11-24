using APIapp.API;
using DesktopUI_Logic.Models;
using DesktopUI_Logic.Unity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace DesktopUI_Logic.ApiServices
{
    class GameModelsReciever : IDataReciever<GameDetailsModel, string, int>
    {
        public IApiClient<string> apiClient;
        public GameModelsReciever()
        {
            IUnityContainer container = new UnityContainer();
            UnityRegister.Register(container);
            apiClient = container.Resolve<IApiClient<string>>("IGDBcall");

        }
        public async Task<List<GameDetailsModel>> GetAll()
        {
            List<GameDetailsModel> UImodel = JsonConvert.DeserializeObject<List<GameDetailsModel>>(await apiClient.GetByValue("").ConfigureAwait(false));
            return UImodel;
        }

        public async Task<List<GameDetailsModel>> GetByValue(string title, int platId)
        {
            List<GameDetailsModel> UImodel = JsonConvert.DeserializeObject<List<GameDetailsModel>>(await apiClient.GetByValue(title).ConfigureAwait(false));
            List<GameDetailsModel> games = new List<GameDetailsModel>();
            if (platId == 0) return UImodel;
            foreach (GameDetailsModel game in UImodel)
            {
                if (game.Platforms != null)
                {
                    if (game.Platforms.Contains(platId))
                    {
                        games.Add(game);
                    }
                }
            }
            return games;
        }
    }
}
