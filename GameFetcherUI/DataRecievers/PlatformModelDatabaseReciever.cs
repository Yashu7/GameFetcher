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

namespace GameFetcherUI.DataRecievers
{
    public class PlatformModelDatabaseReciever : IDatabaseReciever<Models.PlatformModel>
    {
        private readonly ISqlConnectionInjector<IPlatformModel> _sqlConn;
        private Mapper _mapper { get; set; }
        public PlatformModelDatabaseReciever()
        {
            _mapper = new Mapper(App.Config);
            _sqlConn = UnityRegister.Container.Resolve<ISqlConnectionInjector<IPlatformModel>>();
        }
        public void Delete(Models.PlatformModel name)
        {
            throw new NotImplementedException();
        }

        public List<Models.PlatformModel> GetAll()
        {
            return _mapper.Map<List<IPlatformModel>, List<Models.PlatformModel>>(_sqlConn.SelectAll());
        }

        public List<Models.PlatformModel> GetBy(Models.PlatformModel name)
        {
            throw new NotImplementedException();
        }

        public void Insert(Models.PlatformModel name)
        {
            throw new NotImplementedException();
        }

        public void Update(Models.PlatformModel name)
        {
            throw new NotImplementedException();
        }
    }
}
