
using GameFetcherLogic.ApiClients.Interfaces;
using GameFetcherLogic.Models;
using GameFetcherLogic.Unity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace GameFetcherLogic.ApiServices
{
    class GameModelsDataAccess : IDataAccess<GameDetailsModel, string, int>
    {
        public IApiClient<GameDetailsModel> apiClient;
        public GameModelsDataAccess()
        {
            
            apiClient = UnityRegister.Container.Resolve<IApiClient<GameDetailsModel>>("IGDBcall");

        }
        public async Task<List<GameDetailsModel>> GetAll()
        {
            List<GameDetailsModel> UImodel = await apiClient.GetAll().ConfigureAwait(false);
            return UImodel;
        }

        public async Task<List<GameDetailsModel>> GetByValue(string title, int platId)
        {
            if (string.IsNullOrWhiteSpace(title)) return null;
            List<GameDetailsModel> UImodel = await apiClient.Get(title).ConfigureAwait(false);
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
