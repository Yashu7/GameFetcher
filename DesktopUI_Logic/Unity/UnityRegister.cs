using APIapp.API;
using DesktopUI_Logic.Models;
using DesktopUI_Logic.SqlServices;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.Injection;

namespace DesktopUI_Logic.Unity
{
    public static class UnityRegister
    {
        public static void Register(IUnityContainer container)
        {
            container.RegisterType<ISqlQueries<IGameDetailsModel>, GameQueries>();
            container.RegisterType<ISqlQueries<IPlatformModel>, PlatformQueries>();
            container.RegisterType<ISqlQueries<IDiscountedGamesModel>, EshopQueries>();
            container.RegisterType<ISqlConnectionInjector<IGameDetailsModel>, SqlConnectionInjector<IGameDetailsModel>>();
            container.RegisterType<ISqlConnectionInjector<IPlatformModel>, SqlConnectionInjector<IPlatformModel>>();
            container.RegisterType<ISqlConnectionInjector<IDiscountedGamesModel>, SqlConnectionInjector<IDiscountedGamesModel>>();
            container.RegisterType<IApiClient<string>, IGDBApiCall>("IGDBcall");


            container.RegisterType<IApiClient<string>>(new InjectionConstructor(new ResolvedParameter<IApiClient<string>>("IGDBcall")));
        }
        
    }
}
