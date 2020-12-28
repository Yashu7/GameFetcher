using System;
using System.Collections.Generic;
using System.Text;

namespace GameFetcherUI.Converters
{
    sealed class EpochToDateConverter
    {
        public static string ConvertTime(long time)
        {
            if (time <= 0) return "Release Date Unknown";
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(time).ToLocalTime();
            return dtDateTime.ToString("dd/MM/yyyy");
        }
    }
}
