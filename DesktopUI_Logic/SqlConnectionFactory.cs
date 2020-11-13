using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopUI_Logic
{
    public class SqlConnectionFactory
    {
        public static ISqlConnection GetSqlConnection()
        {
            return new ToSqlConnection();
        }
    }
}
