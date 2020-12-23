using GameFetcherLogic.ApiServices;
using GameFetcherLogic.Models;
using GameFetcherLogic.Unity;
using GameFetcherUI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using Unity;

namespace GameFetcherUI.ViewModel
{
    public class CheckDiscountsViewModel : ViewModelBase, INotifyPropertyChanged, IView
    { 
        #region Properties, fields
        
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
        #endregion
       
        #region Constructor
        public CheckDiscountsViewModel()
        {
            Game = StaticData.Instance.Model;
            DataContext = this;
            GetDiscountPrices();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Gets discount prices from outside APIs
        /// </summary>
        public async void GetDiscountPrices()
        {
            //Nintendo Eshop Discounts
            var eshop = UnityRegister.Container.Resolve<IDataReciever<DiscountedSwitchGames, string, int>>("EshopDealsReciever");
            try
            {
                List<DiscountedSwitchGames> list = await eshop.GetByValue(Game.Name, 1).ConfigureAwait(false);
                if (list.Count > 0)
                {
                    EshopDiscountPrice = list[0].DiscountPrice;
                    EshopPrice = list[0].OriginalPrice;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

         

        #endregion

    }
}
