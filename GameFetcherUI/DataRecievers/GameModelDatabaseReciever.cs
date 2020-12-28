using AutoMapper;
using GameFetcherLogic;
using GameFetcherLogic.Models;
using GameFetcherLogic.Unity;
using GameFetcherUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Linq;

namespace GameFetcherUI.DataRecievers
{
    public class GameModelDatabaseReciever : IDatabaseReciever<GameModel>
    {
        private ISqlConnectionInjector<IGameDetailsModel> sqlConn;
        private Mapper _mapper { get; set; }
        public GameModelDatabaseReciever()
        {
            _mapper = new Mapper(App.Config);
            sqlConn = UnityRegister.Container.Resolve<ISqlConnectionInjector<IGameDetailsModel>>();
        }
        public void Delete(GameModel name)
        {
            sqlConn.Delete(_mapper.Map<IGameDetailsModel>(name));
        }

        public List<GameModel> GetBy(GameModel name)
        {
            var gamesList = _mapper.Map<List<IGameDetailsModel>, List<GameModel>>(sqlConn.SelectAll());
            return (List<GameModel>)gamesList.Where(x => x.Name.Contains(name.Name));
        }

        public List<GameModel> GetAll()
        {
            return _mapper.Map<List<IGameDetailsModel>, List<GameModel>>(sqlConn.SelectAll());
        }

        public void Update(GameModel name)
        {
            sqlConn.UpdateGame(_mapper.Map<IGameDetailsModel>(name));
        }

        public void Insert(GameModel name)
        {
            sqlConn.InsertGame(_mapper.Map<IGameDetailsModel>(name));
        }
    }
}
