using System.Collections.Generic;

namespace DesktopUI_Logic
{
    public interface ISqlConnectionInjector<T>
    {
        void Delete(T model);
        void DeleteAll();
        void InsertAll(List<T> models);
        void InsertGame(T model);
        List<T> SelectAll();
        void UpdateGame(T model);
    }
}