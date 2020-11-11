using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DesktopUI_Logic.Models
{
    public class GameDetailsModel : INotifyPropertyChanged
    {
        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public string ConvertTime(long time)
        {
            if (time <= 0) return "Release Date Unknown";
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(time).ToLocalTime();
            return dtDateTime.ToString("dd/MM/yyyy");
        }

        [JsonProperty("id")]
        public long Id { get; set; }

        //My game score I gave in application.
        private int _myScore = 0;
        public int MyScore
        { 
            get 
            { 
                
                return _myScore;
            }
            set
            {
                _myScore = value; 
                NotifyPropertyChanged("MyScore"); 
            }
        }
        
        public enum Status { Not_Played, Played, Playing };
        private Status playingStatus;


        public List<Enum> _enums = new List<Enum>() { Status.Not_Played, Status.Played, Status.Playing };
        public List<Enum> Enums
        {
            get
            {
                return _enums;
            }
            set
            {
                _enums = value;
                NotifyPropertyChanged("Enums");
            }
        } 
            
        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> AllPlatforms { get; set; } = new List<string>();
        public string PlatformsGames { get; set; }
        private string _platformPlaying;
        public string PlatformPlaying
        {
            get
            {
                return _platformPlaying;
            }
            set
            {
                _platformPlaying = value;
                NotifyPropertyChanged("PlatformPlaying");
            }
        }
        public Status GetStatus 
        {
            get
            {
                return playingStatus;
            }
            set 
            {
                playingStatus = value;
                NotifyPropertyChanged("GetStatus");
            }
        }


        [JsonProperty("age_ratings")]
        public List<long> AgeRatings { get; set; }

        [JsonProperty("alternative_names")]
        public List<long> AlternativeNames { get; set; }

        [JsonProperty("bundles")]
        public List<long> Bundles { get; set; }

        [JsonProperty("category")]
        public long Category { get; set; }

        

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }

        [JsonProperty("dlcs")]
        public List<long> Dlcs { get; set; }

        [JsonProperty("expansions")]
        public List<long> Expansions { get; set; }

        

        [JsonProperty("first_release_date")]
        public long FirstReleaseDate { get; set; }

        public string ReleaseDate
        {
            get
            {
                return ConvertTime(FirstReleaseDate);
            }

            set
            {
                ReleaseDate = ConvertTime(FirstReleaseDate);
            }
        }

        [JsonProperty("franchises")]
        public List<long> Franchises { get; set; }

        [JsonProperty("game_engines")]
        public List<long> GameEngines { get; set; }

        [JsonProperty("game_modes")]
        public List<long> GameModes { get; set; }

        [JsonProperty("genres")]
        public List<long> Genres { get; set; }

        [JsonProperty("involved_companies")]
        public List<long> InvolvedCompanies { get; set; }

        [JsonProperty("keywords")]
        public List<long> Keywords { get; set; }

        [JsonProperty("multiplayer_modes")]
        public List<long> MultiplayerModes { get; set; }

        private string _name;
        [JsonProperty("name")]
        public string Name
        {
            get { return _name; }
            set {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        [JsonProperty("platforms")]
        public List<long> Platforms { get; set; }

        

        [JsonProperty("rating")]
        public double Rating { get; set; }

        

        [JsonProperty("release_dates")]
        public List<long> ReleaseDates { get; set; }

        

        [JsonProperty("similar_games")]
        public List<long> SimilarGames { get; set; }

        

        [JsonProperty("storyline")]
        public string Storyline { get; set; }

        private string _summary;
        [JsonProperty("summary")]
        public string Summary
        {
            get
            {
                return _summary;
            }
            set
            {
                _summary = value;
                NotifyPropertyChanged("Summary");

            }
        }

        [JsonProperty("tags")]
        public List<long> Tags { get; set; }

        [JsonProperty("themes")]
        public List<long> Themes { get; set; }

       

        
    }
}
