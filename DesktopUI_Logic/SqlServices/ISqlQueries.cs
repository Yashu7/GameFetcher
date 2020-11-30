using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopUI_Logic.SqlServices
{
    public interface ISqlQueries<T>
    {
        //Interface for classes that talk to the SQL Server
        void Insert(T model);
        void InsertAll(List<T> models);
        List<T> SelectAll();
        T SelectBy(T model);
        void Delete(T model);
        void DeleteAll();
        void Update(T model);
    }
}
