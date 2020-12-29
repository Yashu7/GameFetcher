using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GameFetcherLogic.Models
{
    public interface IGameDetailsModel
    {
        
        List<long> AgeRatings { get; set; }
        List<string> AllPlatforms { get; set; }
        List<long> AlternativeNames { get; set; }
        List<long> Bundles { get; set; }
        long Category { get; set; }
        long CreatedAt { get; set; }
        List<long> Dlcs { get; set; }
        List<Enum> Enums { get; set; }
        List<long> Expansions { get; set; }
        long FirstReleaseDate { get; set; }
        List<long> Franchises { get; set; }
        List<long> GameEngines { get; set; }
        List<long> GameModes { get; set; }
        List<long> Genres { get; set; }
        GameDetailsModel.Status GetStatus { get; set; }
        long Id { get; set; }
        List<long> InvolvedCompanies { get; set; }
        List<long> Keywords { get; set; }
        List<long> MultiplayerModes { get; set; }
        int MyScore { get; set; }
        string Name { get; set; }
        string PlatformPlaying { get; set; }
        List<long> Platforms { get; set; }
        string PlatformsGames { get; set; }
        double Rating { get; set; }
        string ReleaseDate { get; set; }
        List<long> ReleaseDates { get; set; }
        List<long> SimilarGames { get; set; }
        string Storyline { get; set; }
        string Summary { get; set; }
        List<long> Tags { get; set; }
        List<long> Themes { get; set; }
       
    }
}