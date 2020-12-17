using DesktopUI_Logic;
using DesktopUI_Logic.Models;
using DesktopUI_Logic.Unity;
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
    public class GameStatusViewModel : UserControl, INotifyPropertyChanged, IView, IUnitySetup, IViewCommandSetter
    {
        #region Properties, fields
        private IUnityContainer container;
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
            InstantiateUnity();
        }
        #endregion

        #region Methods
        private void UpdateGame(object obj)
        {
            var values = (object[])obj;
           
            container.Resolve<ISqlConnectionInjector<IGameDetailsModel>>().UpdateGame(values[0] as IGameDetailsModel);
            ICloseable closable = (ICloseable)values[1];
            closable.Close();
           
        }
        public void InstantiateUnity()
        {
            container = new UnityContainer();
            UnityRegister.Register(container);
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
