using APIapp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIapp.Factories
{
    public abstract class Factory
    {
        public abstract IObject ReturnObject(string objectName);
    }
}
