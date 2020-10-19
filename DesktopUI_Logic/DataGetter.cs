using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIapp;

namespace DesktopUI_Logic
{
    public class DataGetter
    {
        public async Task<string> GetData()
        {
            GamesApiCalls gameData = new GamesApiCalls();
            return await gameData.CallApi();
        }
        
    }
}
