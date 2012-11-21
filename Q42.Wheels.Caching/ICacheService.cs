using System;

namespace Q42.Wheels.Caching
{
  /// <summary>
  /// Expose cachingservice specific methods
  /// </summary>
  public interface ICacheService
  {
    /// <summary>
    /// Get the requested object stored under key <paramref name="key"/> or generate() the object and store it for the given <paramref name="lifetime"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="generate"></param>
    /// <param name="lifetime"></param>
    /// <returns></returns>
    T Get<T>(string key, Func<T> generate, TimeSpan? lifetime = null);
    
    /// <summary>
    /// Set the given object in the cache with the given <paramref name="lifetime"/> as key <paramref name="key"/>
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="lifetime"></param>
    void Set(string key, object value, TimeSpan? lifetime = null);
  }
}
