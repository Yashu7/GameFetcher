using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using DesktopUI_Logic.Models;
using System.Linq;
using System.Windows;
using System.Data;
using System.Data.SQLite;
using System.Collections.ObjectModel;

namespace DesktopUI_Logic
{
    public class ToSqlConnection
    {
        private SQLiteConnection Connect()
        {
            string connectionString = null;
            SQLiteConnection cnn = new SQLiteConnection();
            //connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GameFetcherDatabase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
            connectionString = "Data Source=.\\GameFetcherDBlite222.db;";
            cnn = new SQLiteConnection(connectionString);
            
            return (SQLiteConnection)cnn;
            
        }
        public void PostPlatforms(ObservableCollection<PlatformModel> platforms)
        {

            foreach (PlatformModel model in platforms)
            {
                using (SQLiteConnection cnn = Connect())
                {
                    SQLiteCommand comm;
                    cnn.Open();
                    //  comm = new SQLiteCommand("InsertPlatform", cnn)
                    //  {
                    // CommandType = CommandType.StoredProcedure
                    // };
                    string query = "INSERT INTO Platforms ( PlatformID,PlatformName ) VALUES ( @Id, @Name )";
                    comm = new SQLiteCommand(query, cnn);
                    comm.Parameters.Add(new SQLiteParameter("@Id", model.platformId));
                    comm.Parameters.Add(new SQLiteParameter("@Name", model.name));

                    comm.ExecuteReader();
                    comm.Dispose();
                    cnn.Close();
                }
            }

        }
        public void PostCommand(GameDetailsModel game)
        {
            using (SQLiteConnection cnn = Connect())
            {
                SQLiteCommand comm;
                cnn.Open();
                //comm = new SQLiteCommand("InsertGame", cnn);
                //comm.CommandType = CommandType.StoredProcedure;
                string query = "INSERT INTO Games(Title,ReleaseDate,Summary)VALUES(@title,@date,@summary)";
                comm = new SQLiteCommand(query, cnn);
                comm.Parameters.Add(new SQLiteParameter("@title", game.Name));
                comm.Parameters.Add(new SQLiteParameter("@date", game.FirstReleaseDate));
                comm.Parameters.Add(new SQLiteParameter("@summary", game.Summary));
                comm.ExecuteReader();
                comm.Dispose();
                cnn.Close();
                foreach (int a in game.Platforms)
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
        public void UpdateCommand(GameDetailsModel game)
        {
            using (SQLiteConnection cnn = Connect())
            {
                SQLiteCommand comm;
                cnn.Open();
                //comm = new SQLiteCommand("UpdateGameProcedure", cnn);
                //comm.CommandType = CommandType.StoredProcedure;
                string query = "UPDATE Games SET Title = @title, ReleaseDate = @date, Summary = @summary, Status = @status, Rating = @rating, PlatformPlaying = @PlatformPlaying WHERE Id = @id;";
                comm = new SQLiteCommand(query, cnn);
                comm.Parameters.Add(new SQLiteParameter("@id", game.Id));
                comm.Parameters.Add(new SQLiteParameter("@title", game.Name));
                comm.Parameters.Add(new SQLiteParameter("@date", game.FirstReleaseDate));
                comm.Parameters.Add(new SQLiteParameter("@summary", game.Summary));
                comm.Parameters.Add(new SQLiteParameter("@status", Convert.ToInt32(game.GetStatus)));
                comm.Parameters.Add(new SQLiteParameter("@rating", game.MyScore));
                comm.Parameters.Add(new SQLiteParameter("@PlatformPlaying", game.PlatformPlaying));
                comm.ExecuteReader();
                comm.Dispose();
                cnn.Close();
            }
        }
        public void RemoveCommand(GameDetailsModel game)
        {
            using (SQLiteConnection cnn = Connect())
            {
                SQLiteCommand comm;
                cnn.Open();
                // comm = new SQLiteCommand("RemoveGame", cnn);
                // comm.CommandType = CommandType.StoredProcedure;
                string query = "DELETE FROM Games WHERE Id = @id;";
                comm = new SQLiteCommand(query, cnn);
                comm.Parameters.Add(new SQLiteParameter("@id", game.Id));

                comm.ExecuteReader();
                comm.Dispose();
                cnn.Close();
            }
        }
        public List<GameDetailsModel> ReadCommand()
        {
            List<GameDetailsModel> models = new List<GameDetailsModel>();
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
                    GameDetailsModel model = new GameDetailsModel
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
        public List<GameDetailsModel> AddPlatformsToGames(List<GameDetailsModel> games)
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
                    // MessageBox.Show(reader.GetString(1));

                    foreach (GameDetailsModel game in games)
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
        public ObservableCollection<PlatformModel> GetPlatformModels()
        {
            ObservableCollection<PlatformModel> models = new ObservableCollection<PlatformModel>();
            using (SQLiteConnection cnn = Connect())
            {
                SQLiteCommand comm;
                cnn.Open();
                string query = "SELECT * FROM Platforms";
                comm = new SQLiteCommand(query, cnn);
                SQLiteDataReader reader;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    PlatformModel model = new PlatformModel();
                    model.platformId = reader.GetInt32(1);
                    model.name = reader.GetString(2);

                    models.Add(model);


                }
                return models;
            }
        }
    }
}
