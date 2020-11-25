using DesktopUI_Logic.ApiServices;
using DesktopUI_Logic.Models;
using DesktopUI_Logic.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace GameFetcherUI.ViewModel
{
    public class CheckDiscountsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        IUnityContainer container;
        private string _eshopDiscountPrice = "No sale";
        public string EshopDiscountPrice
        {
            get
            {
                return _eshopDiscountPrice;
            }
            set
            {
                _eshopDiscountPrice = value;
                NotifyPropertyChanged("EshopDiscountPrice");
            }
        }
        private string _eshopPrice = "";
        public string EshopPrice
        {
            get
            {
                return _eshopPrice;
            }
            set
            {
                _eshopPrice = value;
                NotifyPropertyChanged("EshopPrice");
            }
        }
        private IGameDetailsModel _game;
        public IGameDetailsModel Game
        {
            get
            {
                return _game;
            }
            set
            {
                _game = value;
                OnPropertyChanged();
            }
        }
        public CheckDiscountsViewModel()
        {
            Game = StaticData.Instance.Model;
            DataContext = this;
            container = new UnityContainer();
            UnityRegister.Register(container);
            GetPrices();
        }
        public async void GetPrices()
        {
            var eshop = container.Resolve<IDataReciever<DiscountedSwitchGames, string, int>>("EshopDealsReciever");
            List<DiscountedSwitchGames> list = await eshop.GetByValue(Game.Name,1).ConfigureAwait(false);
            if (list != null)
            {
                EshopDiscountPrice = list[0].DiscountPrice;
                EshopPrice = list[0].OriginalPrice;
            }
            else
            {
                MessageBox.Show("Not found");
            }
        }

    }
}
