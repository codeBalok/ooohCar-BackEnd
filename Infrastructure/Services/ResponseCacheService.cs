using Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ResponseCacheService : IResponseCacheService
    {
        // private readonly IDatabase _database;
        // public ResponseCacheService(IConnectionMultiplexer redis)
        // {
        //     _database = redis.GetDatabase();
        // }

        // public async Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive)
        // {
        //     if (response == null)
        //     {
        //         return;
        //     }

        //     var options = new JsonSerializerOptions
        //     {
        //         PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        //     };

        //     var serialisedResponse = JsonSerializer.Serialize(response, options);

        //     await _database.StringSetAsync(cacheKey, serialisedResponse, timeToLive);
        // }

        // public async Task<string> GetCachedResponseAsync(string cacheKey)
        // {
        //     var cachedResponse = await _database.StringGetAsync(cacheKey);

        //     if (cachedResponse.IsNullOrEmpty)
        //     {
        //         return null;
        //     }

        //     return cachedResponse;
        // }
        public Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCachedResponseAsync(string cacheKey)
        {
            throw new NotImplementedException();
        }
    }
}