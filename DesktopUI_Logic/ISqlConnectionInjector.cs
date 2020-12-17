using System.Collections.Generic;

namespace DesktopUI_Logic
{
    public interface ISqlConnectionInjector<T>
    {
        /// <summary>
        /// Delete record from database based on passed model
        /// </summary>
        /// <param name="model"></param>
        void Delete(T model);
        /// <summary>
        /// Delete all records from database
        /// </summary>
        void DeleteAll();
        /// <summary>
        /// Insert several records into database
        /// </summary>
        /// <param name="models"></param>
        void InsertAll(List<T> models);
        /// <summary>
        /// Insert single object into database
        /// </summary>
        /// <param name="model"></param>
        void InsertGame(T model);
        /// <summary>
        /// Return all records from database
        /// </summary>
        /// <returns></returns>
        List<T> SelectAll();
        /// <summary>
        /// Update existing record matching passed model
        /// </summary>
        /// <param name="model"></param>
        void UpdateGame(T model);
    }
}