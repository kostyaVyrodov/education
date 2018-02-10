using System;
using SolidOod.Module5_I.Interfaces;

namespace SolidOod.Module5_I
{
    public class StoreLogger : IStoreLogger
    {
        public void Saving(int id)
        {
            Console.WriteLine($"Saving message {id}.");
        }

        public void Saved(int id)
        {
            Console.WriteLine($"Saved message {id}.");
        }

        public void Reading(int id)
        {
            Console.WriteLine($"Reading message {id}.");
        }

        public void DidNotFind(int id)
        {
            Console.WriteLine($"No message {id} found.");
        }

        public void Returning(int id)
        {
            Console.WriteLine($"Returning message {id}.");
        }
    }
}
