using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GameFetcherLogic.SerializationServices
{
    public static class GameListCustomSerializer<T>
    {
        /// <summary>
        /// Formats list of game objects into a single string for serialization.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeListToFormattedString(List<T> obj)
        {
            try
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append("Your Games:");
                stringBuilder.AppendLine();
                foreach (var o in obj)
                {
                    var objType = o.GetType();
                    IList<PropertyInfo> props = new List<PropertyInfo>(objType.GetProperties());
                    foreach (var p in props)
                    {
                        var propValue = p.GetValue(o, null);
                        
                        stringBuilder.Append(p.Name + " : " + propValue + " | ");
                    }
                    stringBuilder.AppendLine();
                }
                return stringBuilder.ToString();
            }
            catch(ArgumentNullException ex)
            {
                return ex.ToString();
            }
        }
    }
}
