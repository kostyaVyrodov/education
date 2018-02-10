using System;
using System.IO;
using SolidOod.Module1;

namespace SolidOod.Module4_L
{
    public class SqlStore: IStore
    {
        public FileInfo GetFileInfo(int id)
        {
            throw new NotImplementedException();
        }

        public Maybe<string> ReadAllText(int id)
        {
            throw new NotImplementedException();
        }

        public void WriteAllText(int id, string message)
        {
            throw new NotImplementedException();
        }
    }
}
