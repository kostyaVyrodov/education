using System;
using System.IO;
using SolidOod.Module1;

namespace SolidOod.Module3_O
{
    public class MessageStore
    {
        private readonly StoreLogger log;
        private readonly StoreCache cache;
        private readonly FileStore fileStore;

        public MessageStore(string workingDirectory)
        {
            if (workingDirectory == null)
                throw new ArgumentNullException("workingDirectory");
            if (!Directory.Exists(workingDirectory))
                throw new ArgumentException("Boo", "workingDirectory");

            WorkingDirectory = workingDirectory;
            log = new StoreLogger();
            cache = new StoreCache();
            fileStore = new FileStore();
        }

        // It's easy to create instance with null property. The GetFileName won't work.
        public string WorkingDirectory { get; private set; }

        public void Save(int id, string message)
        {
            Log.Saving(id);
            var fileInfo = Store.GetFileInfo(id, WorkingDirectory);
            Store.WriteAllText(fileInfo.FullName, message);
            Cache.AddOrUpdate(id, message);
            Log.Saved(id);
        }

        // var message = fileStore.Read(49).DefaultIfEmpty("").Single();
        public Maybe<string> Read(int id)
        {
            Log.Reading(id);
            var fileInfo = Store.GetFileInfo(id, WorkingDirectory);

            if (!fileInfo.Exists)
            {
                Log.DidNotFind(id);
                return new Maybe<string>();
            }

            var message = Cache.GetOrAdd(id, _ => Store.ReadAllText(fileInfo.FullName));
            Log.Returning(id);
            return new Maybe<string>(message);
        }

        protected virtual FileStore Store => fileStore;

        protected virtual StoreCache Cache => cache;

        protected virtual StoreLogger Log => log;
    }
}
