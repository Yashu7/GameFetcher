using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFetcherUI.Interfaces
{
    public interface IViewCommandSetter
    {
        /// <summary>
        /// Set up all commands needed. Primarily use this at constructor.
        /// </summary>
        void InstantiateCommands();
    }
}
