using DesktopUI_Logic.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace DesktopUI_Logic.SqlServices
{
    internal class PlatformQueries : ISqlQueries<IPlatformModel>
    {
        public void Delete(IPlatformModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(IPlatformModel model)
        {
            using (SQLiteConnection cnn = SqlConnectionInstance.GetSQLiteConnection())
            {
                SQLiteCommand comm;
                cnn.Open();
                string query = "INSERT INTO Platforms ( PlatformID,PlatformName ) VALUES ( @Id, @Name )";
                comm = new SQLiteCommand(query, cnn);
                comm.Parameters.Add(new SQLiteParameter("@Id", model.platformId));
                comm.Parameters.Add(new SQLiteParameter("@Name", model.name));

                comm.ExecuteReader();
                comm.Dispose();
                cnn.Close();
            }
        }

        public void InsertAll(List<IPlatformModel> models)
        {
            foreach (IPlatformModel model in models)
            {
                using (SQLiteConnection cnn = SqlConnectionInstance.GetSQLiteConnection())
                {
                    SQLiteCommand comm;
                    cnn.Open();
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

        public List<IPlatformModel> SelectAll()
        {
            List<IPlatformModel> models = new List<IPlatformModel>();
            using (SQLiteConnection cnn = SqlConnectionInstance.GetSQLiteConnection())
            {
                SQLiteCommand comm;
                cnn.Open();
                string query = "SELECT * FROM Platforms";
                comm = new SQLiteCommand(query, cnn);
                SQLiteDataReader reader;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    IPlatformModel model = new PlatformModel
                    {
                        platformId = reader.GetInt32(1),
                        name = reader.GetString(2)
                    };

                    models.Add(model);


                }
                return models;
            }
        }

        public IPlatformModel SelectBy(IPlatformModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(IPlatformModel model)
        {
            throw new NotImplementedException();
        }

        
    }
}
