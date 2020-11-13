using DesktopUI_Logic.Models;
using System;
using System.Collections.Generic;
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
        public List<GameDetailsModel> GetAllGames()
        {
            return sql.ReadCommand();
        }
        public void RemoveGame(GameDetailsModel game)
        {
            sql.RemoveCommand(game);
        }
        public List<GameDetailsModel> GetPlayedGames()
        {
            return sql.ReadCommand().Where(x => x.GetStatus == GameDetailsModel.Status.Played).ToList();
        }
        public List<GameDetailsModel> GetPlayingNowGames()
        {
            return sql.ReadCommand().Where(x => x.GetStatus == GameDetailsModel.Status.Playing).ToList();
        }
        public List<GameDetailsModel> GetNotPlayedGames()
        {
            return sql.ReadCommand().Where(x => x.GetStatus == GameDetailsModel.Status.Not_Played).ToList();
        }
        public List<GameDetailsModel> GetUpcomingGames()
        {
            return sql.ReadCommand().Where(x => x.FirstReleaseDate >= Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds)).ToList();
        }
    }
}
