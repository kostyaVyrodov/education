using System;
using SolidOod.Module1;
using SolidOod.Module5_I.Interfaces;

namespace SolidOod.Module5_I
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
