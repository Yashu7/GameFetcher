using AutoMapper;
using GameFetcherLogic;
using GameFetcherLogic.Models;
using GameFetcherLogic.Unity;
using GameFetcherUI.Models;
using System.Collections.Generic;
using System.Linq;
using Unity;

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
        /// <summary>
        /// Deletes record from source database based on passed parameter.
        /// </summary>
        /// <param name="name"></param>
        public void Delete(GameModel name)
        {
            sqlConn.Delete(_mapper.Map<IGameDetailsModel>(name));
        }
        /// <summary>
        /// Get list of records from the source database with the same name as paramater's name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<GameModel> GetBy(GameModel name)
        {
            var gamesList = _mapper.Map<List<IGameDetailsModel>, List<GameModel>>(sqlConn.SelectAll());
            return (List<GameModel>)gamesList.Where(x => x.Name.Contains(name.Name));
        }
        /// <summary>
        /// Get list of records from the source database.
        /// </summary>
        /// <returns></returns>
        public List<GameModel> GetAll()
        {
            return _mapper.Map<List<IGameDetailsModel>, List<GameModel>>(sqlConn.SelectAll());
        }
        /// <summary>
        /// Updates record from source database based on passed parameter.
        /// </summary>
        /// <param name="name"></param>
        public void Update(GameModel name)
        {
            sqlConn.UpdateGame(_mapper.Map<IGameDetailsModel>(name));
        }
        /// <summary>
        /// Inserts new record into source database.
        /// </summary>
        /// <param name="name"></param>
        public void Insert(GameModel name)
        {
            sqlConn.InsertGame(_mapper.Map<IGameDetailsModel>(name));
        }
    }
}
