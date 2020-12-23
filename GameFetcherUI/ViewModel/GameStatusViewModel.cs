using GameFetcherLogic;
using GameFetcherLogic.Models;
using GameFetcherLogic.Unity;
using GameFetcherUI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Unity;

namespace GameFetcherUI.ViewModel
{
    public class GameStatusViewModel : UserControl, INotifyPropertyChanged, IView, IViewCommandSetter
    {
        #region Properties, fields
        private IGameDetailsModel _game = new GameDetailsModel();
        public IGameDetailsModel Game
        {
            get
            {
                return _game;
            }
            set
            {
                _game = value;
                NotifyPropertyChanged("Game");
            }
        }
        #endregion

        #region Constructor
        public GameStatusViewModel()
        {
            DataContext = this;
            Game = StaticData.Instance.Model;
            InstantiateCommands();
        }
        #endregion

        #region Methods
        private void UpdateGame(object obj)
        {
            var values = (object[])obj;

            UnityRegister.Container.Resolve<ISqlConnectionInjector<IGameDetailsModel>>().UpdateGame(values[0] as IGameDetailsModel);
            ICloseable closable = (ICloseable)values[1];
            closable.Close();
           
        }
        

        #endregion

        #region ICommands
        public ICommand UpdateCommand { get; private set; }

        public void InstantiateCommands()
        {
            UpdateCommand = new RelayCommand(new Action<object>(UpdateGame));
        }
        #endregion

        #region INotifyProperties
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

       
        
        #endregion
    }
}
