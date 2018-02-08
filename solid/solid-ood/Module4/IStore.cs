using System.IO;

namespace SolidOod.Module4
{
    public interface IStore
    {
        FileInfo GetFileInfo(int id);

        Maybe<string> ReadAllText(int id);

        void WriteAllText(int id, string message);
    }
}