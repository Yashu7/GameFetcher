using GameFetcherLogic.Models;
using GameFetcherLogic.SqlServices;
using GameFetcherLogic.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace GameFetcherLogic
{
    public class SqlConnectionInjector<T> : ISqlConnectionInjector<T>
    {

        readonly ISqlQueries<T> Sql;
        public SqlConnectionInjector(ISqlQueries<T> sql) => Sql = sql;
        public SqlConnectionInjector()
        {

            
            //Plugs in Sql Queries depending on T type
            Sql = UnityRegister.Container.Resolve<ISqlQueries<T>>();

        }



        public List<T> SelectAll() => Sql.SelectAll();

        public void Delete(T model) => Sql.Delete(model);

        public void DeleteAll() => Sql.DeleteAll();

        public void InsertAll(List<T> models) => Sql.InsertAll(models);

        public void UpdateGame(T model) => Sql.Update(model);

        public void InsertGame(T model) => Sql.Insert(model);





    }
}
