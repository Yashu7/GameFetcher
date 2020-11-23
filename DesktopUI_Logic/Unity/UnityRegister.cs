using DesktopUI_Logic.Models;
using DesktopUI_Logic.SqlServices;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace DesktopUI_Logic.Unity
{
    public static class UnityRegister
    {
        public static void Register(IUnityContainer container)
        {
            container.RegisterType<ISqlQueries<IGameDetailsModel>, GameQueries>();
            container.RegisterType<ISqlQueries<IPlatformModel>, PlatformQueries>();
            container.RegisterType<ISqlQueries<IDiscountedGamesModel>, EshopQueries>();
        }
        
    }
}
