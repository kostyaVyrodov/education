using System;
using System.IO;

namespace SolidOod.Module4
{
    public class FileStore : IStore
    {
        public DirectoryInfo WorkingDirectory;

        public FileStore(DirectoryInfo workingDirectory)
        {
            if (workingDirectory == null)
                throw new ArgumentNullException("workingDirectory");
            if (!workingDirectory.Exists)
                throw new ArgumentException("Boo", "workingDirectory");

            WorkingDirectory = workingDirectory;

        }

        public virtual void WriteAllText(int id, string message)
        {
            var path = this.GetFileInfo(id).FullName;
            File.WriteAllText(path, message);
        }

        public virtual Maybe<string> ReadAllText(int id)
        {
            var file = GetFileInfo(id);

            if (!file.Exists)
            {
                return new Maybe<string>();
            }

            var path = file.FullName;
            return new Maybe<string>(File.ReadAllText(path));
        }

        public virtual FileInfo GetFileInfo(int id)
        {
            return new FileInfo(Path.Combine(WorkingDirectory.FullName, id + ".txt"));
        }
    }
}
