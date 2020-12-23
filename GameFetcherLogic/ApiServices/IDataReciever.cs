using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameFetcherLogic.ApiServices
{
    public interface IDataReciever<T, T2, T3>
    {
        //Interface for classes that recieve data from APIs

        /// <summary>
        /// Looks if specified game is discounted.
        /// </summary>
        /// <param name="value"></param>
        Task<List<T>> GetByValue(T2 value, T3 value2);
        /// <summary>
        /// Returns all discounted games.
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAll();
    }
}
