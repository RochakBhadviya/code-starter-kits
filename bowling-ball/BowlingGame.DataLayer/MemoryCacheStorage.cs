using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.DataLayer
{
    public class MemoryCacheStorage
    {
        private readonly IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        private static readonly Lazy<MemoryCacheStorage> storage = new Lazy<MemoryCacheStorage>(() => new MemoryCacheStorage());

        /// <summary>
        /// Get memory cache storage object.
        /// </summary>
        public static MemoryCacheStorage GetInstance
        {
            get
            {
                return storage.Value;
            }
        }

        /// <summary>
        /// Insert entity in the cache.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="frameId"></param>
        /// <param name="bowlingScore"></param>
        public void InsertIntoCache<T>(int frameId, T bowlingScore)
        {
            if(_cache.TryGetValue(frameId, out T cacheEntry))
            {
                _cache.Remove(frameId);
            }

            _cache.Set(frameId, bowlingScore);
        }

        /// <summary>
        /// Get bowling score by frame id.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="frameId"></param>
        /// <returns></returns>
        public T GetBowlingScore<T>(int frameId)
        {
            T cacheEntry;

            if(_cache.TryGetValue(frameId, out cacheEntry))
            {
                return cacheEntry;
            }

            return default(T);
        }
    }
}
