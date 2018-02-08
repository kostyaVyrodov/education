using System;
using System.IO;
using System.Linq;

namespace SolidOod.Module4
{
    public class MessageStore
    {
        private readonly StoreLogger log;
        private readonly StoreCache cache;
        private readonly IStore store;

        public MessageStore(DirectoryInfo workingDirectory)
        {
            if (workingDirectory == null)
                throw new ArgumentNullException("workingDirectory");
            if (!workingDirectory.Exists)
                throw new ArgumentException("Boo", "workingDirectory");

            log = new StoreLogger();
            cache = new StoreCache();
            store = new FileStore(workingDirectory);
        }

        public void Save(int id, string message)
        {
            Log.Saving(id);
            store.WriteAllText(id, message);
            Cache.AddOrUpdate(id, message);
            Log.Saved(id);
        }

        public Maybe<string> Read(int id)
        {
            Log.Reading(id);

            var message = Cache.GetOrAdd(id, _ => store.ReadAllText(id));

            if (message.Any())
                Log.Reading(id);
            else 
                Log.DidNotFind(id);

            Log.Returning(id);
            return message;
        }


        protected virtual StoreCache Cache => cache;

        protected virtual StoreLogger Log => log;
    }
}
