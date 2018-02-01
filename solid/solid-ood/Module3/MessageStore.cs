using System;
using System.IO;

namespace SolidOod.Module3
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
            log.Saving(id);
            var fileInfo = fileStore.GetFileInfo(id, WorkingDirectory);
            fileStore.WriteAllText(fileInfo.FullName, message);
            cache.AddOrUpdate(id, message);
            log.Saved(id);
        }

        // var message = fileStore.Read(49).DefaultIfEmpty("").Single();
        public Maybe<string> Read(int id)
        {
            log.Reading(id);
            var fileInfo = fileStore.GetFileInfo(id, WorkingDirectory);

            if (!fileInfo.Exists)
            {
                log.DidNotFind(id);
                return new Maybe<string>();
            }

            var message = cache.GetOrAdd(id, _ => fileStore.ReadAllText(fileInfo.FullName));
            log.Returning(id);
            return new Maybe<string>(message);
        }
    }
}
