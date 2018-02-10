using System.IO;

namespace SolidOod.Module3_O
{
    public class FileStore
    {
        public virtual void WriteAllText(string path, string message)
        {
            File.WriteAllText(path, message);
        }

        public virtual string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        public virtual FileInfo GetFileInfo(int id, string workingDir)
        {
            return new FileInfo(Path.Combine(workingDir, id + ".txt"));
        }
    }
}
