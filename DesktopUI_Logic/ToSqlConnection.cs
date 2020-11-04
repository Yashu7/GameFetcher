using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using DesktopUI_Logic.Models;
using System.Linq;
using System.Windows;
using System.Data;

namespace DesktopUI_Logic
{
    public class ToSqlConnection
    {
        private SqlConnection Connect()
        {
            string connectionString = null;
            SqlConnection cnn;
            connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GameFetcherDatabase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
            cnn = new SqlConnection(connectionString);
            return cnn;
            
        }
        public void PostPlatforms(List<PlatformModel> platforms)
        {
            
            foreach(PlatformModel model in platforms)
            {
                SqlConnection cnn = Connect();
                SqlCommand comm;
                cnn.Open();
                comm = new SqlCommand("InsertPlatform", cnn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                comm.Parameters.Add(new SqlParameter("@Id", model.platformId));
                comm.Parameters.Add(new SqlParameter("@Name", model.name));
               
                comm.ExecuteReader();
                comm.Dispose();
                cnn.Close();
            }
           
        }
        public void PostCommand(GameDetailsModel game)
        {
            SqlConnection cnn = Connect();
            SqlCommand comm;
                cnn.Open();
                 comm = new SqlCommand("InsertGame", cnn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@title", game.Name));
                comm.Parameters.Add(new SqlParameter("@date", game.FirstReleaseDate));
                comm.Parameters.Add(new SqlParameter("@summary", game.Summary));
                comm.ExecuteReader();
                comm.Dispose();
                cnn.Close();

            foreach (int a in game.Platforms)
            {
                cnn = Connect();
                cnn.Open();
                comm = new SqlCommand("GamePlatformJunction", cnn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@gameID", 1));
                comm.Parameters.Add(new SqlParameter("@platformID", a));
                comm.ExecuteReader();
                comm.Dispose();
                cnn.Close();
            }


        }
        public void UpdateCommand(GameDetailsModel game)
        {
            SqlConnection cnn = Connect();
            SqlCommand comm;
            cnn.Open();
            comm = new SqlCommand("UpdateGameProcedure", cnn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@id", game.Id));
            comm.Parameters.Add(new SqlParameter("@title", game.Name));
            comm.Parameters.Add(new SqlParameter("@date", game.FirstReleaseDate));
            comm.Parameters.Add(new SqlParameter("@summary", game.Summary));
            comm.Parameters.Add(new SqlParameter("@status", Convert.ToInt32(game.GetStatus)));
            comm.Parameters.Add(new SqlParameter("@rating", game.MyScore));
            comm.Parameters.Add(new SqlParameter("@PlatformPlaying", game.PlatformPlaying));
            comm.ExecuteReader();
            comm.Dispose();
            cnn.Close();
        }
        public void RemoveCommand(GameDetailsModel game)
        {
            SqlConnection cnn = Connect();
            SqlCommand comm;
            cnn.Open();
            comm = new SqlCommand("RemoveGame", cnn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@id", game.Id));
           
            comm.ExecuteReader();
            comm.Dispose();
            cnn.Close();
        }
        public List<GameDetailsModel> ReadCommand()
        {
            List<GameDetailsModel> models = new List<GameDetailsModel>();
            SqlConnection cnn = Connect();
            SqlCommand comm;
            cnn.Open();
            string query = "SELECT * FROM Games";
            comm = new SqlCommand(query, cnn);
            SqlDataReader reader;
            reader = comm.ExecuteReader();
            while(reader.Read())
            {
                GameDetailsModel model = new GameDetailsModel
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    FirstReleaseDate = reader.GetInt32(2),
                    Summary = reader.GetString(3),
                    MyScore = reader.GetInt32(4)


                    
                };
                if(reader.GetString(5) != null)
                {
                    model.PlatformPlaying = reader.GetString(5);
                }




                GameDetailsModel.Status s = (GameDetailsModel.Status)reader.GetInt32(6);
                model.playingStatus = s;
                models.Add(model);


            }


            return AddPlatformsToGames(models);
        }
        public List<GameDetailsModel> AddPlatformsToGames(List<GameDetailsModel> games)
        {
           
            SqlConnection cnn = Connect();
            SqlCommand comm;
            cnn.Open();
            string query = "SELECT Games.Title, Platforms.PlatformName FROM((Games INNER JOIN GamePlatforms ON Games.Id = GamePlatforms.GameId) INNER JOIN Platforms ON GamePlatforms.PlatformId = Platforms.PlatformID);";
            comm = new SqlCommand(query, cnn);
            SqlDataReader reader;
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
        public List<PlatformModel> GetPlatformModels()
        {
            List<PlatformModel> models = new List<PlatformModel>();
            SqlConnection cnn = Connect();
            SqlCommand comm;
            cnn.Open();
            string query = "SELECT * FROM Platforms";
            comm = new SqlCommand(query, cnn);
            SqlDataReader reader;
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
