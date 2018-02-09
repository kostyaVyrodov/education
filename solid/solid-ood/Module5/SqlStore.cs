using System;
using System.IO;
using SolidOod.Module5.Interfaces;

namespace SolidOod.Module5
{
    public class SqlStore: IStore
    {
        public Maybe<string> ReadAllText(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(int id, string message)
        {
            throw new NotImplementedException();
        }
    }
}
