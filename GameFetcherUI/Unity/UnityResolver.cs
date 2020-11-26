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
    public static class UnityResolver
    {
        public static void Register(IUnityContainer container)
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
    }
}
