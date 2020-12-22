using APIapp.API;
using DesktopUI_Logic.ApiServices;
using DesktopUI_Logic.Models;
using DesktopUI_Logic.SerializationServices;
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
            container.RegisterType<IApiClient<string>, IGDBApiClient>("IGDBcall");
            container.RegisterType<IApiClient<string>, EshopScraperApiClient>("EshopScraperCall");
            container.RegisterType<IDataReciever<GameDetailsModel, string, int>, GameModelsReciever>("GameModelsReciever");
            container.RegisterType<IDataReciever<DiscountedSwitchGames, string, int>, EshopSalesReciever>("EshopDealsReciever");
            container.RegisterType<ISerializer<IGameDetailsModel>, GameDetailsModelToXmlSerializer>();
            IDataReciever<DiscountedSwitchGames, string, int> Reciever;
        
            
            



        }
        
    }
}
