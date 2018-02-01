using System;
using System.IO;

namespace SolidOod
{
    public class FileStore
    {
        public FileStore(string workingDirectory)
        {
            if (workingDirectory == null)
                throw new ArgumentNullException("workingDirectory");
            if (!Directory.Exists(workingDirectory))
                throw new ArgumentException("Boo", "workingDirectory");

            this.WorkingDirectory = workingDirectory;
        }

        // It's easy to create instance with null property. The GetFileName won't work.
        public string WorkingDirectory { get; private set; }

        public void Save(int id, string message)
        {
            var path = GetFileName(id);
            File.WriteAllText(path, message);
        }

        public bool Exists(int id)
        {
            var path = this.GetFileName(id);
            return File.Exists(path);
        }

        public string Read(int id)
        {
            // No events, no void
            var path = GetFileName(id);
            var msg = File.ReadAllText(path);
            return msg;
        }

        public bool TryRead(int id, out string message)
        {
            message = null;
            var path = GetFileName(id);
            if (!File.Exists(path))
                return false;

            message = File.ReadAllText(path);
            return true;
        }

        // var message = fileStore.Read(49).DefaultIfEmpty("").Single();
        public Maybe<string> ReadMaybe(int id)
        {
            var path = GetFileName(id);

            if (!File.Exists(path))
                return new Maybe<string>();

            var message = File.ReadAllText(path);
            return new Maybe<string>(message);
        }

        public string GetFileName(int id)
        {
            return Path.Combine(this.WorkingDirectory, id + ".txt");
        }
    }
}
