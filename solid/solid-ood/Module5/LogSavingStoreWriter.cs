using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidOod.Module5.Interfaces;

namespace SolidOod.Module5
{
    public class LogSavingStoreWriter: IStoreWriter
    {
        public void Save(int id, string message)
        {
            Console.WriteLine("Saving message {id}.", id);
        }
    }
}
