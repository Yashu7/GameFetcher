using DesktopUI_Logic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DesktopUI_Logic.SerializationServices
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
            List<GameDetailsModel> models = objs.Cast<GameDetailsModel>().ToList();
            List<GameInfoModel> xmlModels = new List<GameInfoModel>(); ;
            foreach(var m in models)
            {
                xmlModels.Add(new GameInfoModel { Title = m.Name,Platform =m.PlatformPlaying,Score =m.MyScore.ToString(),PlayingStatus =m.GetStatus.ToString() });
            }
            XmlSerializer serializer = new XmlSerializer(typeof(List<GameInfoModel>));
            string a = GameListCustomSerializer<GameInfoModel>.Serialize(xmlModels);

            using (TextWriter writer = new StreamWriter(path + ".txt"))
            {
                writer.Write(a);
                
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
