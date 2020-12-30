using GameFetcherLogic.ApiClients;
using GameFetcherLogic.ApiClients.Interfaces;
using GameFetcherLogic.ApiServices;
using GameFetcherLogic.Models;
using GameFetcherLogic.SerializationServices;
using GameFetcherLogic.SqlServices;
using Unity;

namespace GameFetcherLogic.Unity
{
    public static class UnityRegister
    {
        private static UnityContainer _container = new UnityContainer(); 
        public static UnityContainer Container
        {
            get
            {
                return _container;
            }
            private set
            {
                _container = value;
            }
        }
        static void Register(IUnityContainer container)
        {
            container.RegisterType<ISqlQueries<IGameDetailsModel>, GameQueries>();
            container.RegisterType<ISqlQueries<IPlatformModel>, PlatformQueries>();
            container.RegisterType<ISqlQueries<IDiscountedGamesModel>, EshopQueries>();
            container.RegisterType<ISqlConnectionInjector<IGameDetailsModel>, SqlConnectionInjector<IGameDetailsModel>>();
            container.RegisterType<ISqlConnectionInjector<IPlatformModel>, SqlConnectionInjector<IPlatformModel>>();
            container.RegisterType<ISqlConnectionInjector<IDiscountedGamesModel>, SqlConnectionInjector<IDiscountedGamesModel>>();
            container.RegisterType<IApiClient<GameDetailsModel>, IGDBApiClient>("IGDBcall");
           // container.RegisterType<IApiClient<DiscountedSwitchGames>, IGDBApiClient>("EshopScraperCall");
            container.RegisterType<IDataAccess<GameDetailsModel, string, int>, GameModelsDataAccess>("GameModelsReciever");
            container.RegisterType<IDataAccess<DiscountedSwitchGames, string, int>, EshopPricesDataAccess>("EshopDealsReciever");
            container.RegisterType<ISerializer<IGameDetailsModel>, GameDetailsModelToXmlSerializer>();
            IDataAccess<DiscountedSwitchGames, string, int> Reciever;
        
        }
        static UnityRegister()
        {
            Register(Container);
        }
        
    }
}
