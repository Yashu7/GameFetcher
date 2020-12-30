using GameFetcherUI.DataRecievers;
using GameFetcherUI.Factories;
using GameFetcherUI.Interfaces;
using GameFetcherUI.Models;
using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace GameFetcherUI.ViewModel
{
    public class GameStatusViewModel : UserControl, INotifyPropertyChanged, IView, IViewCommandSetter
    {
        #region Properties, fields
        private IDataAccess<GameModel> GamesReciever { get; set; }
        private GameModel _game = new GameModel();
        public GameModel Game
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
            GamesReciever = GameModelDatabaseRecieverFactory.Factory.GetInstance();
            DataContext = this;
            Game = PickedGameSingleton.Instance.Model;
            InstantiateCommands();
        }
        #endregion

        #region Methods
        private void UpdateGame(object obj)
        {
            var values = (object[])obj;
            GamesReciever.Update(values[0] as GameModel);
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
