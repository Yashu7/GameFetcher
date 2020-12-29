using GameFetcherLogic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace GameFetcherLogic.SerializationServices
{
    public class GameDetailsModelToXmlSerializer : ISerializer<IGameDetailsModel>
    {
        public IGameDetailsModel Deserialize()
        {
            throw new NotImplementedException();
        }

        public void Serialize(IGameDetailsModel obj, string path)
        {
            throw new NotImplementedException();  
        }
        public void SerializeList(List<IGameDetailsModel> objs, string path)
        {
          
            List<GameInfoModel> xmlModels = new List<GameInfoModel>();
            foreach(var m in objs)
            {
                xmlModels.Add(new GameInfoModel { Title = m.Name,Platform =m.PlatformPlaying,Score =m.MyScore.ToString(),PlayingStatus =m.GetStatus.ToString() });
            }
            string formattedText = GameListCustomSerializer<GameInfoModel>.SerializeListToFormattedString(xmlModels);
            using (TextWriter writer = new StreamWriter(path + ".txt"))
            {
                writer.Write(formattedText);
            }
        }
        
    }
    public class GameInfoModel
    {
        public string Title { get; set; }
        public string Platform { get; set; }
        public string Score { get; set; }
        public string PlayingStatus { get; set; }
        
    }
     

}
