using System;
using System.Linq;

using Enyim.Caching.Memcached;
using Enyim.Caching;

namespace Q42.Wheels.Caching.Memcached
{
  /// <summary>
  /// Implementation of a shared cacheservice via MemCached. Configuration is handled via the regular Application Configuration (web.config/app.config) section of Memcached.
  /// </summary>
  public class MemcachedService : ICacheService
  {
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(MemcachedService));

    private readonly MemcachedClient client;
    private readonly string keyPrefix;

    /// <summary>
    /// Create the Memcached Service
    /// </summary>
    /// <param name="keyPrefix"></param>
    public MemcachedService(string keyPrefix)
    {
      this.client = new MemcachedClient();
      this.keyPrefix = keyPrefix;

      log.InfoFormat("MemcachedService started with prefix: '{0}'", keyPrefix);
    }

    /// <summary>
    /// Explicitly check for invalid keys, so we can log better errors
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    private static bool invalidKey(string key)
    {
      return key.Contains(' ') || key.Any(c => c >= 0x00 && c <= 0x20);
    }

    /// <summary>
    /// Retrieve the given item from the Memcached server or generate() it and store it.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="generate"></param>
    /// <param name="lifetime"></param>
    /// <returns></returns>
    public T Get<T>(string key, Func<T> generate, TimeSpan? lifetime = null)
    {
      if (invalidKey(key))
      {
        log.ErrorFormat("Can't use as key: {0}", key);
        return generate();
      }

      var fullKey = this.keyPrefix + "." + key;

      object value = client.Get(fullKey);
      if (value != null)
      {
        log.DebugFormat("Cache hit for key {0}", fullKey);
        return (T)value;
      }

      log.DebugFormat("Generate cache for key {0}", fullKey);
      value = generate();
      Set(key, value, lifetime);

      return (T)value;
    }

    /// <summary>
    /// Store the given item with the given key in the memcached server
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="lifetime"></param>
    public void Set(string key, object value, TimeSpan? lifetime = null)
    {
      if (invalidKey(key))
      {
        log.ErrorFormat("Can't use as key: {0}", key);
      }

      var fullKey = this.keyPrefix + "." + key;

      var lt = lifetime.HasValue ? lifetime.Value : TimeSpan.FromMinutes(1);
      client.Store(StoreMode.Set, fullKey, value, lt);
    }
  }
}
