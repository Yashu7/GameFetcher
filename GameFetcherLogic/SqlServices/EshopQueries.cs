using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using GameFetcherLogic.Models;

namespace GameFetcherLogic.SqlServices
{
    internal class EshopQueries : ISqlQueries<IDiscountedGamesModel>
    {
        public void Delete(IDiscountedGamesModel model)
        {
            using (var cnn = SqlConnectionInstance.GetSQLiteConnection())
            {
                SQLiteCommand command;
                cnn.Open();
                string query = "DELETE FROM SwitchEshopGames WHERE Title = '"+model.Title+"';";
                command = new SQLiteCommand(query, cnn);
                command.ExecuteReader();
                command.Dispose();
                cnn.Close();
            }
        }

        public void DeleteAll()
        {
            using (var cnn = SqlConnectionInstance.GetSQLiteConnection())
            {
                SQLiteCommand command;
                cnn.Open();
                string query = "DELETE FROM SwitchEshopGames";
                command = new SQLiteCommand(query, cnn);
                command.ExecuteReader();
                command.Dispose();
                cnn.Close();
            }
        }

        public void Insert(IDiscountedGamesModel model)
        {
            using(var cnn = SqlConnectionInstance.GetSQLiteConnection())
            {
                SQLiteCommand command;
                cnn.Open();
                string query = "INSERT INTO SwitchEshopGames ( Title,OriginalPrice,DiscountPrice,Platform ) VALUES ( @title, @ogPrice,@dcPrice,@plat)";
                command = new SQLiteCommand(query, cnn);
                command.Parameters.Add(new SQLiteParameter("@title", model.Title));
                command.Parameters.Add(new SQLiteParameter("@ogPrice", model.OriginalPrice));
                command.Parameters.Add(new SQLiteParameter("@dcPrice", model.DiscountPrice));
                command.Parameters.Add(new SQLiteParameter("@plat", model.PlatformId));
                command.ExecuteReader();
                command.Dispose();
                cnn.Close();
            }
        }

        public void InsertAll(List<IDiscountedGamesModel> models)
        {
            if (models == null) return;
            foreach (IDiscountedGamesModel game in models)
            {
                using (SQLiteConnection cnn = SqlConnectionInstance.GetSQLiteConnection())
                {
                    SQLiteCommand comm;
                    cnn.Open();

                    string query = "INSERT INTO SwitchEshopGames ( Title,OriginalPrice,DiscountPrice,Platform ) VALUES ( @title, @ogPrice,@dcPrice,@plat)";
                    comm = new SQLiteCommand(query, cnn);
                    comm.Parameters.Add(new SQLiteParameter("@title", game.Title));
                    comm.Parameters.Add(new SQLiteParameter("@ogPrice", game.OriginalPrice));
                    comm.Parameters.Add(new SQLiteParameter("@dcPrice", game.DiscountPrice));
                    comm.Parameters.Add(new SQLiteParameter("@plat", game.PlatformId));

                    comm.ExecuteReader();
                    comm.Dispose();
                    cnn.Close();

                }
            }
        }

        public List<IDiscountedGamesModel> SelectAll()
        {
            throw new NotImplementedException();
        }

        public IDiscountedGamesModel SelectBy(IDiscountedGamesModel model)
        {
            IDiscountedGamesModel foundModel = new DiscountedSwitchGames();
            using (SQLiteConnection cnn = SqlConnectionInstance.GetSQLiteConnection())
            {
                SQLiteCommand comm;
                cnn.Open();
                string query = "SELECT OriginalPrice,DiscountPrice FROM SwitchEshopGames WHERE SwitchEshopGames.Title = \"" + model.Title + "\";";
                comm = new SQLiteCommand(query, cnn);
                SQLiteDataReader reader;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    foundModel = new DiscountedSwitchGames
                    {
                        OriginalPrice = reader.GetString(0),
                        DiscountPrice = reader.GetString(1),
                    };
                }
                return foundModel;
            }
        }

        public void Update(IDiscountedGamesModel model)
        {
            throw new NotImplementedException();
        }

      
    }
}
