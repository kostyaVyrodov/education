using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidOod.Module4
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
