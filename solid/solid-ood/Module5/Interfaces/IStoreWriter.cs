using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidOod.Module5.Interfaces
{
    public interface IStoreWriter
    {
        void Save(int id, string message);
    }
}
