using System.Threading.Tasks;

namespace APIapp
{
    public interface IGamesApiCalls
    {
        Task<string> GetAllPlatforms();
        Task<string> GetGameByTitle(string title);
    }
}