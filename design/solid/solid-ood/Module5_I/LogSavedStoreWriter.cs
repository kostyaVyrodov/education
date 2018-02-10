using System;
using SolidOod.Module6_D.Interfaces;

namespace SolidOod.Module5_I
{
    public class LogSavedStoreWriter : IStoreWriter
    {
        public void Save(int id, string message)
        {
            Console.WriteLine("Saved message {id}.", id);
        }
    }
}
