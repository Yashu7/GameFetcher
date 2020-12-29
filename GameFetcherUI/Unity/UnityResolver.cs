using GameFetcherLogic.Models;
using GameFetcherLogic.SerializationServices;
using GameFetcherUI.View;
using GameFetcherUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace GameFetcherUI.Unity
{
     static class UnityResolver
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
        private static void Register(IUnityContainer container)
        {
            container.RegisterType<IView, GameStatus>();
            container.RegisterType<IView, GameStatusViewModel>();

            container.RegisterType<IView, GameDetails>();
            container.RegisterType<IView, GameDetailsViewModel>();

            container.RegisterType<IView, AddGamePage>("AddGame");
            container.RegisterType<IView, AddGamePageViewModel>("AddGame");

            container.RegisterType<IView, CheckDiscounts>("CheckDiscount");
            container.RegisterType<IView, CheckDiscountsViewModel>("CheckDiscount");

         
        }
        static UnityResolver()
        {
            Register(Container);
        }
    }
}
