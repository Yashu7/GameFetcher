using System;
using System.Collections.Generic;
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
       
        public async Task<List<GameDetailsModel>> GetGameByTitle(string title, int platId)
        {
            GamesApiCalls gameData = new GamesApiCalls();
            
            string output = await gameData.GetGameByTitle(title);
            List<GameDetailsModel> UImodel = JsonConvert.DeserializeObject<List<GameDetailsModel>>(output);
            List<GameDetailsModel> games = new List<GameDetailsModel>();
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
        public async Task<List<Models.PlatformModel>> GetAllPlatforms()
        {
            GamesApiCalls platformData = new GamesApiCalls();
            string output = await platformData.GetAllPlatforms();
            List<Models.PlatformModel> platformModels = JsonConvert.DeserializeObject<List<Models.PlatformModel>>(output);
            platformModels = platformModels.OrderByDescending(x => x.name).ToList();
            return platformModels;
        }
    }
}
