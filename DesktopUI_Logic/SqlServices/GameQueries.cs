using DesktopUI_Logic.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace DesktopUI_Logic.SqlServices
{
    internal class GameQueries : ISqlQueries<IGameDetailsModel>
    {
        private static SQLiteConnection Connect()
        {
            SQLiteConnection cnn = new SQLiteConnection();
            string connectionString = "Data Source=.\\GameFetcherDBlite222.db;";
            cnn = new SQLiteConnection(connectionString);
            return (SQLiteConnection)cnn;
        }
        public void Delete(IGameDetailsModel model)
        {
            using (SQLiteConnection cnn = Connect())
            {
                SQLiteCommand comm;
                cnn.Open();
                string query = "DELETE FROM Games WHERE Id = @id;";
                comm = new SQLiteCommand(query, cnn);
                comm.Parameters.Add(new SQLiteParameter("@id", model.Id));
                comm.ExecuteReader();
                comm.Dispose();
                cnn.Close();
            }
        }

        public void Insert(IGameDetailsModel model)
        {
            using (SQLiteConnection cnn = Connect())
            {
                SQLiteCommand comm;
                cnn.Open();
                //comm = new SQLiteCommand("InsertGame", cnn);
                //comm.CommandType = CommandType.StoredProcedure;
                string query = "INSERT INTO Games(Title,ReleaseDate,Summary)VALUES(@title,@date,@summary)";
                comm = new SQLiteCommand(query, cnn);
                comm.Parameters.Add(new SQLiteParameter("@title", model.Name));
                comm.Parameters.Add(new SQLiteParameter("@date", model.FirstReleaseDate));
                comm.Parameters.Add(new SQLiteParameter("@summary", model.Summary));
                comm.ExecuteReader();
                comm.Dispose();
                cnn.Close();
                foreach (int a in model.Platforms)
                {
                    using (SQLiteConnection cnn2 = Connect())
                    {
                        cnn2.Open();
                        //comm = new SQLiteCommand("GamePlatformJunction", cnn);
                        //comm.CommandType = CommandType.StoredProcedure;
                        string secondQuery = "INSERT INTO GamePlatforms(GameId,PlatformId)VALUES((SELECT MAX(Id) FROM Games),@platformID)";
                        comm = new SQLiteCommand(secondQuery, cnn2);
                        comm.Parameters.Add(new SQLiteParameter("@gameID", 1));
                        comm.Parameters.Add(new SQLiteParameter("@platformID", a));
                        comm.ExecuteReader();
                        comm.Dispose();
                        cnn2.Close();
                    }
                }
            }
        }

        public List<IGameDetailsModel> SelectAll()
        {
            List<IGameDetailsModel> models = new List<IGameDetailsModel>();
            using (SQLiteConnection cnn = Connect())
            {
                SQLiteCommand comm;
                cnn.Open();
                string query = "SELECT * FROM Games";
                comm = new SQLiteCommand(query, cnn);
                SQLiteDataReader reader;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    IGameDetailsModel model = new GameDetailsModel()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        FirstReleaseDate = reader.GetInt32(2),
                        Summary = reader.GetString(3),
                        MyScore = reader.GetInt32(4)
                    };
                    if (reader.GetString(5) != null)
                    {
                        model.PlatformPlaying = reader.GetString(5);
                    }
                    GameDetailsModel.Status s = (GameDetailsModel.Status)reader.GetInt32(6);
                    model.GetStatus = s;
                    models.Add(model);
                }
                return AddPlatformsToGames(models);
            }
        }

        public IGameDetailsModel SelectBy(IGameDetailsModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(IGameDetailsModel model)
        {
            using (SQLiteConnection cnn = Connect())
            {
                SQLiteCommand comm;
                cnn.Open();
                //comm = new SQLiteCommand("UpdateGameProcedure", cnn);
                //comm.CommandType = CommandType.StoredProcedure;
                string query = "UPDATE Games SET Title = @title, ReleaseDate = @date, Summary = @summary, Status = @status, Rating = @rating, PlatformPlaying = @PlatformPlaying WHERE Id = @id;";
                comm = new SQLiteCommand(query, cnn);
                comm.Parameters.Add(new SQLiteParameter("@id", model.Id));
                comm.Parameters.Add(new SQLiteParameter("@title", model.Name));
                comm.Parameters.Add(new SQLiteParameter("@date", model.FirstReleaseDate));
                comm.Parameters.Add(new SQLiteParameter("@summary", model.Summary));
                comm.Parameters.Add(new SQLiteParameter("@status", Convert.ToInt32(model.GetStatus)));
                comm.Parameters.Add(new SQLiteParameter("@rating", model.MyScore));
                comm.Parameters.Add(new SQLiteParameter("@PlatformPlaying", model.PlatformPlaying));
                comm.ExecuteReader();
                comm.Dispose();
                cnn.Close();
            }
        }
        //Bind Platforms to Games's Platform IDs.
        private static List<IGameDetailsModel> AddPlatformsToGames(List<IGameDetailsModel> games)
        {
            using (SQLiteConnection cnn = Connect())
            {
                SQLiteCommand comm;
                cnn.Open();
                string query = "SELECT Games.Title, Platforms.PlatformName FROM((Games INNER JOIN GamePlatforms ON Games.Id = GamePlatforms.GameId) INNER JOIN Platforms ON GamePlatforms.PlatformId = Platforms.PlatformID);";
                comm = new SQLiteCommand(query, cnn);
                SQLiteDataReader reader;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    foreach (IGameDetailsModel game in games)
                    {
                        if (reader.GetString(0).Contains(game.Name))
                        {
                            game.AllPlatforms.Add(reader.GetString(1));
                        }
                    }
                }
                return games;
            }
        }

        public void InsertAll(List<IGameDetailsModel> models)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }
    }
}
