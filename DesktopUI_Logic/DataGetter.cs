using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIapp;
using DesktopUI_Logic.Models;
using Newtonsoft.Json;


namespace DesktopUI_Logic
{
    public class DataGetter
    {
       
        public async Task<List<GameDetailsModel>> GetGameByTitle(string title)
        {
            GamesApiCalls gameData = new GamesApiCalls();
            
            string output = await gameData.GetGameByTitle(title);
            List<GameDetailsModel> UImodel = JsonConvert.DeserializeObject<List<GameDetailsModel>>(output);

           

            return UImodel;
        }
    }
}
