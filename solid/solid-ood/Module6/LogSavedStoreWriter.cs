using System;
using SolidOod.Module6.Interfaces;

namespace SolidOod.Module6
{
    public class LogSavedStoreWriter:IStoreWriter
    {
        public void Save(int id, string message)
        {
            Console.WriteLine("Saved message {id}.", id);
        }
    }
}
