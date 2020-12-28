using GameFetcherUI.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFetcherUI.Models
{
    public class GameModel
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

      
        public long Id { get; set; }

        
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

        public List<string> AllPlatforms { get; set; } = new List<string>() { "No Platform Available" };
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

        public List<long> AgeRatings { get; set; }

        public List<long> AlternativeNames { get; set; }

        public List<long> Bundles { get; set; }

        public long Category { get; set; }

        public long CreatedAt { get; set; }

        public List<long> Dlcs { get; set; }

        public List<long> Expansions { get; set; }

        public long FirstReleaseDate { get; set; } = 0;

        public string ReleaseDate
        {
            get
            {
                return EpochToDateConverter.ConvertTime(FirstReleaseDate);
            }

            set
            {
                
            }
        }

        public List<long> Franchises { get; set; }

        public List<long> GameEngines { get; set; }

        public List<long> GameModes { get; set; }

        public List<long> Genres { get; set; }

        public List<long> InvolvedCompanies { get; set; }

        public List<long> Keywords { get; set; }

        public List<long> MultiplayerModes { get; set; }

        private string _name;
        
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public List<long> Platforms { get; set; }

        public double Rating { get; set; }

        public List<long> ReleaseDates { get; set; }

        public List<long> SimilarGames { get; set; }

        public string Storyline { get; set; }

        private string _summary = "No summary";
       
        public string Summary
        {
            get
            {
                return _summary;
            }
            set
            {
                if (value == null) return;
                _summary = value;
                NotifyPropertyChanged("Summary");

            }
        }

        public List<long> Tags { get; set; }

        public List<long> Themes { get; set; }
    }
}
