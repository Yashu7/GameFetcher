using System;
using System.Collections.Generic;
using System.Text;

namespace GameFetcherLogic.SerializationServices
{
    public interface ISerializer<T>
    {
        /// <summary>
        /// Serializes list of objects to single text file.
        /// </summary>
        /// <param name="objs">List of objects</param>
        /// <param name="path">Save file path</param>
        void SerializeList(List<T> objs, string path);
        void Serialize(T obj, string path);
        T Deserialize();
    }
}
