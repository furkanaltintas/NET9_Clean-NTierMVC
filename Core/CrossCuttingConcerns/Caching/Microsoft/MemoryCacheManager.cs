using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Core.CrossCuttingConcerns.Caching.Microsoft;

public class MemoryCacheManager : ICacheManager
{
    private readonly IMemoryCache _cache;
    private readonly List<string> _cacheKeys = new();

    public MemoryCacheManager()
    {
        _cache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
    }

    public void Add(string key, object data, int duration)
    {
        _cacheKeys.Add(key);
        _cache.Set(key, data, TimeSpan.FromMinutes(duration));
    }



    public T Get<T>(string key) =>
        _cache.Get<T>(key);



    public object Get(string key) =>
        _cache.Get(key);



    public bool IsAdd(string key) =>
        _cache.TryGetValue(key, out _); // _ => Değerin kullanılmayacağını veya kontrol edilmeyeceğini belirtmek için kullanılır



    public void Remove(string key) =>
        _cache.Remove(key);



    // Elimizdeki patterna uyan cacheleri bulup silmeye yarıyor
    public void RemoveByPattern(string pattern) // "IProductService.Get"
    {
        foreach (var key in _cacheKeys.ToArray()) // "Business.Abstract.IProductService.GetAllByCategoryAsync(2)"
        {
            if (key.Contains(pattern))
            {
                _cacheKeys.Remove(key); // Listeden kaldırın
                _cache.Remove(key); // Önbellekten kaldırın
            }
        }

        #region cacheEntriesCollectionDefinition kısmı null olarak geliyor. Kontrol yapılacak
        //var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        //var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_cache) as dynamic;

        //List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

        //foreach (var cacheItem in cacheEntriesCollection)
        //{

        //    ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
        //    cacheCollectionValues.Add(cacheItemValue);
        //}

        //var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
        //var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

        //foreach (var key in keysToRemove)
        //{
        //    _cache.Remove(key);
        //}
        #endregion
    }
}