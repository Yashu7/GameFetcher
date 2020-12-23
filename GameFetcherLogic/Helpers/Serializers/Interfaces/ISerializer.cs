using System;
using System.Collections.Generic;
using System.Text;

namespace GameFetcherLogic.SerializationServices
{
    public interface ISerializer<T>
    {
        void SerializeList(List<T> objs, string path);
        void Serialize(T obj, string path);
        T Deserialize();
    }
}
