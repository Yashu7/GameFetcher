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

            if (!CheckIfPathIsValid(path)) return;
            List<ExportedGameModel> xmlModels = new List<ExportedGameModel>();
            ConvertModels(objs, xmlModels);
            string formattedText = GameListCustomSerializer<ExportedGameModel>.SerializeListToFormattedString(xmlModels);
            using (TextWriter writer = new StreamWriter(path + ".txt"))
            {
                writer.Write(formattedText);
            }
        }
        /// <summary>
        /// Map IGameDetailsModel list to ExportedGameModel list.
        /// </summary>
        /// <param name="source">Original models</param>
        /// <param name="output">Models formatted for serialization</param>
        public static void ConvertModels(List<IGameDetailsModel> source, List<ExportedGameModel> output)
        {
            foreach (var model in source)
            {
                output.Add(new ExportedGameModel { Title = model.Name, Platform = model.PlatformPlaying, Score = model.MyScore.ToString(), PlayingStatus = model.GetStatus.ToString() });
            }
        }
        public static bool CheckIfPathIsValid(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Savefile path is missing", nameof(path));
                
            }
            return true;
        }
        
    }

}
