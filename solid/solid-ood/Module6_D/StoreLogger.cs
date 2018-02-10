using System;
using System.Linq;
using SolidOod.Module1;
using SolidOod.Module6_D.Interfaces;

namespace SolidOod.Module6_D
{
    // Replace static Console on ILogger
    public class StoreLogger : IStoreWriter, IStoreReader
    {
        private readonly IStoreWriter writer;
        private readonly IStoreReader reader;

        public StoreLogger(IStoreWriter writer, IStoreReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void Save(int id, string message)
        {
            Console.WriteLine($"Saving message {id}.");
            writer.Save(id, message);
            Console.WriteLine($"Saved message {id}.");
        }

        public Maybe<string> Read(int id)
        {
            Console.WriteLine($"Reading message {id}.");
            var retVal = this.reader.Read(id);

            if (retVal.Any())
                Console.WriteLine($"Returning message {id}.");
            else
                Console.WriteLine($"No message {id} found.");

            return retVal;
        }
    }
}
