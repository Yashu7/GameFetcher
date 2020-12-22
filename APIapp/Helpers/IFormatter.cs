using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIapp.Helpers
{
    interface IFormatter<T>
    {
        T ReturnFormattedValue(T value);
    }
}
