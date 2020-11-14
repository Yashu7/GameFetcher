using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIapp;
using DesktopUI_Logic.Models;
using Newtonsoft.Json;


namespace DesktopUI_Logic
{
    public class DataGetter : IDataGetter
    {
        private readonly GameApiCallInjector apiCall = new GameApiCallInjector();
        public async Task<List<GameDetailsModel>> GetGameByTitle(string title, int platId)
        {
            List<GameDetailsModel> UImodel = JsonConvert.DeserializeObject<List<GameDetailsModel>>(await apiCall.GetGamesByTitle(title));
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
        public async Task<List<Models.IPlatformModel>> GetAllPlatforms()
        {
            List<Models.IPlatformModel> platformModels = JsonConvert.DeserializeObject<List<Models.IPlatformModel>>(await apiCall.GetAllPlatforms());
            platformModels = platformModels.OrderByDescending(x => x.name).ToList();
            List<Models.IPlatformModel> m = new List<Models.IPlatformModel>(platformModels);
            return m;
        }
    }
}
