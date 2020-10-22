using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DesktopUI_Logic.Models
{
    public class GameDetailsModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

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

        public string ReleaseDate { get; set; }

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

        [JsonProperty("name")]
        public string Name { get; set; }

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

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("tags")]
        public List<long> Tags { get; set; }

        [JsonProperty("themes")]
        public List<long> Themes { get; set; }

       

        
    }
}
