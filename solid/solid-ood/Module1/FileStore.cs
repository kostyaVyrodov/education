using System;
using System.IO;

namespace Module1.SolidOod
{
    public class FileStore
    {
        public FileStore(string workingDirectory)
        {
            if(workingDirectory == null) 
                throw new ArgumentNullException("workingDirectory");

            this.WorkingDirectory = workingDirectory;
        }

        // It's easy to create instance with null property. The GetFileName won't work.
        public string WorkingDirectory { get; private set; }

        public void Save(int id, string message)
        {
            var path = GetFileName(id);
            File.WriteAllText(path, message);
        }

        public string Read(int id)
        {
            // No events, no void
            var path = GetFileName(id);
            var msg = File.ReadAllText(path);
            return msg;
        }

        public string GetFileName(int id)
        {
            return Path.Combine(this.WorkingDirectory, id + ".txt");
        }
    }
}
