using System;
using System.Collections.Generic;
using System.Linq;

namespace Q42.Wheels.Caching
{
  /// <summary>
  /// This cache service implementation uses an in memory dictionary to store objects and retrieve those. 
  /// </summary>
  public class MockCacheService : ICacheService
  {
    private Dictionary<string, Tuple<DateTime, object>> store;

    /// <summary>
    /// create mock cache service
    /// </summary>
    public MockCacheService()
    {
      this.store = new Dictionary<string, Tuple<DateTime, object>>();
    }

    /// <summary>
    /// return the item from in memory dictionary or sets it using the given generate function() and returns it.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="generate"></param>
    /// <param name="lifetime"></param>
    /// <returns></returns>
    public T Get<T>(string key, Func<T> generate, TimeSpan? lifetime = null)
    {
      if (store.ContainsKey(key))
      {
        var t = store[key];

        if (t.Item1 >= DateTime.Now)
          return (T)t.Item2;

        store.Remove(key);
      }

      if (store.Count > 100)
        foreach (var k in store.Take(10).Select(kv => kv.Key))
          store.Remove(k);

      var v = generate();
      store[key] = Tuple.Create(DateTime.Now + (lifetime ?? TimeSpan.FromMinutes(1)), (object)v);
      return v;
    }

    /// <summary>
    /// set the given value with given key in the in memory dictionary cache
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="lifetime"></param>
    public void Set(string key, object value, TimeSpan? lifetime = null)
    {
      if (store.ContainsKey(key))
        store.Remove(key);

      store[key] = Tuple.Create(DateTime.Now + (lifetime ?? TimeSpan.FromMinutes(1)), (object)value);
    }
  }
}
