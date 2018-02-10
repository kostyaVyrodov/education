using System;

namespace SolidOod.Module6.Interfaces
{
    public interface IStoreCache
    {
        void Save(int id, string message);

        Maybe<string> GetOrAdd(int id, Func<int, Maybe<string>> messageFactory);
    }
}