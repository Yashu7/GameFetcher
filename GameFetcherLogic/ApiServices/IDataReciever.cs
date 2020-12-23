﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameFetcherLogic.ApiServices
{
    public interface IDataReciever<T, T2, T3>
    {
        //Interface for classes that recieve data from APIs

        Task<List<T>> GetByValue(T2 value, T3 value2);
        
        Task<List<T>> GetAll();
    }
}
