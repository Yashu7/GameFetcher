using DesktopUI_Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI_Logic
{
    public class DataInjection
    {
        readonly IDataGetter dataGetter;
        public DataInjection(IDataGetter _dataGetter) => dataGetter = _dataGetter;
        public DataInjection() => dataGetter = new DataGetter();

        public async Task<List<IGameDetailsModel>> GetAllGamesFromApi(string title, int platId) => new List<IGameDetailsModel>(await dataGetter.GetGameByTitle(title,platId));
        
        
    }
}
