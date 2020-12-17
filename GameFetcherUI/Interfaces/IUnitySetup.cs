using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFetcherUI.Interfaces
{
    public interface IUnitySetup
    {

        /// <summary>
        /// Set up all unity dependencies. Primarily use this at constructor.
        /// </summary>
        public void InstantiateUnity();
    }
}
