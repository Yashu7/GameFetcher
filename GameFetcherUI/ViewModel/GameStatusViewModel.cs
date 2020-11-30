using DesktopUI_Logic;
using DesktopUI_Logic.Models;
using DesktopUI_Logic.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Unity;

namespace GameFetcherUI.ViewModel
{
    public class GameStatusViewModel : UserControl, INotifyPropertyChanged, IView
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
            container = new UnityContainer();
            UpdateCommand = new RelayCommand(new Action<object>(UpdateGame));
            
        }
        #endregion

        #region Methods
        private void UpdateGame(object obj)
        {
            UnityRegister.Register(container);
            container.Resolve<ISqlConnectionInjector<IGameDetailsModel>>().UpdateGame(obj as IGameDetailsModel);
           
        }
        #endregion

        #region ICommands
        public ICommand UpdateCommand { get; private set; }
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
