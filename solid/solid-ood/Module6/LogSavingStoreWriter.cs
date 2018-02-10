using System;
using SolidOod.Module6.Interfaces;

namespace SolidOod.Module6
{
    public class LogSavingStoreWriter: IStoreWriter
    {
        public void Save(int id, string message)
        {
            Console.WriteLine("Saving message {id}.", id);
        }
    }
}
