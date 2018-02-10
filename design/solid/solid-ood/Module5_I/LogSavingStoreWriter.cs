using System;
using SolidOod.Module6_D.Interfaces;

namespace SolidOod.Module5_I
{
    public class LogSavingStoreWriter: IStoreWriter
    {
        public void Save(int id, string message)
        {
            Console.WriteLine("Saving message {id}.", id);
        }
    }
}
