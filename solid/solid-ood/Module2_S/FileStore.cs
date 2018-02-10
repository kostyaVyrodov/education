using System.IO;

namespace SolidOod.Module2_S
{
    public class FileStore
    {
        public void WriteAllText(string path, string message)
        {
            File.WriteAllText(path, message);
        }

        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        public FileInfo GetFileInfo(int id, string workingDir)
        {
            return new FileInfo(Path.Combine(workingDir, id + ".txt"));
        }
    }
}
