using System;
using System.IO;
using SolidOod.Module1;
using SolidOod.Module6_D.Interfaces;

namespace SolidOod.Module6_D
{
    public class FileStore : IFileLocator, IStoreReader, IStoreWriter
    {
        private readonly DirectoryInfo workingDirectory;

        public FileStore(DirectoryInfo workingDirectory)
        {
            if (workingDirectory == null)
                throw new ArgumentNullException("workingDirectory");
            if (!workingDirectory.Exists)
                throw new ArgumentException("Boo", "workingDirectory");

            this.workingDirectory = workingDirectory;

        }

        public void Save(int id, string message)
        {
            var path = this.GetFileInfo(id).FullName;
            File.WriteAllText(path, message);
        }

        public Maybe<string> Read(int id)
        {
            var file = GetFileInfo(id);

            if (!file.Exists)
            {
                return new Maybe<string>();
            }

            var path = file.FullName;
            return new Maybe<string>(File.ReadAllText(path));
        }

        public FileInfo GetFileInfo(int id)
        {
            return new FileInfo(Path.Combine(workingDirectory.FullName, id + ".txt"));
        }
    }
}
