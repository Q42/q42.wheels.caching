using System;
using System.Runtime.Caching;

namespace Q42.Wheels.Caching
{
  /// <summary>
  /// This is a adapter on the System.Runtime.Caching.MemoryCache
  /// </summary>
  public class RuntimeCacheService : ICacheService
  {
    /// <summary>
    /// Get the object from cache or generate it and set it
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="generate"></param>
    /// <param name="lifetime"></param>
    /// <returns></returns>
    public T Get<T>(string key, Func<T> generate, TimeSpan? lifetime = null) 
    {
      var cache = MemoryCache.Default;
      object result = cache.Get(key);
      if (result == null)
      {
        result = generate();
        Set(key, result, lifetime);
      }
      return (T)result;
    }

    /// <summary>
    /// Set item in cache with absolute Expiration
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="lifetime">Defaults to 120 minutes</param>
    public void Set(string key, object value, TimeSpan? lifetime = null)
    {
      if (value != null)
      {
        var cache = MemoryCache.Default;
        if (!lifetime.HasValue)
          lifetime = TimeSpan.FromMinutes(120);//default to 120 minutes for now
        cache.Set(key, value, new CacheItemPolicy() { AbsoluteExpiration = DateTime.Now.Add(lifetime.Value) });
      }
    }
  }
}