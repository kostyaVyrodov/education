using System;
using System.IO;
using System.Linq;
using SolidOod.Module1;
using SolidOod.Module5_I.Interfaces;

namespace SolidOod.Module5_I
{
    public class MessageStore
    {
        private readonly IStoreLogger log;
        private readonly StoreCache cache;
        private readonly FileStore store;

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
            new LogSavingStoreWriter().Save(id, message);
            store.Save(id, message);
            Cache.Save(id, message);
            new LogSavedStoreWriter().Save(id, message);
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

        public FileInfo GetFileInfo(int id)
        {
            return this.FileLocator.GetFileInfo(id);
        }

        protected virtual IFileLocator FileLocator => store;

        protected virtual StoreCache Cache => cache;

        protected virtual IStoreLogger Log => log;
    }
}
