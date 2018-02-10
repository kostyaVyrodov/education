using System;
using System.Collections.Concurrent;
using SolidOod.Module1;
using SolidOod.Module5_I.Interfaces;

namespace SolidOod.Module5_I
{
    public class StoreCache : IStoreCache
    {
        private readonly ConcurrentDictionary<int, Maybe<string>> cache;

        public StoreCache()
        {
            this.cache = new ConcurrentDictionary<int, Maybe<string>>();
        }

        public void Save(int id, string message)
        {
            var m = new Maybe<string>(message);
            this.cache.AddOrUpdate(id, m, (i, s) => m);
        }

        public Maybe<string> GetOrAdd(int id, Func<int, Maybe<string>> messageFactory)
        {
            return this.cache.GetOrAdd(id, messageFactory);
        }
    }
}
