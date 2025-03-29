using ASC.WEB.Models;

namespace ASC.WEB.Data
{
    public interface INavigationCacheOperations
    {
        Task<NavigationModels> GetNavigationCacheAsync();
        Task CreateNavigationCacheAsync();
    }
}
