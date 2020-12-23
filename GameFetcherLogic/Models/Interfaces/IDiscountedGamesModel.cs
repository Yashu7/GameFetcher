namespace GameFetcherLogic.Models
{
    public interface IDiscountedGamesModel
    {
        string Title { get; set; }
        string OriginalPrice { get; set; }
        string DiscountPrice { get; set; }
        int PlatformId { get; set; }
    }
}
