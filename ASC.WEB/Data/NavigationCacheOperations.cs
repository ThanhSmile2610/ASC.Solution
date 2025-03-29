using ASC.WEB.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace ASC.WEB.Data
{
    public class NavigationCacheOperations : INavigationCacheOperations
    {
        private readonly IDistributedCache _cache;
        private readonly string NavigationCacheName = "NavigationCache";
        public NavigationCacheOperations(IDistributedCache cache)
        {
            _cache = cache;
        }
        public async Task CreateNavigationCacheAsync()
        {
            await _cache.SetStringAsync(NavigationCacheName, File.ReadAllText("Navigation/Navigation.json"));
        }
        public async Task<NavigationModels> GetNavigationCacheAsync()
        {
            return JsonConvert.DeserializeObject<NavigationModels>(await _cache.GetStringAsync(NavigationCacheName));
        }
    }
}
