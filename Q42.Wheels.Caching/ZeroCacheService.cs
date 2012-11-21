using System;

namespace Q42.Wheels.Caching
{
  /// <summary>
  /// The ZeroCacheService does not cache anything. It will always use the generate() function to return results when calling Get()
  /// </summary>
  public class ZeroCacheService : ICacheService
  {
    /// <summary>
    /// return object from generate() function (this implementation does not cache)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="generate"></param>
    /// <param name="lifetime"></param>
    /// <returns></returns>
    public T Get<T>(string key, Func<T> generate, TimeSpan? lifetime = null)
    {
      return generate();
    }

    /// <summary>
    /// nothing. (this implementation does not cache)
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="lifetime"></param>
    public void Set(string key, object value, TimeSpan? lifetime = null)
    {
    }
  }
}
