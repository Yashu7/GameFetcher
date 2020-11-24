using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI_Logic.ApiServices
{
    public interface IDataReciever<T, T2, T3>
    {
        Task<List<T>> GetByValue(T2 value, T3 value2);
        Task<List<T>> GetAll();
    }
}
