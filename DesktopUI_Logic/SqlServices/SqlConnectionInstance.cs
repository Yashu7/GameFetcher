using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace DesktopUI_Logic.SqlServices
{
    public static class SqlConnectionInstance
    {
        public static SQLiteConnection GetSQLiteConnection()
        { 
            string connectionString = "Data Source=.\\GameFetcherDBlite222.db;";
            SQLiteConnection cnn = new SQLiteConnection(connectionString);
            return (SQLiteConnection)cnn;
        }
    }
}
