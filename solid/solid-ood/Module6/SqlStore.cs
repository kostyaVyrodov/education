using System;
using SolidOod.Module6.Interfaces;

namespace SolidOod.Module6
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
