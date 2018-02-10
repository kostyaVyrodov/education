using System;
using System.Collections.Concurrent;

namespace SolidOod.Module3_O
{
    public class StoreCache
    {
        private readonly ConcurrentDictionary<int, string> cache;

        public StoreCache()
        {
            this.cache = new ConcurrentDictionary<int, string>();
        }

        public void AddOrUpdate(int id, string message)
        {
            this.cache.AddOrUpdate(id, message, (i, s) => message);
        }

        public string GetOrAdd(int id, Func<int, string> messageFactory)
        {
            return this.cache.GetOrAdd(id, messageFactory);
        }
    }
}
