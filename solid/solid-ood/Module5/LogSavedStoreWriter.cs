using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidOod.Module4;
using SolidOod.Module5.Interfaces;

namespace SolidOod.Module5
{
    public class LogSavedStoreWriter:IStoreWriter
    {
        public void Save(int id, string message)
        {
            Console.WriteLine("Saved message {id}.", id);
        }
    }
}
