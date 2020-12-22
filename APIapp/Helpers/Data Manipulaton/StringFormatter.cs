using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIapp.Helpers
{
    class StringFormatter : IFormatter<string>
    {
        /// <summary>
        /// Formats string to specific format needed for IGDB search query
        /// </summary>
        /// <returns>Formatted string for query</returns>
        public string ReturnFormattedValue(string title)
        {
            if (title == null) return String.Empty;
            String[] separator = title.Split(' ');
            string queryName = "";
            foreach (String s in separator)
            {
                queryName += s + "% ";
            }
            return queryName = queryName.Remove(queryName.Length - 1);
        }
        
    }
}
