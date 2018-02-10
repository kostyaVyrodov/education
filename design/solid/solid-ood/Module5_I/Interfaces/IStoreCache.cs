using System;
using SolidOod.Module1;

namespace SolidOod.Module5_I.Interfaces
{
    public interface IStoreCache
    {
        void Save(int id, string message);

        Maybe<string> GetOrAdd(int id, Func<int, Maybe<string>> messageFactory);
    }
}