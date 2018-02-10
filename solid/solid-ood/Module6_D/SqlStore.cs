using System;
using SolidOod.Module1;
using SolidOod.Module6_D.Interfaces;

namespace SolidOod.Module6_D
{
    public class SqlStore: IStoreReader, IStoreWriter
    {
        public Maybe<string> Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(int id, string message)
        {
            throw new NotImplementedException();
        }
    }
}
