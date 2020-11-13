using DesktopUI_Logic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DesktopUI_Logic
{
    public class SqlConnectionInjector
    {
        ISqlConnection sql;
        public SqlConnectionInjector(ISqlConnection _sql)
        {
            sql = _sql;
        }
        public SqlConnectionInjector()
        {
            sql = new ToSqlConnection();
        }
        public List<IGameDetailsModel> GetAllGames()
        {
            return sql.ReadCommand();
        }
        public void RemoveGame(IGameDetailsModel game)
        {
            sql.RemoveCommand(game);
        }
        public List<IGameDetailsModel> GetPlayedGames()
        {
            return sql.ReadCommand().Where(x => x.GetStatus == GameDetailsModel.Status.Played).ToList();
        }
        public List<IGameDetailsModel> GetPlayingNowGames()
        {
            return sql.ReadCommand().Where(x => x.GetStatus == GameDetailsModel.Status.Playing).ToList();
        }
        public List<IGameDetailsModel> GetNotPlayedGames()
        {
            return sql.ReadCommand().Where(x => x.GetStatus == GameDetailsModel.Status.Not_Played).ToList();
        }
        public List<IGameDetailsModel> GetUpcomingGames()
        {
            return sql.ReadCommand().Where(x => x.FirstReleaseDate >= Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds)).ToList();
        }
        public void UpdateGame(IGameDetailsModel game)
        {
            sql.UpdateCommand(game);
        }
        public void InsertGame(IGameDetailsModel game)
        {
            sql.PostCommand(game);
        }
        public ObservableCollection<PlatformModel> GetAllPlatforms()
        {
            return sql.GetPlatformModels();
        }
    }
}
