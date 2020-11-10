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
    public class DataGetter
    {
       
        public async Task<ObservableCollection<GameDetailsModel>> GetGameByTitle(string title, int platId)
        {
            GamesApiCalls gameData = new GamesApiCalls();
            
            string output = await gameData.GetGameByTitle(title);
            ObservableCollection<GameDetailsModel> UImodel = JsonConvert.DeserializeObject<ObservableCollection<GameDetailsModel>>(output);
            ObservableCollection<GameDetailsModel> games = new ObservableCollection<GameDetailsModel>();
            if (platId == 0) return UImodel;
            foreach(GameDetailsModel game in UImodel)
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
        public async Task<ObservableCollection<Models.PlatformModel>> GetAllPlatforms()
        {
            GamesApiCalls platformData = new GamesApiCalls();
            string output = await platformData.GetAllPlatforms();
            List<Models.PlatformModel> platformModels = JsonConvert.DeserializeObject<List<Models.PlatformModel>>(output);
            platformModels = platformModels.OrderByDescending(x => x.name).ToList();
            ObservableCollection<Models.PlatformModel> m = new ObservableCollection<Models.PlatformModel>(platformModels);
            return m;
        }
    }
}
