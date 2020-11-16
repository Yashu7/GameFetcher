using DesktopUI_Logic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI_Logic
{
    public class SqlConnectionInjector
    {
        readonly ISqlConnection sql;
        public SqlConnectionInjector(ISqlConnection _sql) => sql = _sql;
        public SqlConnectionInjector() => sql = new ToSqlConnection();
       
        public List<IGameDetailsModel> GetAllGames() => sql.ReadCommand();
        
        public void RemoveGame(IGameDetailsModel game) => sql.RemoveCommand(game);
        
        public List<IGameDetailsModel> GetPlayedGames() => sql.ReadCommand().Where(x => x.GetStatus == GameDetailsModel.Status.Played).ToList();
       
        public List<IGameDetailsModel> GetPlayingNowGames() =>  sql.ReadCommand().Where(x => x.GetStatus == GameDetailsModel.Status.Playing).ToList();
        
        public List<IGameDetailsModel> GetNotPlayedGames() => sql.ReadCommand().Where(x => x.GetStatus == GameDetailsModel.Status.Not_Played).ToList();
       
        public List<IGameDetailsModel> GetUpcomingGames() => sql.ReadCommand().Where(x => x.FirstReleaseDate >= Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds)).ToList();

        public void UpdateGame(IGameDetailsModel game) => sql.UpdateCommand(game);

        public void InsertGame(IGameDetailsModel game) => sql.PostCommand(game);

        public ObservableCollection<IPlatformModel> GetAllPlatforms() => sql.GetPlatformModels();
        
        public void RefreshDiscounts(List<IDiscountedGamesModel> games) => sql.PostDiscountedGames(games);
        public string GetDiscount(IGameDetailsModel game) => sql.GetDiscount(game);

    }
}
